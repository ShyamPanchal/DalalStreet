using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient.Pages
{
    public partial class GameAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonStop_Click(object sender, EventArgs e)
        {
            Simulation game = (Simulation)Application["Game"];
            game.Running = false;
            Response.Redirect("~/Pages/ResultPage.aspx");
        }
    }
}