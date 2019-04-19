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
    public partial class GameAdmin : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Application["Game"] == null)
            {
                (Master as MasterPage).DoLogout();
            } else
            {
                if (Request.Cookies["UserID"] != null)
                {
                    await LoadTable();
                }
            }
        }

        protected async void Timer_Tick(object sender, EventArgs e)
        {
            await LoadTable();
        }

        private async Task LoadTable()
        {
            IEnumerable<Player> players = await Core.Controllers.DalalStreetAPIController.GetInstance().GetAllPlayers();

            bool isGameRunning = await Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();

            buttonStop.Enabled = isGameRunning;

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

        protected async void buttonStop_Click(object sender, EventArgs e)
        {
            bool isGameRunning = await Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();
            if (isGameRunning)
            {
                bool _false = Core.Controllers.DalalStreetAPIController.GetInstance().StopGame();
                Simulation game = (Simulation)Application["Game"];            
                if (game != null)
                {
                    game.Running = _false;
                    game.Finished = true;
                    Response.Redirect("~/Pages/ResultPage.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
    }
}