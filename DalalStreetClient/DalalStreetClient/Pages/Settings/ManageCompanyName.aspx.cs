using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient.Pages.Settings
{
    public partial class ManageCompanyName : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["objId"] == null)
                {

                }
                else
                {
                    SimpleString name =  await Core.Controllers.DalalStreetAPIController.GetInstance().GetCompanyName(Int16.Parse(Session["objId"].ToString()));
                    textboxName.Text = name.Name;
                    HiddenFieldId.Value = name.Id.ToString();
                }
            }
        }
        protected async void buttonSave_Click(object sender, EventArgs e)
        {
            if (HiddenFieldId.Value == null || HiddenFieldId.Value == "")
            {
                SimpleString name = new SimpleString();
                name.Name = textboxName.Text;
                Core.Controllers.DalalStreetAPIController.GetInstance().CreateCompanyName(name);
            } else
            {
                SimpleString name = await Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetCompanyName(Int16.Parse(HiddenFieldId.Value));                
                name.Name = textboxName.Text;
                Core.Controllers.DalalStreetAPIController.GetInstance().SaveCompanyName(name);
            }
            Session["objId"] = null;
            Response.Redirect("~/Pages/GameSettings.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            Session["objId"] = null;
            Response.Redirect("~/Pages/GameSettings.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

    }
}