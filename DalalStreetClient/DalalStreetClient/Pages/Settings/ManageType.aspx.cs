using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient.Pages.Settings
{
    public partial class ManageType : System.Web.UI.Page
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
                    EventType type = Core.Controllers.DalalStreetAPIController.GetInstance().GetEventType(Int16.Parse(Session["objId"].ToString()));
                    textboxTypeString.Text = type.TypeString;
                    textboxLikelyhood.Text = "" + type.Likelihood;
                    textboxEffectOnOthers.Text = "" + type.EffectOnOthers;
                    textboxEffectOnSelf.Text = "" + type.EffectOnSelf;
                }
            }
        }
        protected void buttonSave_Click(object sender, EventArgs e)
        {
            if (HiddenFieldId.Value == null || HiddenFieldId.Value == "")
            {
                EventType type = new EventType();
                type.TypeString = textboxTypeString.Text;

                type.Likelihood = Int16.Parse(textboxLikelyhood.Text);
                type.EffectOnOthers = Decimal.Parse(textboxEffectOnOthers.Text);
                type.EffectOnSelf = Decimal.Parse(textboxEffectOnSelf.Text);

                Core.Controllers.DalalStreetAPIController.GetInstance().CreateEventType(type);
            }
            else
            {
                EventType type = Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetEventType(Int16.Parse(HiddenFieldId.Value));
                type.TypeString = textboxTypeString.Text;
                type.Likelihood = Int16.Parse(textboxLikelyhood.Text);
                type.EffectOnOthers = Decimal.Parse(textboxEffectOnOthers.Text);
                type.EffectOnSelf = Decimal.Parse(textboxEffectOnSelf.Text);
                Core.Controllers.DalalStreetAPIController.GetInstance().SaveEventType(type);
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