using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient.Pages
{
    public partial class GameSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCompanyNameTable();
            LoadCompanyCategoryTable();
            LoadCompanyTable();
            LoadEventTypeTable();
            LoadEventTable();
        }

        private void LoadCompanyNameTable()
        {

            CompanyNameTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 252, 45, 45);

            TableCell cell01 = new TableCell();
            cell01.Text = "Name";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            CompanyNameTable.Rows.Add(row0);

            IEnumerable<SimpleString> companyNames = Core.Controllers.DalalStreetAPIController.GetInstance().GetCompanyName();
            foreach (SimpleString name in companyNames)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = name.Name;
                row.Cells.Add(cell1);
                CompanyNameTable.Rows.Add(row);
            }
        }
        private void LoadCompanyCategoryTable()
        {

            CompanyCategoryTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 252, 45, 45);

            TableCell cell01 = new TableCell();
            cell01.Text = "Name";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            CompanyCategoryTable.Rows.Add(row0);

            IEnumerable<CompanyCategory> companyCategories = Core.Controllers.DalalStreetAPIController.GetInstance().GetCompanyCategory();
            foreach (CompanyCategory category in companyCategories)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = category.Name;
                row.Cells.Add(cell1);

                CompanyCategoryTable.Rows.Add(row);
            }
        }

        private void LoadCompanyTable()
        {

            CompanyTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 252, 45, 45);

            TableCell cell01 = new TableCell();
            cell01.Text = "Name";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            TableCell cell02 = new TableCell();
            cell02.Text = "Category";
            cell02.Font.Bold = true;
            row0.Cells.Add(cell02);

            TableCell cell03 = new TableCell();
            cell03.Text = "Total Stock";
            cell03.Font.Bold = true;
            row0.Cells.Add(cell03);

            TableCell cell04 = new TableCell();
            cell04.Text = "Stock Value";
            cell04.Font.Bold = true;
            row0.Cells.Add(cell04);

            CompanyTable.Rows.Add(row0);

            IEnumerable<Company> companies = Core.Controllers.DalalStreetAPIController.GetInstance().GetCompany();
            foreach (Company name in companies)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = name.Name;
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "" + name.CategoryId;
                row.Cells.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "" + name.TotalStocks;
                row.Cells.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "" + name.StockValues;
                row.Cells.Add(cell4);

                CompanyTable.Rows.Add(row);

            }
        }

        private void LoadEventTypeTable()
        {

            EventTypeTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 252, 45, 45);

            TableCell cell01 = new TableCell();
            cell01.Text = "Type String";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            TableCell cell02 = new TableCell();
            cell02.Text = "Likelihood";
            cell02.Font.Bold = true;
            row0.Cells.Add(cell02);

            TableCell cell03 = new TableCell();
            cell03.Text = "Effect On Self";
            cell03.Font.Bold = true;
            row0.Cells.Add(cell03);

            TableCell cell04 = new TableCell();
            cell04.Text = "Effect On Others";
            cell04.Font.Bold = true;
            row0.Cells.Add(cell04);

            EventTypeTable.Rows.Add(row0);

            IEnumerable<EventType> eventTypes = Core.Controllers.DalalStreetAPIController.GetInstance().GetEventType();
            foreach (EventType type in eventTypes)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = type.TypeString;
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "" + type.Likelihood;
                row.Cells.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "" + type.EffectOnSelf;
                row.Cells.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "" + type.EffectOnOthers;
                row.Cells.Add(cell4);

                EventTypeTable.Rows.Add(row);
            }
        }
        private void LoadEventTable()
        {

            NewsEventsTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 252, 45, 45);

            TableCell cell01 = new TableCell();
            cell01.Text = "On Company";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            TableCell cell02 = new TableCell();
            cell02.Text = "Type";
            cell02.Font.Bold = true;
            row0.Cells.Add(cell02);

            NewsEventsTable.Rows.Add(row0);

            IEnumerable<Event> events = Core.Controllers.DalalStreetAPIController.GetInstance().GetEvent();
            foreach (Event enews in events)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = "" + enews.OnCompanyId;
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "" + enews.EventTypeId;
                row.Cells.Add(cell2);
                NewsEventsTable.Rows.Add(row);
            }
        }
    }
}