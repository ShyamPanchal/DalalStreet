using DalalStreetClient.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient.Pages.Dashboard
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetContent_Click(object sender, EventArgs e)
        {
            TestCallController controller = TestCallController.GetInstance();
            TestCallController.Greeting g = controller.MakeCall();
            TextBox1.Text = g.Content;
            //controller.DisposeClient();
        }
    }
}