using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient.Pages
{
    public partial class GamePlayer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["Game"] == null)
            {
                (Master as MasterPage).DoLogout();
            } else
            {
                UpdateData();
            }
        }


        protected void Timer_Tick(object sender, EventArgs e)
        {
            Simulation game = (Simulation)Application["Game"];
            if (game == null)
            {
                (this.Master as MasterPage).DoLogout();
                //Todo redirect to an error page
                Response.Redirect("~/Login.aspx");
            } else if (game.Running)
            {
                if (Request.Cookies["UserID"] != null)
                {
                    UpdateData();
                }

            } else
            {
                //the case of admin check first
                Response.Redirect("~/Pages/ResultPage.aspx");
            }
        }

        private void UpdateData()
        {
            HttpCookie userCookie = Request.Cookies["UserID"];
            Player player = Core.Controllers.DalalStreetAPIController.GetInstance().GetPlayer(Int32.Parse(userCookie.Value));
            IEnumerable<Company> companies = Core.Controllers.DalalStreetAPIController.GetInstance().GetCompanies();
            string companyJson = "";
            foreach (Company company in companies)
            {
                Inventory inventory = Core.Controllers.DalalStreetAPIController.GetInstance().GetPlayerInventory(player.Id, company.Id);

                companyJson = companyJson + company.toJson(inventory.ownedStocks) + ",";
            }
            if (companies.Count() > 0)
            {
                companyJson = companyJson.Substring(0, companyJson.Length - 1);
            }
            companyJson = companyJson + "";
            StocksFromServer.Value = companyJson;

            IEnumerable<Event> events = Core.Controllers.DalalStreetAPIController.GetInstance().GetEvents(10);

            string eventJson = "[";
            foreach (Event _event in events)
            {
                eventJson = eventJson + "\"" + Core.Controllers.DalalStreetAPIController.GetInstance().GetCompany(_event.OnCompanyId).Name
                    + " " + Core.Controllers.DalalStreetAPIController.GetInstance().GetEventType(_event.EventTypeId).TypeString + "\",";
            }
            if (events.Count() > 0)
            {
                eventJson = eventJson.Substring(0, eventJson.Length - 1);
            }
            eventJson = eventJson + "]";
            NewsFromServer.Value = eventJson;

            UserInfoFromServer.Value = "\"balance\":" + player.Balance;
            PlayerBalance.Value = "" + player.Balance;

            //reforce checking
            if (!Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning())
            {
                Response.Redirect("~/Pages/ResultPage.aspx");
            }
        }

        public void BuyStocks(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserID"];
            Core.Controllers.DalalStreetAPIController.GetInstance().BuyStock(
                Int32.Parse(userCookie.Value), 
                Int32.Parse(HiddenCompanyId.Value),
                Int32.Parse(quantityToPurchase.Value));
            UpdateData();
        }

        public void SellStocks(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserID"];
            Core.Controllers.DalalStreetAPIController.GetInstance().SellStock(
                Int32.Parse(userCookie.Value),
                Int32.Parse(HiddenCompanyId.Value),
                Int32.Parse(quantityToPurchase.Value));
            UpdateData();
        }
    }
}