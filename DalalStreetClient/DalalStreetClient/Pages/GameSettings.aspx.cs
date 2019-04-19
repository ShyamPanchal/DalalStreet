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
    public partial class GameSettings : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {

            if (Application["Game"] == null)
            {
                (Master as MasterPage).DoLogout();
            }

            if (!IsPostBack)
            {
                textboxAPUIrl.Text = Core.Services.DalalStreetAPIService.URL;
            }
            await UpdateTables();
            
        }

        private async Task UpdateTables ()
        {
            try
            {
                bool isRunning = await Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();
                buttonReset.Enabled = !isRunning;
                Simulation game = (Simulation)Application["Game"];

                //LoadCompanyNameTable();
                companyNames.Visible = false;
                await LoadCompanyCategoryTable();
                await LoadCompanyTable();
                await LoadEventTypeTable();
                await LoadEventTable();

            }
            catch (Exception exception)
            {
                //problem
            }
        }

        private async Task LoadCompanyNameTable(bool isRunning = false)
        {

            CompanyNameTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 252, 45, 45);

            TableCell cell01 = new TableCell();
            cell01.Text = "Name";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            TableCell cell05 = new TableCell();
            cell05.Text = " ";
            cell05.Font.Bold = true;
            row0.Cells.Add(cell05);

            TableCell cell06 = new TableCell();
            cell06.Text = " ";
            cell06.Font.Bold = true;
            row0.Cells.Add(cell06);

            CompanyNameTable.Rows.Add(row0);

            IEnumerable<SimpleString> companyNames = await Core.Controllers.DalalStreetAPIController.GetInstance().GetCompanyName();
            foreach (SimpleString name in companyNames)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = name.Name;
                row.Cells.Add(cell1);

                TableCell cell5 = new TableCell();
                Button buttonEdit = new Button();
                buttonEdit.Text = "Edit";
                buttonEdit.CommandArgument = name.Id.ToString();
                buttonEdit.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
                buttonEdit.Attributes.Add("autopostback", "false");
                buttonEdit.Click += (object sender, System.EventArgs args) => {
                    string id = ((Button)sender).CommandArgument;
                    Session["objId"] = id;
                    Response.Redirect("~/Pages/Settings/ManageCompanyName.aspx");
                };
                cell5.Controls.Add(buttonEdit);
                row.Cells.Add(cell5);

                TableCell cell6 = new TableCell();
                Button buttonDelete = new Button();
                buttonDelete.Text = "Delete";
                buttonDelete.CommandArgument = name.Id.ToString();
                buttonDelete.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
                buttonDelete.Attributes.Add("autopostback", "false");
                buttonDelete.Click += async (object sender, System.EventArgs args)=>
                {
                    string id = ((Button)sender).CommandArgument;
                    Core.Controllers.DalalStreetAPIController.GetInstance().DeleteCompanyName(Int16.Parse(id));
                    Response.Redirect("~/Pages/GameSettings.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                };
                cell6.Controls.Add(buttonDelete);
                row.Cells.Add(cell6);

                CompanyNameTable.Rows.Add(row);
            }

            TableRow newrow = new TableRow();
            TableCell cell = new TableCell();
            Button buttonAdd = new Button();
            buttonAdd.Text = "New";
            buttonAdd.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
            buttonAdd.Attributes.Add("autopostback", "false");
            buttonAdd.Click += (object sender, System.EventArgs args) =>
            {
                Response.Redirect("~/Pages/Settings/ManageCompanyName.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            };
            cell.Controls.Add(buttonAdd);
            row0.Cells.Add(cell);
            CompanyNameTable.Rows.Add(newrow);
        }

        private async Task LoadCompanyCategoryTable(bool isRunning = false)
        {

            CompanyCategoryTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 252, 45, 45);

            TableCell cell01 = new TableCell();
            cell01.Text = "Name";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            TableCell cell05 = new TableCell();
            cell05.Text = " ";
            cell05.Font.Bold = true;
            row0.Cells.Add(cell05);

            TableCell cell06 = new TableCell();
            cell06.Text = " ";
            cell06.Font.Bold = true;
            row0.Cells.Add(cell06);

            CompanyCategoryTable.Rows.Add(row0);

            IEnumerable<CompanyCategory> companyCategories = await Core.Controllers.DalalStreetAPIController.GetInstance().GetCompanyCategories();
            foreach (CompanyCategory category in companyCategories)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = category.Name;
                row.Cells.Add(cell1);

                TableCell cell5 = new TableCell();
                Button buttonEdit = new Button();
                buttonEdit.Text = "Edit";
                buttonEdit.CommandArgument = category.Id.ToString();
                buttonEdit.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
                buttonEdit.Attributes.Add("autopostback", "false");
                buttonEdit.Click += (object sender, System.EventArgs args) => {
                    string id = ((Button)sender).CommandArgument;
                    Session["objId"] = id;
                    Response.Redirect("~/Pages/Settings/ManageCategory.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                };
                cell5.Controls.Add(buttonEdit);
                row.Cells.Add(cell5);

                TableCell cell6 = new TableCell();
                Button buttonDelete = new Button();
                buttonDelete.Text = "Delete";
                buttonDelete.CommandArgument = category.Id.ToString();
                buttonDelete.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
                buttonDelete.Attributes.Add("autopostback", "false");
                buttonDelete.Click += (object sender, System.EventArgs args) =>
                {
                    string id = ((Button)sender).CommandArgument;
                    Core.Controllers.DalalStreetAPIController.GetInstance().DeleteCompanyCategory(Int16.Parse(id));
                    Response.Redirect("~/Pages/GameSettings.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                };
                cell6.Controls.Add(buttonDelete);
                row.Cells.Add(cell6);

                CompanyCategoryTable.Rows.Add(row);
            }

            TableRow newrow = new TableRow();
            TableCell cell = new TableCell();
            Button buttonAdd = new Button();
            buttonAdd.Text = "New";
            buttonAdd.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
            buttonAdd.Attributes.Add("autopostback", "false");
            buttonAdd.Click += (object sender, System.EventArgs args) =>
            {
                Response.Redirect("~/Pages/Settings/ManageCategory.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            };
            cell.Controls.Add(buttonAdd);
            row0.Cells.Add(cell);
            CompanyNameTable.Rows.Add(newrow);
        }

        private async Task LoadCompanyTable(bool isRunning = false)
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

            TableCell cell05 = new TableCell();
            cell05.Text = " ";
            cell05.Font.Bold = true;
            row0.Cells.Add(cell05);

            TableCell cell06 = new TableCell();
            cell06.Text = " ";
            cell06.Font.Bold = true;
            row0.Cells.Add(cell06);

            CompanyTable.Rows.Add(row0);

            IEnumerable<Company> companies = await Core.Controllers.DalalStreetAPIController.GetInstance().GetCompanies();
            foreach (Company company in companies)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = company.Name;
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                CompanyCategory category =  await Core.Controllers.DalalStreetAPIController.GetInstance().GetCompanyCategory(company.CategoryId);
                cell2.Text = category.Name;
                row.Cells.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "" + company.TotalStocks;
                row.Cells.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "" + company.StockValues;
                row.Cells.Add(cell4);

                TableCell cell5 = new TableCell();
                Button buttonEdit = new Button();
                buttonEdit.Text = "Edit";
                buttonEdit.CommandArgument = company.Id.ToString();
                buttonEdit.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
                buttonEdit.Attributes.Add("autopostback", "false");
                buttonEdit.Click += (object sender, System.EventArgs args) => {
                    string id = ((Button)sender).CommandArgument;
                    Session["objId"] = id;
                    Response.Redirect("~/Pages/Settings/ManageCompany.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                };
                cell5.Controls.Add(buttonEdit);
                row.Cells.Add(cell5);

                TableCell cell6 = new TableCell();
                Button buttonDelete = new Button();
                buttonDelete.Text = "Delete";
                buttonDelete.CommandArgument = company.Id.ToString();
                buttonDelete.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
                buttonDelete.Attributes.Add("autopostback", "false");
                buttonDelete.Click += (object sender, System.EventArgs args) =>
                {
                    string id = ((Button)sender).CommandArgument;
                    Core.Controllers.DalalStreetAPIController.GetInstance().DeleteCompany(Int16.Parse(id));
                    Response.Redirect("~/Pages/GameSettings.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                };
                cell6.Controls.Add(buttonDelete);
                row.Cells.Add(cell6);

                CompanyTable.Rows.Add(row);

            }

            TableRow newrow = new TableRow();
            TableCell cell = new TableCell();
            Button buttonAdd = new Button();
            buttonAdd.Text = "New";
            buttonAdd.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
            buttonAdd.Attributes.Add("autopostback", "false");
            buttonAdd.Click += (object sender, System.EventArgs args) =>
            {
                Response.Redirect("~/Pages/Settings/ManageCompany.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            };
            cell.Controls.Add(buttonAdd);
            row0.Cells.Add(cell);
            CompanyNameTable.Rows.Add(newrow);
        }

        private async Task LoadEventTypeTable(bool isRunning = false)
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

            TableCell cell05 = new TableCell();
            cell05.Text = " ";
            cell05.Font.Bold = true;
            row0.Cells.Add(cell05);

            TableCell cell06 = new TableCell();
            cell06.Text = " ";
            cell06.Font.Bold = true;
            row0.Cells.Add(cell06);

            EventTypeTable.Rows.Add(row0);

            IEnumerable<EventType> eventTypes = await Core.Controllers.DalalStreetAPIController.GetInstance().GetEventTypes();
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

                TableCell cell5 = new TableCell();
                Button buttonEdit = new Button();
                buttonEdit.Text = "Edit";
                buttonEdit.CommandArgument = type.Id.ToString();
                buttonEdit.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
                buttonEdit.Attributes.Add("autopostback", "false");
                buttonEdit.Click += (object sender, System.EventArgs args) => {
                    string id = ((Button)sender).CommandArgument;
                    Session["objId"] = id;
                    Response.Redirect("~/Pages/Settings/ManageType.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                };
                cell5.Controls.Add(buttonEdit);
                row.Cells.Add(cell5);

                TableCell cell6 = new TableCell();
                Button buttonDelete = new Button();
                buttonDelete.Text = "Delete";
                buttonDelete.CommandArgument = type.Id.ToString();
                buttonDelete.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
                buttonDelete.Attributes.Add("autopostback", "false");
                buttonDelete.Click += async (object sender, System.EventArgs args) =>
                {
                    string id = ((Button)sender).CommandArgument;
                    Core.Controllers.DalalStreetAPIController.GetInstance().DeleteEventType(Int16.Parse(id));
                    Response.Redirect("~/Pages/GameSettings.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                };
                cell6.Controls.Add(buttonDelete);
                row.Cells.Add(cell6);
                EventTypeTable.Rows.Add(row);
            }

            TableRow newrow = new TableRow();
            TableCell cell = new TableCell();
            Button buttonAdd = new Button();
            buttonAdd.Text = "New";
            buttonAdd.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
            buttonAdd.Attributes.Add("autopostback", "false");
            buttonAdd.Click += (object sender, System.EventArgs args) =>
            {
                Response.Redirect("~/Pages/Settings/Managetype.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            };
            cell.Controls.Add(buttonAdd);
            row0.Cells.Add(cell);
            CompanyNameTable.Rows.Add(newrow);
        }
        private async Task LoadEventTable(bool isRunning = false)
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

            TableCell cell05 = new TableCell();
            cell05.Text = " ";
            cell05.Font.Bold = true;
            row0.Cells.Add(cell05);

            TableCell cell06 = new TableCell();
            cell06.Text = " ";
            cell06.Font.Bold = true;
            row0.Cells.Add(cell06);

            NewsEventsTable.Rows.Add(row0);

            IEnumerable<Event> events = new List<Event>();

            if (!isRunning)
            {
                events = await Core.Controllers.DalalStreetAPIController.GetInstance().GetEvents(10);
            }
            foreach (Event enews in events)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                Company company= await Core.Controllers.DalalStreetAPIController.GetInstance().GetCompany(enews.OnCompanyId);
                cell1.Text = company.Name;
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                EventType type = await Core.Controllers.DalalStreetAPIController.GetInstance().GetEventType(enews.EventTypeId);
                cell2.Text = type.TypeString;
                row.Cells.Add(cell2);
                NewsEventsTable.Rows.Add(row);

                TableCell cell5 = new TableCell();
                Button buttonEdit = new Button();
                buttonEdit.Text = "Edit";
                buttonEdit.CommandArgument = enews.Id.ToString();
                buttonEdit.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
                buttonEdit.Attributes.Add("autopostback", "false");
                buttonEdit.Click += (object sender, System.EventArgs args) => {
                    string id = ((Button)sender).CommandArgument;
                    Session["objId"] = id;
                    Response.Redirect("~/Pages/Settings/ManageEvent.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                };
                cell5.Controls.Add(buttonEdit);
                row.Cells.Add(cell5);

                TableCell cell6 = new TableCell();
                Button buttonDelete = new Button();
                buttonDelete.Text = "Delete";
                buttonDelete.CommandArgument = enews.Id.ToString();
                buttonDelete.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
                buttonDelete.Attributes.Add("autopostback", "false");
                buttonDelete.Click += async (object sender, System.EventArgs args) =>
                {
                    string id = ((Button)sender).CommandArgument;
                    Core.Controllers.DalalStreetAPIController.GetInstance().DeleteEvent(Int16.Parse(id));
                    Response.Redirect("~/Pages/GameSettings.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                };
                cell6.Controls.Add(buttonDelete);
                row.Cells.Add(cell6);
            }

            TableRow newrow = new TableRow();
            TableCell cell = new TableCell();
            Button buttonAdd = new Button();
            buttonAdd.Text = "New";
            buttonAdd.CssClass = "w3-button w3-red w3-padding w3-small w3-round";
            buttonAdd.Attributes.Add("autopostback", "false");
            buttonAdd.Click += (object sender, System.EventArgs args) =>
            {
                Response.Redirect("~/Pages/Settings/ManageEvent.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            };
            cell.Controls.Add(buttonAdd);
            row0.Cells.Add(cell);
            CompanyNameTable.Rows.Add(newrow);
        }

        protected async void buttonCheckAPI_Click(object sender, EventArgs e)
        {
            string url = Core.Services.DalalStreetAPIService.URL;
            Core.Services.DalalStreetAPIService.URL = textboxAPUIrl.Text;
            await VerifyURL();
            Core.Services.DalalStreetAPIService.URL = url;
        }

        protected async void VerifyAPI(object source, ServerValidateEventArgs args)
        {
            Core.Services.DalalStreetAPIService.URL = textboxAPUIrl.Text;
            if (! await VerifyURL())
            {
                args.IsValid = false;
            }
        }

        private async Task<bool> VerifyURL()
        {
            try
            {
                await Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning();
                return true;
            } catch(Exception e)
            {
                //error
                return false;
            }
        }

        protected async void VerifyAPIWorking(object source, ServerValidateEventArgs args)
        {
            Core.Services.DalalStreetAPIService.URL = textboxAPUIrl.Text;
            if (await VerifyURL())
            {
                //using to message working
                args.IsValid = false;
            }
        }

        protected void buttonUpdateAPI_Click(object sender, EventArgs e)
        {
            Core.Services.DalalStreetAPIService.URL = textboxAPUIrl.Text;
        }

        protected async void buttonReset_click(object sender, EventArgs e)
        {
            if (!await Core.Controllers.DalalStreetAPIController.GetInstance().isGameRunning())
            {
                Core.Controllers.DalalStreetAPIController.GetInstance().resetGame();
                await UpdateTables();
            }
        }
    }
}