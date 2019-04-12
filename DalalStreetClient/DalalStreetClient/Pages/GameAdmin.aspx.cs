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
            if (Application["Game"] == null)
            {
                (Master as MasterPage).DoLogout();
            } else
            {
                if (Request.Cookies["UserID"] != null)
                {
                    LoadTable();
                }
            }
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            Simulation game = (Simulation)Application["Game"];
            if (game == null)
            {
                (Master as MasterPage).DoLogout();
            }

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

            IEnumerable<Player> players = Core.Controllers.DalalStreetAPIController.GetInstance().GetAllPlayers();

            foreach (Player player in players)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = player.Name;
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "" + player.Score;
                row.Cells.Add(cell2);
                PlayersTable.Rows.Add(row);
            }
        }

        protected void buttonStop_Click(object sender, EventArgs e)
        {
            bool b = Core.Controllers.DalalStreetAPIController.GetInstance().StopGame();
            Simulation game = (Simulation)Application["Game"];            
            if (game != null)
            {
                game.Running = b;
                Response.Redirect("~/Pages/ResultPage.aspx");
            }
        }
    }
}