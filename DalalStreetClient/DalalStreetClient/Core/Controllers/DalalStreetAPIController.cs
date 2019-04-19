using DalalStreetClient.Core.Models;
using DalalStreetClient.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<bool> isGameRunning()
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            bool result = await service.isGameRunning("/Application/getgamestart");
            
            return result;

        }

        #region GAME
        public bool StartGame()
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            bool result = service.StartGame("/Application/Start");
            
            return result;

        }

        public bool StopGame()
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            bool result = service.StopGame("/Application/Stop");
            
            return result;

        }
        public void resetGame()
        {
            StopGame();
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            service.ResetGame("/Application/Reset");
            //
        }
        #endregion
        #region ADMIN

        public async Task<IEnumerable<SimpleString>> GetCompanyName()
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            IEnumerable<SimpleString> result = await service.GetCompanyNames("/DS_NewCompanyNames/allrecords");
            //
            return result;

        }

        public async Task<SimpleString> GetCompanyName(long id)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            SimpleString result = await service.GetCompanyName("/DS_NewCompanyNames/" + id);
            
            return result;

        }
        public SimpleString CreateCompanyName(SimpleString name)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            SimpleString result = service.CreateCompanyName(name, "/DS_NewCompanyNames");
            
            return result;

        }
        public SimpleString SaveCompanyName(SimpleString name)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            SimpleString result = service.SaveCompanyName(name, "/DS_NewCompanyNames/" + name.Id);
            
            return result;

        }
        public bool DeleteCompanyName(long id)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            bool result = service.Delete("/DS_NewCompanyNames/" + id);
            
            return result;

        }
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            IEnumerable<Company> result = await service.GetCompanies("/DS_Company/allrecords");
            
            return result;

        }

        public async Task<Company> GetCompany(long id)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            Company result = await service.GetCompany("/DS_Company/" + id);
            
            return result;

        }
        public Company CreateCompany(Company company)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            Company result = service.CreateCompany(company, "/DS_Company");
            
            return result;

        }
        public Company SaveCompany(Company company)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            Company result = service.SaveCompany(company, "/DS_Company/" + company.Id);
            
            return result;

        }
        public bool DeleteCompany(long id)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            bool result = service.Delete("/DS_Company/" + id);
            
            return result;

        }
        public async Task<IEnumerable<CompanyCategory>> GetCompanyCategories()
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            IEnumerable<CompanyCategory> result = await service.GetCompanyCategories("/DS_CompanyCategory/allrecords");
            
            return result;

        }
        public async Task<CompanyCategory> GetCompanyCategory(long id)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            CompanyCategory result = await service.GetCompanyCategory("/DS_CompanyCategory/" + id);
            
            return result;

        }
        public CompanyCategory CreateCompanyCategory(CompanyCategory category)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            CompanyCategory result = service.CreateCompanyCategory(category, "/DS_CompanyCategory");
            
            return result;

        }
        public CompanyCategory SaveCompanyCategory(CompanyCategory category)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            CompanyCategory result = service.SaveCompanyCategory(category, "/DS_CompanyCategory/" + category.Id);
            
            return result;

        }
        public bool DeleteCompanyCategory(long id)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            bool result = service.Delete("/DS_CompanyCategory/" + id);
            
            return result;

        }
        public async Task<IEnumerable<EventType>> GetEventTypes()
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            IEnumerable<EventType> result = await service.GetEventTypes("/DS_EventTypes/allrecords");
            
            return result;

        }
        public async Task<EventType> GetEventType(long id)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            EventType result = await service.GetEventType("/DS_EventTypes/" + id);
            
            return result;

        }
        public EventType CreateEventType(EventType eventType)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            EventType result = service.CreateEventType(eventType, "/DS_EventTypes");
            
            return result;

        }
        public EventType SaveEventType(EventType eventType)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            EventType result = service.SaveEventType(eventType, "/DS_EventTypes/" + eventType.Id);
            
            return result;

        }
        public bool DeleteEventType(long id)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            bool result = service.Delete("/DS_EventTypes/" + id);
            
            return result;

        }
        public async Task<IEnumerable<Event>> GetEvents(int quantity)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            IEnumerable<Event> result = await service.GetEvents("/DS_NewsEvent/allrecords/" + quantity);
            
            return result;

        }
        public async Task<Event> GetEvent(long id)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            Event result = await service.GetEvent("/DS_NewsEvent/" + id);
            
            return result;

        }
        public Event CreateEvent(Event _event)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();

            Event result = service.CreateEvent(_event, "/DS_NewsEvent");
            
            return result;

        }
        public Event SaveEvent(Event _event)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            Event result = service.SaveEvent(_event, "/DS_NewsEvent/" + _event.Id);
            
            return result;

        }
        public bool DeleteEvent(long id)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            bool result = service.Delete("/DS_NewsEvent/" + id);
            
            return result;

        }
#endregion
        #region PLAYER
        public async Task<Player> AddPlayer(string name)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            Player result = await service.AddPlayer(name, "/DS_Player/addPlayer");
            
            return result;

        }
        public async Task<Player> GetPlayer(int id)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            Player result = await service.GetPlayer("/DS_Player/getPlayer/" + id);
            
            return result;

        }

        public async Task<Inventory> GetPlayerInventory(int id, int company)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            Inventory result = await service.GetPlayerInventory("/DS_Player/playerInventory/" + id + "/" + company);
            
            if (result == null)
            {
                result = new Inventory();
                result.companyId = company;
                result.playerId = id;
                result.ownedStocks = 0;
            }
            return result;

        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            IEnumerable<Player> result = await service.GetAllPlayers("/DS_Player/allPlayers");
            
            return result;

        }
        public async Task<bool> BuyStock(int  playerId, int companyId, int stocks)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            bool result = await service.BuyOrSell(playerId, companyId, stocks, "/DS_Player/buy");
            
            return result;

        }
        public async Task<bool> SellStock(int playerId, int companyId, int stocks)
        {
            DalalStreetAPIService service = DalalStreetAPIService.GetInstance();
            
            bool result = await service.BuyOrSell(playerId, companyId, stocks, "/DS_Player/sell");
            
            return result;

        }
        #endregion
    }
}