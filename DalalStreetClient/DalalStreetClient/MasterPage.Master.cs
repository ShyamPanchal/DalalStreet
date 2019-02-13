using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {

        public bool IsPrivateAccess(object sender)
        {
            return !((System.Web.UI.Control)sender).Page.Page.AppRelativeVirtualPath.Contains("Login.aspx") &&
                !((System.Web.UI.Control)sender).Page.Page.AppRelativeVirtualPath.Contains("Error.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = "";
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie == null)
            {
                if (IsPrivateAccess(sender))
                {
                    Response.Redirect("~/Login.aspx");
                }
                menu.Visible = false;

            }
            else
            {
                HttpCookie c1 = Request.Cookies["UserName"];
                if (c1 == null)
                {
                    userName = "user";
                }
                else
                {
                    userName = c1.Value;
                }

                HttpCookie c = Request.Cookies["UserCategory"];
                if (c == null)
                {
                    DoLogout();
                    Response.Redirect("~/Login.aspx");
                }
                else if (!IsPrivateAccess(sender) && (Session["UserId"] == null))
                {

                    ManageMenuVisibility(c.Value.ToString());
                    //send the user to the first page if is a public
                    if (c.Value == "Admin")
                    {
                        Response.Redirect("~/Pages/Dashboard/AdminDashboard.aspx");
                    }
                    else if (c.Value == "Player")
                    {
                        Response.Redirect("~/Pages/PlayerWaitingRoom.aspx");
                    }

                }
                ManageMenuVisibility(c.Value.ToString());

            }
        }

        public void ManageMenuVisibility(string categoryCookie)
        {
            Core.Models.User.Category category = Core.Models.User.ConvertCategory(categoryCookie);


            switch (category)
            {
                case Core.Models.User.Category.Admin:
                    Menu_LinkButtonAdminDashboard.Visible = true;                    
                    Menu_LinkMenuLogout.Visible = true;
                    break;
                case Core.Models.User.Category.Player:
                    Menu_LinkButtonAdminDashboard.Visible = false;

                    Menu_LinkMenuLogout.Visible = true;
                    break;
            }

        }
        private void DoLogout()
        {
            Session.Abandon();
            if (Request.Cookies["UserID"] != null)
            {
                Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
                Application.RemoveAll();
                Session.RemoveAll();
            }
        }
    }
}