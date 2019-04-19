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
    public partial class ManageEvent : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
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
                    Event _event = await Core.Controllers.DalalStreetAPIController.GetInstance()
                        .GetEvent(Int16.Parse(Session["objId"].ToString()));
                    HiddenFieldId.Value = _event.Id.ToString();
                    idEventType = _event.EventTypeId.ToString();
                    idCompany = _event.OnCompanyId.ToString();

                }
                IEnumerable<Company> dataSource = await Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetCompanies(); ;

                int i = -1;
                int position = -1;
                dataSource.ToList().ForEach(company => {
                    DropDownListCompany.Items.Add(new ListItem(company.Name, company.Id.ToString()));
                    if (company.Id.ToString() == idCompany)
                    {
                        position = i;
                    }
                    i++;
                });

                if (position == -1)
                {
                    DropDownListCompany.SelectedIndex = 0;
                }
                else
                {
                    DropDownListCompany.SelectedIndex = position;
                }

                IEnumerable<EventType> dataSource2 = await Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetEventTypes(); ;

                i = -1;
                position = -1;
                dataSource2.ToList().ForEach(eventType => {
                    DropDownListEventType.Items.Add(new ListItem(eventType.TypeString, eventType.Id.ToString()));
                    if (eventType.Id.ToString() == idEventType)
                    {
                        position = i;
                    }
                    i++;
                });

                if (position == -1)
                {
                    DropDownListEventType.SelectedIndex = 0;
                }
                else
                {
                    DropDownListEventType.SelectedIndex = position;
                }

            }
        }
        protected async void buttonSave_Click(object sender, EventArgs e)
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
                Event _event = await Core.Controllers.DalalStreetAPIController.GetInstance()
                    .GetEvent(Int16.Parse(HiddenFieldId.Value));

                _event.OnCompanyId = Int16.Parse(DropDownListCompany.SelectedValue);
                _event.EventTypeId = Int16.Parse(DropDownListEventType.SelectedValue);

                Core.Controllers.DalalStreetAPIController.GetInstance().SaveEvent(_event);
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