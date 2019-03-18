using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient.Pages.Settings
{
    public partial class ManageCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string idCategory = null;
            if (!IsPostBack)
            {
                if (Session["objId"] == null)
                {

                }
                else
                {
                    Company company = Core.Controllers.DalalStreetAPIController.GetInstance().GetCompany(Int16.Parse(Session["objId"].ToString()));
                    textboxName.Text = company.Name;
                    HiddenFieldId.Value = company.Id.ToString();
                    idCategory = company.CategoryId.ToString();
                }
                IEnumerable<CompanyCategory> dataSource = Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetCompanyCategories(); ;
                DropDownListCompanyCategory.DataSource = dataSource;

                if (idCategory == null)
                {
                    DropDownListCompanyCategory.SelectedIndex = 0;
                }
                else
                {
                    DropDownListCompanyCategory.SelectedValue = idCategory;
                }
            }
        }
        protected void buttonSave_Click(object sender, EventArgs e)
        {
            if (HiddenFieldId.Value == null || HiddenFieldId.Value == "")
            {
                Company company = new Company();
                company.Name = textboxName.Text;
                company.CategoryId = Int16.Parse(DropDownListCompanyCategory.SelectedValue);
                company.StockValues = Int16.Parse(textboxStockValue.Text);
                company.TotalStocks = Int16.Parse(textboxTotalStock.Text);
                Core.Controllers.DalalStreetAPIController.GetInstance().CreateCompany(company);
            }
            else
            {
                Company company = Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetCompany(Int16.Parse(HiddenFieldId.Value));
                company.Name = textboxName.Text;
                company.CategoryId = Int16.Parse(DropDownListCompanyCategory.SelectedValue);
                company.StockValues = Int16.Parse(textboxStockValue.Text);
                company.TotalStocks = Int16.Parse(textboxTotalStock.Text);
                Core.Controllers.DalalStreetAPIController.GetInstance().SaveCompany(company);
            }
            Session["objId"] = null;
            Response.Redirect("~/Pages/GameSettings.aspx");
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            Session["objId"] = null;
            Response.Redirect("~/Pages/GameSettings.aspx");
        }
    }
}