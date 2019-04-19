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
    public partial class ManageType : System.Web.UI.Page
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
                    EventType type = await Core.Controllers.DalalStreetAPIController.GetInstance().GetEventType(Int16.Parse(Session["objId"].ToString()));
                    textboxTypeString.Text = type.TypeString;
                    textboxLikelyhood.Text = "" + type.Likelihood;
                    textboxEffectOnOthers.Text = "" + type.EffectOnOthers;
                    textboxEffectOnSelf.Text = "" + type.EffectOnSelf;
                    HiddenFieldId.Value = "" + type.Id;
                }
            }
        }
        protected async void buttonSave_Click(object sender, EventArgs e)
        {
            if (verifyNumber(textboxLikelyhood.Text, 1, 0) && verifyNumber(textboxEffectOnOthers.Text, 1, -1) && verifyNumber(textboxEffectOnSelf.Text, 1, -1))
            {
                if (HiddenFieldId.Value == null || HiddenFieldId.Value == "")
                {
                    EventType type = new EventType();
                    type.TypeString = textboxTypeString.Text;

                    type.Likelihood = Decimal.Parse(textboxLikelyhood.Text);
                    type.EffectOnOthers = Decimal.Parse(textboxEffectOnOthers.Text);
                    type.EffectOnSelf = Decimal.Parse(textboxEffectOnSelf.Text);

                    Core.Controllers.DalalStreetAPIController.GetInstance().CreateEventType(type);
                }
                else
                {
                    EventType type = await Core.Controllers.DalalStreetAPIController.GetInstance()
                        .GetEventType(Int16.Parse(HiddenFieldId.Value));
                    type.TypeString = textboxTypeString.Text;
                    type.Likelihood = Decimal.Parse(textboxLikelyhood.Text);
                    type.EffectOnOthers = Decimal.Parse(textboxEffectOnOthers.Text);
                    type.EffectOnSelf = Decimal.Parse(textboxEffectOnSelf.Text);
                    Core.Controllers.DalalStreetAPIController.GetInstance().SaveEventType(type);
                }
                Session["objId"] = null;
                Response.Redirect("~/Pages/GameSettings.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            Session["objId"] = null;
            Response.Redirect("~/Pages/GameSettings.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void validateLikehood(object source, ServerValidateEventArgs args)
        {
            string number = textboxLikelyhood.Text;
            if (!verifyNumber(number, 1, 0))
            {
                args.IsValid = false;
            }
        }

        protected void validateEffectOnSelf(object source, ServerValidateEventArgs args)
        {
            string number = textboxEffectOnSelf.Text;
            if (!verifyNumber(number, 1, -1))
            {
                args.IsValid = false;
            }
        }

        protected void validateEffectOnOthers(object source, ServerValidateEventArgs args)
        {
            string number = textboxEffectOnOthers.Text;
            if (!verifyNumber(number, 1, -1))
            {
                args.IsValid = false;
            }
        }

        public bool verifyNumber(string number, int max = 100000000, int min = 0)
        {
            try
            {
                Decimal value = Decimal.Parse(number);
                if (value > max || value < min)
                {
                    return false;
                }
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    
    }
}