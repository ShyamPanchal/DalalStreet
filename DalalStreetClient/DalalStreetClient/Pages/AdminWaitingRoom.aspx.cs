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
    public partial class AdminWaitingRoom : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Application["Game"] == null)
            {
                (Master as MasterPage).DoLogout();
            } else
            {
                HttpCookie c1 = Request.Cookies["UserName"];
                if (c1.Value == "Admin")
                {
                    Simulation game = (Simulation)Application["Game"];
                    bool isGameRunning = await Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();
                    if (isGameRunning)
                    {
                        Response.Redirect("~/Pages/GameAdmin.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }                

                await LoadTable();
            }
        }

        protected async void Timer_Tick(object sender, EventArgs e)
        {
            if (Application["Game"] == null)
            {
                //do something?
                (Master as MasterPage).DoLogout();
            }
            else
            {
                int times = (int)Application["Times"];
                times++;
                Application["Times"] = times;
                //Update_Times.Text = "" + times;
                await LoadTable();

            }            
        }

        private async Task LoadTable()
        {
            Simulation game = (Simulation)Application["Game"];
            IEnumerable<Player> players = await Core.Controllers.DalalStreetAPIController.GetInstance().GetAllPlayers();
            buttonStart.Enabled = players.Count() > 0;
             //= game.Players.Count > 0;

            PlayersTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 252, 45, 45);

            TableCell cell01 = new TableCell();
            cell01.Text = "Name";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            TableCell cell02 = new TableCell();
            cell02.Text = "Score";
            cell02.Font.Bold = true;
            row0.Cells.Add(cell02);

            PlayersTable.Rows.Add(row0);            

            foreach (Player user in players)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = user.Name;
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "" + user.Score;
                row.Cells.Add(cell2);
                PlayersTable.Rows.Add(row);
            }
        }

        protected async void buttonStart_Click(object sender, EventArgs e)
        {
            Simulation game = (Simulation)Application["Game"];
            IEnumerable<Player> players = await Core.Controllers.DalalStreetAPIController.GetInstance().GetAllPlayers();
            if (players.Count() > 0)
            {
                game.Finished = false;
                game.Running = Core.Controllers.DalalStreetAPIController.GetInstance().StartGame();
                game.Restarted = false;
                Response.Redirect("~/Pages/GameAdmin.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}