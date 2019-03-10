using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient.Pages
{
    public partial class PlayerWaitingRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["Game"]==null)
            {
                //do something?
            } else
            {               
                int times = (int)Application["Times"];
                times++;
                Application["Times"] = times;
                //Update_Times.Text = "" + times;
                LoadTable();

            }
            /*
            if (!IsPostBack)
            {
                
            }*/
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            Simulation game = (Simulation)Application["Game"];
            if (game.Running)
            {
                Response.Redirect("~/Pages/GamePlayer.aspx");
            }

            PlayersTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 252, 45, 45);

            TableCell cell01 = new TableCell();
            cell01.Text = "Name";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            TableCell cell02 = new TableCell();
            cell02.Text = "IP";
            cell02.Font.Bold = true;
            row0.Cells.Add(cell02);

            PlayersTable.Rows.Add(row0);


            foreach (User user in game.Players)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = user.Name;
                row.Cells.Add(cell1);
                
                TableCell cell2 = new TableCell();
                cell2.Text = user.IP;
                row.Cells.Add(cell2);
                PlayersTable.Rows.Add(row);
            }
        }
    }
}