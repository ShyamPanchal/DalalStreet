using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient.Pages
{
    public partial class GamePlayer : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Application["Game"] == null)
            {
                (Master as MasterPage).DoLogout();
            } else
            {
                try
                {
                    await UpdateData();
                }
                catch (Exception ex)
                {

                }
            }
        }


        protected async void Timer_Tick(object sender, EventArgs e)
        {
            Simulation game = (Simulation)Application["Game"];
            if (game == null)
            {
                (this.Master as MasterPage).DoLogout();
                //Todo redirect to an error page
                Response.Redirect("~/Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            } else if (game.Running)
            {

                if (Request.Cookies["UserID"] != null)
                {
                    try
                    {
                        await UpdateData();
                    }
                    catch (Exception ex)
                    {

                    }
                }

            } else
            {
                //the case of admin check first
                Response.Redirect("~/Pages/ResultPage.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        private async Task UpdateData()
        {
            HttpCookie userCookie = Request.Cookies["UserID"];
            Player player = await Core.Controllers.DalalStreetAPIController.GetInstance().GetPlayer(Int32.Parse(userCookie.Value));
            IEnumerable<Company> companies = await Core.Controllers.DalalStreetAPIController.GetInstance().GetCompanies();
            string companyJson = "";
            foreach (Company company in companies)
            {
                Inventory inventory = await Core.Controllers.DalalStreetAPIController.GetInstance().GetPlayerInventory(player.Id, company.Id);

                companyJson = companyJson + company.toJson(inventory.ownedStocks) + ",";
            }
            if (companies.Count() > 0)
            {
                companyJson = companyJson.Substring(0, companyJson.Length - 1);
            }
            companyJson = companyJson + "";
            StocksFromServer.Value = companyJson;

            IEnumerable<Event> events = await Core.Controllers.DalalStreetAPIController.GetInstance().GetEvents(10);

            string eventJson = "[";
            foreach (Event _event in events)
            {
                Company c = await Core.Controllers.DalalStreetAPIController.GetInstance().GetCompany(_event.OnCompanyId);
                EventType et = await Core.Controllers.DalalStreetAPIController.GetInstance().GetEventType(_event.EventTypeId);
                eventJson = eventJson + "\"" + c.Name
                    + " " + et.TypeString + "\",";
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
            if (!await Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning())
            {
                Response.Redirect("~/Pages/ResultPage.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        public async void BuyStocks(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserID"];
            await Core.Controllers.DalalStreetAPIController.GetInstance().BuyStock(
                Int32.Parse(userCookie.Value), 
                Int32.Parse(HiddenCompanyId.Value),
                Int32.Parse(quantityToPurchase.Value));
            await UpdateData();
        }

        public async void SellStocks(object sender, EventArgs e)
        {
            try
            {
                int id = -1;
                int companyId = -1;
                int qtd = -1;
                HttpCookie userCookie = Request.Cookies["UserID"];
                Int32.Parse(userCookie.Value);
                Int32.Parse(HiddenCompanyId.Value);
                Int32.Parse(quantityToPurchase.Value);
                await Core.Controllers.DalalStreetAPIController.GetInstance().SellStock(id, companyId, qtd);
                await UpdateData();
            }
            catch(Exception ex)
            {

            }

        }
    }
}