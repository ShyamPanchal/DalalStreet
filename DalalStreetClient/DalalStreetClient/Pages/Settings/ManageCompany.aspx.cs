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
                    textboxStockValue.Text = company.StockValues.ToString();
                    textboxTotalStock.Text = company.TotalStocks.ToString();
                }
                IEnumerable<CompanyCategory> dataSource = Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetCompanyCategories(); ;

                int i = -1;
                int position;
                dataSource.ToList().ForEach(category => {
                    DropDownListCompanyCategory.Items.Add(new ListItem(category.Name, category.Id.ToString()));
                    if (category.Id.ToString() == idCategory)
                    {
                        position = i;
                    }
                    i++;
                });

                if (i == -1)
                {
                    DropDownListCompanyCategory.SelectedIndex = 0;
                } else
                {
                    DropDownListCompanyCategory.SelectedIndex = i;
                }
            }
        }
        protected void buttonSave_Click(object sender, EventArgs e)
        {
            if (verifyNumber(textboxStockValue.Text) && verifyNumber(textboxTotalStock.Text))
            {

                if (HiddenFieldId.Value == null || HiddenFieldId.Value == "")
                {
                    Company company = new Company();
                    company.Name = textboxName.Text;
                    company.CategoryId = Int16.Parse(DropDownListCompanyCategory.SelectedValue);
                    company.StockValues = Int32.Parse(textboxStockValue.Text);
                    company.TotalStocks = Int32.Parse(textboxTotalStock.Text);
                    Core.Controllers.DalalStreetAPIController.GetInstance().CreateCompany(company);
                }
                else
                {
                    Company company = Core.Controllers.DalalStreetAPIController.GetInstance()
                        .GetCompany(Int16.Parse(HiddenFieldId.Value));
                    company.Name = textboxName.Text;
                    company.CategoryId = Int16.Parse(DropDownListCompanyCategory.SelectedValue);
                    company.StockValues = Int32.Parse(textboxStockValue.Text);
                    company.TotalStocks = Int32.Parse(textboxTotalStock.Text);
                    Core.Controllers.DalalStreetAPIController.GetInstance().SaveCompany(company);
                }
                Session["objId"] = null;
                Response.Redirect("~/Pages/GameSettings.aspx");
            }
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            Session["objId"] = null;
            Response.Redirect("~/Pages/GameSettings.aspx");
        }

        protected void validateTotalStock(object source, ServerValidateEventArgs args)
        {
            string number = textboxTotalStock.Text;
            if (!verifyNumber(number))
            {
                args.IsValid = false;
            }
        }

        protected void validateStockValue(object source, ServerValidateEventArgs args)
        {
            string number = textboxStockValue.Text;
            if (!verifyNumber(number))
            {
                args.IsValid = false;
            }
        }

        public bool verifyNumber(string number, int max = 100000000, int min = 0)
        {
            try
            {
                int value = Int32.Parse(number);
                if (value > max || value < min)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}