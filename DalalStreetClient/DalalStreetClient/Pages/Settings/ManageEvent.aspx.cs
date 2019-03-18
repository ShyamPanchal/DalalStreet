using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DalalStreetClient.Pages.Settings
{
    public partial class ManageEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idCompany = null;
                string idEventType = null;
                if (Session["objId"] == null)
                {

                }
                else
                {
                    Event _event = Core.Controllers.DalalStreetAPIController.GetInstance()
                        .GetEvent(Int16.Parse(Session["objId"].ToString()));
                    HiddenFieldId.Value = _event.Id.ToString();
                    idEventType = _event.EventTypeId.ToString();
                    idCompany = _event.OnCompanyId.ToString();

                }
                IEnumerable<Company> dataSource = Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetCompanies(); ;
                DropDownListCompany.DataSource = dataSource;

                if (idCompany == null)
                {
                    DropDownListCompany.SelectedIndex = 0;
                } else
                {
                    DropDownListCompany.SelectedValue = idCompany;
                }
                IEnumerable<EventType> dataSource2 = Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetEventTypes(); ;
                DropDownListEventType.DataSource = dataSource;

                if (idEventType == null)
                {
                    DropDownListEventType.SelectedIndex = 0;
                } else
                    DropDownListEventType.SelectedValue = idEventType;
                {
                }
            }
        }
        protected void buttonSave_Click(object sender, EventArgs e)
        {
            if (HiddenFieldId.Value == null || HiddenFieldId.Value == "")
            {
                Event _event = new Event();
                _event.OnCompanyId = Int16.Parse(DropDownListCompany.SelectedValue);
                _event.EventTypeId = Int16.Parse(DropDownListEventType.SelectedValue);

                Core.Controllers.DalalStreetAPIController.GetInstance().CreateEvent(_event);
            }
            else
            {
                Event _event = Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetEvent(Int16.Parse(HiddenFieldId.Value));

                _event.OnCompanyId = Int16.Parse(DropDownListCompany.SelectedValue);
                _event.EventTypeId = Int16.Parse(DropDownListEventType.SelectedValue);

                Core.Controllers.DalalStreetAPIController.GetInstance().SaveEvent(_event);
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