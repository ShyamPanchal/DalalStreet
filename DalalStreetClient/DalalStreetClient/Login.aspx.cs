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
                if (name == "Admin#Admin")
                {
                    string ip = Request.UserHostAddress;
                    GetIpValue(out ip);
                    user = new User("Admin", ip, Core.Models.User.Category.Admin);

                    if (!ExistsGame())
                    {
                        Simulation game = new Simulation(user);
                        IEnumerable<Player> players = Core.Controllers.DalalStreetAPIController.GetInstance().GetAllPlayers();
                        foreach (Player player in players)
                        {
                            User  p_user = new User(player.Name, "", Core.Models.User.Category.Player);
                            p_user.player = player;
                            game.Players.Add(p_user);
                        }
                        Application["Game"] = game;
                        Application["Times"] = 0;
                    } 
                }
                else
                {                    
                    if (ExistsGame())
                    {
                        string ip = Request.UserHostAddress;
                        GetIpValue(out ip);
                        user = new User(name, ip, Core.Models.User.Category.Player);

                        //Adding a player to the game
                        Simulation game = (Simulation)Application["Game"];
                        Player player = null;
                        //trying to recover the player if the game is running
                        if (game.Running)
                        {
                            IEnumerable<Player> ps =  Core.Controllers.DalalStreetAPIController.GetInstance().GetAllPlayers();
                            foreach(Player p in ps)
                            {
                                if (user.Name == p.Name)
                                {
                                    player = p;
                                }
                            }
                        } 
                        if (player == null)
                        {
                            player = Core.Controllers.DalalStreetAPIController.GetInstance().AddPlayer(user.Name);
                        }
                        user.player = player;
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
                    //in the case the user is a admin
                    if (user.category == Core.Models.User.Category.Admin)
                    {
                        userCookie = new HttpCookie("UserID", "" + user.Name);
                        Simulation game = (Simulation)Application["Game"];
                        game.Running = Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();
                    } else
                    {
                        userCookie = new HttpCookie("UserID", "" + user.player.Id);
                    }
                    userCookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(userCookie);

                    HttpCookie c0 = new HttpCookie("UserCategory", "" + user.category);

                    Session["role"] = user.category.ToString();
                    Session["userIP"] = user.IP;                    
                    c0.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(c0);

                    HttpCookie c1 = new HttpCookie("UserName", user.Name);
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
            bool e = Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();
            if (e && game == null)
            {
                User u = new User("Admin", "", Core.Models.User.Category.Admin);
                game = new Simulation(u);
                game.Running = true;
                Application["Game"] = game;
            }
            return game != null;
        }

        protected void VerifyUser(object source, ServerValidateEventArgs args)
        {
            if (DuplicatedUser(textboxUserName.Text))
            {
                args.IsValid = false;
            }
        }
        //verify if exists an user with the name
        private bool DuplicatedUser(string name)
        {
            bool e = Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();
            IEnumerable<Player> ps = Core.Controllers.DalalStreetAPIController.GetInstance().GetAllPlayers();
            foreach (Player p in ps)
            {
                if (name == p.Name && !e)
                {
                    return true;
                }
            }
            return false;
        }

        private void GetIpValue(out string ipAdd)
        {
            ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ipAdd))
            {
                ipAdd = Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                //lblIPAddress.Text = ipAdd;
            }
        }
    }
}