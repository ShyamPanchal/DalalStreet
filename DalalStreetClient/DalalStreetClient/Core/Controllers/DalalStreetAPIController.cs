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
        public IEnumerable<Company> GetCompany()
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_Company/allrecords");
            IEnumerable<Company> result = service.GetCompany();
            service.DisposeClient();
            return result;

        }
        public IEnumerable<CompanyCategory> GetCompanyCategory()
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_CompanyCategory/allrecords");
            IEnumerable<CompanyCategory> result = service.GetCompanyCategory();
            service.DisposeClient();
            return result;

        }
        public IEnumerable<EventType> GetEventType()
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_EventTypes/allrecords");
            IEnumerable<EventType> result = service.GetEventType();
            service.DisposeClient();
            return result;

        }
        public IEnumerable<Event> GetEvent()
        {
            DalalStreetAPIService service = new DalalStreetAPIService("/DS_NewsEvent/allrecords");
            IEnumerable<Event> result = service.GetEvent();
            service.DisposeClient();
            return result;

        }
    }
}