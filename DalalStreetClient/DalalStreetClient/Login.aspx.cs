using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonEnter_Click(object sender, EventArgs e)
        {

            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie == null)
            {
                // "Cookie Does not exists! Creating a cookie  now.";
                string name = textboxUserName.Text;
                User user = null;
                //Do the authentication
                if (name == "Admin")
                {
                    user = new User(name, "192.168.1.1.", Core.Models.User.Category.Admin);

                    if (!ExistsGame())
                    {
                        Simulation game = new Simulation(user);
                        Application["Game"] = game;
                        Application["Times"] = 0;
                    }

                }
                else
                {                    
                    if (ExistsGame())
                    {
                        user = new User(name, "192.168.1.1.", Core.Models.User.Category.Player);

                        //Adding a player to the game
                        Simulation game = (Simulation)Application["Game"];
                        game.Players.Add(user);
                    }
                }

                if (user == null)
                {
                    //show error message
                    //Response.Redirect("~/Pages/Error.aspx");
                    //do nothing
                }
                else
                {
                    userCookie = new HttpCookie("UserID", "" + user.Name);
                    userCookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(userCookie);

                    HttpCookie c0 = new HttpCookie("UserCategory", "" + user.category);

                    Session["role"] = user.category.ToString();

                    c0.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(c0);

                    String userName = user.Name;

                    HttpCookie c1 = new HttpCookie("UserName", userName);
                    c1.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(c1);

                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void VerifyGame(object source, ServerValidateEventArgs args)
        {
            if (!ExistsGame())
            {
                args.IsValid = false;
            }
        }

        private bool ExistsGame()
        {
            Simulation game = (Simulation)Application["Game"];
            return game != null;
        }
    }
}