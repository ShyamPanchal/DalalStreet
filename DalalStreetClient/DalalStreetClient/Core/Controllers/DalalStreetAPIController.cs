using DalalStreetClient.Core.Models;
using DalalStreetClient.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static DalalStreetClient.Core.Services.DalalStreetAPIService;

namespace DalalStreetClient.Core.Controllers
{
    public class DalalStreetAPIController
    {
        private static DalalStreetAPIController Controller;

        public static DalalStreetAPIController GetInstance()
        {
            if (Controller == null)
            {
                Controller = new DalalStreetAPIController();
            }
            return Controller;
        }

        public bool isGameRunning()
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/Application/getgamestart", "");
            bool result = service.isGameRunning();
            service.DisposeClient();
            return result;

        }

        public bool StartGame()
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/Application", "?gameStatus=true");
            bool result = service.StartGame();
            service.DisposeClient();
            return result;

        }

        public bool StopGame()
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/Application", "?gameStatus=false");
            bool result = service.StopGame();
            service.DisposeClient();
            return result;

        }

        public IEnumerable<SimpleString> GetCompanyName()
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewCompanyNames/allrecords");
            IEnumerable<SimpleString> result = service.GetCompanyNames();
            service.DisposeClient();
            return result;

        }

        public SimpleString GetCompanyName(long id)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewCompanyNames/" + id);
            SimpleString result = service.GetCompanyName();
            service.DisposeClient();
            return result;

        }
        public SimpleString CreateCompanyName(SimpleString name)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewCompanyNames");
            SimpleString result = service.CreateCompanyName(name);
            service.DisposeClient();
            return result;

        }
        public SimpleString SaveCompanyName(SimpleString name)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewCompanyNames/" + name.Id);
            SimpleString result = service.SaveCompanyName(name);
            service.DisposeClient();
            return result;

        }
        public bool DeleteCompanyName(long id)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewCompanyNames/" + id);
            bool result = service.Delete();
            service.DisposeClient();
            return result;

        }
        public IEnumerable<Company> GetCompanies()
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_Company/allrecords");
            IEnumerable<Company> result = service.GetCompanies();
            service.DisposeClient();
            return result;

        }

        public Company GetCompany(long id)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewCompany/" + id);
            Company result = service.GetCompany();
            service.DisposeClient();
            return result;

        }
        public Company CreateCompany(Company company)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewCompany");
            Company result = service.CreateCompany(company);
            service.DisposeClient();
            return result;

        }
        public Company SaveCompany(Company company)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewCompany/" + company.Id);
            Company result = service.SaveCompany(company);
            service.DisposeClient();
            return result;

        }
        public bool DeleteCompany(long id)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewCompany/" + id);
            bool result = service.Delete();
            service.DisposeClient();
            return result;

        }
        public IEnumerable<CompanyCategory> GetCompanyCategories()
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_CompanyCategory/allrecords");
            IEnumerable<CompanyCategory> result = service.GetCompanyCategories();
            service.DisposeClient();
            return result;

        }
        public CompanyCategory GetCompanyCategory(long id)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_CompanyCategory/" + id);
            CompanyCategory result = service.GetCompanyCategory();
            service.DisposeClient();
            return result;

        }
        public CompanyCategory CreateCompanyCategory(CompanyCategory category)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_CompanyCategory");
            CompanyCategory result = service.CreateCompanyCategory(category);
            service.DisposeClient();
            return result;

        }
        public CompanyCategory SaveCompanyCategory(CompanyCategory category)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_CompanyCategory/" + category.Id);
            CompanyCategory result = service.SaveCompanyCategory(category);
            service.DisposeClient();
            return result;

        }
        public bool DeleteCompanyCategory(long id)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewCompanyCategory/" + id);
            bool result = service.Delete();
            service.DisposeClient();
            return result;

        }
        public IEnumerable<EventType> GetEventTypes()
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_EventTypes/allrecords");
            IEnumerable<EventType> result = service.GetEventTypes();
            service.DisposeClient();
            return result;

        }
        public EventType GetEventType(long id)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_EventTypes/" + id);
            EventType result = service.GetEventType();
            service.DisposeClient();
            return result;

        }
        public EventType CreateEventType(EventType eventType)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewCompanyNames");
            EventType result = service.CreateEventType(eventType);
            service.DisposeClient();
            return result;

        }
        public EventType SaveEventType(EventType eventType)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewCompanyNames/" + eventType.Id);
            EventType result = service.SaveEventType(eventType);
            service.DisposeClient();
            return result;

        }
        public bool DeleteEventType(long id)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_EventTypes/" + id);
            bool result = service.Delete();
            service.DisposeClient();
            return result;

        }
        public IEnumerable<Event> GetEvents()
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewsEvent/allrecords");
            IEnumerable<Event> result = service.GetEvents();
            service.DisposeClient();
            return result;

        }
        public Event GetEvent(long id)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewsEvent/" + id);
            Event result = service.GetEvent();
            service.DisposeClient();
            return result;

        }
        public Event CreateEvent(Event _event)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewsEvent");
            Event result = service.CreateEvent(_event);
            service.DisposeClient();
            return result;

        }
        public Event SaveEvent(Event _event)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewsEvent/" + _event.Id);
            Event result = service.SaveEvent(_event);
            service.DisposeClient();
            return result;

        }
        public bool DeleteEvent(long id)
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewsEvent/" + id);
            bool result = service.Delete();
            service.DisposeClient();
            return result;

        }
    }
}