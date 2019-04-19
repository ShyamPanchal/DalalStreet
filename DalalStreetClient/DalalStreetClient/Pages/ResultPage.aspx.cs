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
    public partial class ResultPage : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            buttonReset.Visible = false;
            if (Application["Game"] == null)
            {
                (Master as MasterPage).DoLogout();
            } else
            {
                int id = -1;
                HttpCookie userCookie = Request.Cookies["UserID"];
                try
                {
                    id = Int32.Parse(userCookie.Value);
                    buttonReset.Visible = false;
                }
                catch (NullReferenceException nre)
                {
                    //there is no id
                    (Master as MasterPage).DoLogout();
                }
                catch (Exception ex)
                {
                    //is the admin
                    buttonReset.Visible = true;
                }
                await LoadTable(id);
            }

        }

        private async Task LoadTable(int id)
        {
            Simulation game = (Simulation)Application["Game"];
            
            if (game == null || game.Restarted)
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

            IEnumerable<Player> players = await Core.Controllers.DalalStreetAPIController.GetInstance().GetAllPlayers();
            

            foreach (Player player in players)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = player.Name;
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "" + player.Score;
                row.Cells.Add(cell2);
                if (player.Id == id)
                {
                    row.BackColor = System.Drawing.Color.FromArgb(255, 202, 169, 169);
                }
                PlayersTable.Rows.Add(row);
            }
        }

        protected void buttonReset_Click(object sender, EventArgs e)
        {
            Core.Controllers.DalalStreetAPIController.GetInstance().resetGame();
            Simulation game = (Simulation)Application["Game"];
            game.Players = new List<User>();
            game.Restarted = true;
            Response.Redirect("~/Pages/GameSettings.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}