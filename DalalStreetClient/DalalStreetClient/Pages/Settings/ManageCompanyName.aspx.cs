using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient.Pages.Settings
{
    public partial class ManageCompanyName : System.Web.UI.Page
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
                    SimpleString name =  Core.Controllers.DalalStreetAPIController.GetInstance().GetCompanyName(Int16.Parse(Session["objId"].ToString()));
                    textboxName.Text = name.Name;
                    HiddenFieldId.Value = name.Id.ToString();
                }
            }
        }
        protected void buttonSave_Click(object sender, EventArgs e)
        {
            if (HiddenFieldId.Value == null || HiddenFieldId.Value == "")
            {
                SimpleString name = new SimpleString();
                name.Name = textboxName.Text;
                Core.Controllers.DalalStreetAPIController.GetInstance().CreateCompanyName(name);
            } else
            {
                SimpleString name = Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetCompanyName(Int16.Parse(HiddenFieldId.Value));                
                name.Name = textboxName.Text;
                Core.Controllers.DalalStreetAPIController.GetInstance().SaveCompanyName(name);
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