using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Simulation game = (Simulation)Application["Game"];

            string userName = "";
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie == null)
            {
                if (IsPrivateAccess(sender))
                {
                    Response.Redirect("~/Login.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
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
                    menu.Visible = false;
                    Response.Redirect("~/Login.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else if (!IsPrivateAccess(sender) && (userCookie != null))
                {
                    if (game == null)
                    {
                        DoLogout();
                        menu.Visible = false;
                        return;
                    } else
                    {
                        ManageMenuVisibility(c.Value.ToString());
                        //send the user to the first page if is a public
                        if (c.Value == "Admin")
                        {
                        
                            if (game == null)
                            {
                                DoLogout();
                                menu.Visible = false;
                                return;
                            }
                            Response.Redirect("~/Pages/GameSettings.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                        else if (c.Value == "Player")
                        {
                            if (!game.ContainsPlayer(userCookie.Value) && game.Restarted)
                            {
                                DoLogout();
                                menu.Visible = false;
                                return;
                            } else
                            {
                                Response.Redirect("~/Pages/PlayerWaitingRoom.aspx", false);
                                Context.ApplicationInstance.CompleteRequest();
                            }
                        
                        }
                    }
                }
                
                Menu_userName.Text = userName;
                string ip = Session["userIP"] != null ? Session["userIP"].ToString() : "";
                Menu_userIP.Text = ip;
                Menu_gameTime.Text = "00:00:00";

                ManageMenuVisibility(c.Value.ToString());

            }/*
            Simulation game = (Simulation)Application["Game"];
                        game.Running = Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();*/
        }

        public void ManageMenuVisibility(string categoryCookie)
        {
            Core.Models.User.Category category = Core.Models.User.ConvertCategory(categoryCookie);


            switch (category)
            {
                case Core.Models.User.Category.Admin:
                    Menu_LinkButtonAdminDashboard.Visible = false;
                    Menu_LinkWaitingRoom.Visible = true;
                    Menu_LinkMenuLogout.Visible = true;
                    Menu_LinkButtonGameSettings.Visible = true;
                    Menu_userName.Visible = false;
                    Menu_userIP.Visible = false;
                    Menu_gameTime.Visible = false;
                    break;
                case Core.Models.User.Category.Player:
                    Menu_LinkButtonAdminDashboard.Visible = false;
                    Menu_LinkWaitingRoom.Visible = false;
                    Menu_LinkMenuLogout.Visible = true;
                    Menu_LinkButtonGameSettings.Visible = false;
                    Menu_userName.Visible = true;
                    Menu_userIP.Visible = false;
                    Menu_gameTime.Visible = false;
                    break;
            }

        }

        protected void Menu_Settings_Room(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/GameSettings.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        protected void Menu_Waiting_Room(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdminWaitingRoom.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        protected void Menu_Home(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/AdminDashboard.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        protected void Menu_Logout_Click(object sender, EventArgs e)
        {
            DoLogout();
            Response.Redirect("~/Login.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        public void DoLogout()
        {
            Session.Abandon();
            if (Request.Cookies["UserID"] != null)
            {
                Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);                
                String role = (String)Session["role"];
                if (role != null)
                {
                    if (User.Category.Admin == User.ConvertCategory(role))
                    {
                        //Application.RemoveAll();
                        //Do not destroy game
                    } else
                    {
                        Simulation game = (Simulation)Application["Game"];
                        if (game != null)
                        {
                            int index = -1;
                            foreach (User user in game.Players)
                            {
                                String name = (String)Response.Cookies["UserName"].Value;
                                if (user.Name == name)
                                {
                                    break;
                                }
                                index++;
                            }
                            if (index > -1)
                            {
                                game.Players.RemoveAt(index);
                            }
                        }

                    }

                }
                Session.RemoveAll();
            }
        }
    }
}