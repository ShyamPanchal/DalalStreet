using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient.Pages.Settings
{
    public partial class ManageCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["objId"] == null)
                {

                }
                else
                {
                    CompanyCategory category = Core.Controllers.DalalStreetAPIController.GetInstance().GetCompanyCategory(Int16.Parse(Session["objId"].ToString()));
                    textboxName.Text = category.Name;
                    HiddenFieldId.Value = category.Id.ToString();
                }
            }
        }
        protected void buttonSave_Click(object sender, EventArgs e)
        {
            if (HiddenFieldId.Value == null || HiddenFieldId.Value == "")
            {
                CompanyCategory category = new CompanyCategory();
                category.Name = textboxName.Text;
                Core.Controllers.DalalStreetAPIController.GetInstance().CreateCompanyCategory(category);
            }
            else
            {
                CompanyCategory name = Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetCompanyCategory(Int16.Parse(HiddenFieldId.Value));
                name.Name = textboxName.Text;
                Core.Controllers.DalalStreetAPIController.GetInstance().SaveCompanyCategory(name);
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