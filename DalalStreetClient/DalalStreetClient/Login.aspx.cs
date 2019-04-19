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
    public partial class Login : System.Web.UI.Page
    {
        public static string ADMIN = "Admin#Admin";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void buttonEnter_Click(object sender, EventArgs e)
        {
            string t = textboxUserName.Text;
            bool valid = !await DuplicatedUser(t) && !(await GameInGame(t));
            if (valid)
            {
                errorGameRunning.Visible = false;
                errorUserDuplicated.Visible = false;
                errorThereIsNoGame.Visible = false;


                HttpCookie userCookie;
                userCookie = Request.Cookies["UserID"];
                if (userCookie == null)
                {
                    // "Cookie Does not exists! Creating a cookie  now.";
                    string name = textboxUserName.Text;
                    User user = null;
                    //Do the authentication
                    if (name == ADMIN)
                    {
                        string ip = Request.UserHostAddress;
                        GetIpValue(out ip);
                        user = new User("Admin", ip, Core.Models.User.Category.Admin);

                        if (! await ExistsGame(textboxUserName.Text))
                        {
                            Simulation game = new Simulation(user);
                            IEnumerable<Player> players = await Core.Controllers.DalalStreetAPIController.GetInstance().GetAllPlayers();
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
                        if (await ExistsGame(t))
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
                                IEnumerable<Player> players =  await Core.Controllers.DalalStreetAPIController.GetInstance().GetAllPlayers();
                                foreach(Player p in players)
                                {
                                    if (user.Name == p.Name)
                                    {
                                        player = p;
                                    }
                                }
                            } 
                            if (player == null)
                            {
                                player = await Core.Controllers.DalalStreetAPIController.GetInstance().AddPlayer(user.Name);
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
                            if (game == null)
                            {
                                game = new Simulation(user);
                            }
                            game.Running = await Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();
                            game.Finished = false;
                            game.Restarted = false;
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

                        Response.Redirect("~/Login.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }

            }
        }

        protected async void VerifyGame(object source, ServerValidateEventArgs args)
        {
            if (! await ExistsGame(textboxUserName.Text))
            {
                args.IsValid = false;
                errorThereIsNoGame.Visible = false;
            }
        }

        private async Task<bool> ExistsGame(string name)
        {
            Simulation game = (Simulation)Application["Game"];
            bool e = await Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();
            if (e && game == null)
            {
                User u = new User("Admin", "", Core.Models.User.Category.Admin);
                game = new Simulation(u);
                game.Running = true;
                Application["Game"] = game;
            }
            return game != null;
        }

        protected async void VerifyUser(object source, ServerValidateEventArgs args)
        {
            if (await DuplicatedUser(textboxUserName.Text))
            {
                args.IsValid = false;
                errorUserDuplicated.Visible = true;
            }
        }
        //verify if exists an user with the name
        private async Task<bool> DuplicatedUser(string name)
        {
            bool e = await Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();
            IEnumerable<Player> ps = await Core.Controllers.DalalStreetAPIController.GetInstance().GetAllPlayers();
            foreach (Player p in ps)
            {
                if (name == p.Name && !e)
                {
                    errorUserDuplicated.Visible = true;
                    return true;
                }
            }
            errorUserDuplicated.Visible = false;
            return false;
        }

        protected async void VerifyInGame(object source, ServerValidateEventArgs args)
        {
            if (await GameInGame(textboxUserName.Text))
            {
                errorGameRunning.Visible = true;
                args.IsValid = false;
            }
        }

        private async Task<bool> GameInGame(string name)
        {
            if (name == ADMIN)
            {
                errorUserDuplicated.Visible = false;
                return false;
            }
            return await Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();
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