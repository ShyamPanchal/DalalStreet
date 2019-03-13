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
                //reforce checking
                if (!Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning())
                {
                    Response.Redirect("~/Pages/ResultPage.aspx");
                }

            } else
            {
                //the case of admin check first
                Response.Redirect("~/Pages/ResultPage.aspx");
            }
        }
    }
}