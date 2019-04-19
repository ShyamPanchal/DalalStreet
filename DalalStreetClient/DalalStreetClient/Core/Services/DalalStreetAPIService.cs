using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace DalalStreetClient.Core.Services
{
    public class DalalStreetAPIService
    {
        public static string URL = "https://dalalstreetapi20190415093152.azurewebsites.net/api";

        public HttpClient client;

        private static DalalStreetAPIService Service;                

        public static DalalStreetAPIService GetInstance()
        {
            if (Service == null)
            {
                Service = new DalalStreetAPIService();
                Service.client = new HttpClient();
                Service.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            /*
                //this.new Uri(URL + url) = new Uri(URL + url);
                client.BaseAddress = new Uri(URL + url);
                client.DefaultRequestHeaders.Accept.Clear();
             */
            }
            return Service;
        }

        public class GameRunning
        {
            public bool Running { get; set; }

        }

        public bool Delete(string url)
        {
            string result = "";

            HttpResponseMessage response = client.DeleteAsync(new Uri(URL + url)).Result;

            
            if (response.IsSuccessStatusCode)
            {
                result =
                    response.Content.ReadAsAsync<string>().Result;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return false;
            }
            return true;
        }

        #region Admin
        public async Task<IEnumerable<SimpleString>> GetCompanyNames(string url)
        {
            IEnumerable<SimpleString> companyNames = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            
            if (response.IsSuccessStatusCode)
            {
                companyNames =
                    await response.Content.ReadAsAsync<IEnumerable<SimpleString>>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return companyNames;
        }
        public async Task<SimpleString> GetCompanyName(string url)
        {

            SimpleString companyName = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            
            if (response.IsSuccessStatusCode)
            {
                companyName =
                    await response.Content.ReadAsAsync<SimpleString>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return companyName;
        }
        public SimpleString CreateCompanyName(SimpleString name, string url)
        {
            SimpleString companyName = null;

            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.PostAsJsonAsync(new Uri(URL + url), name).Result;
            
            if (response.IsSuccessStatusCode)
            {
                companyName =
                    response.Content.ReadAsAsync<SimpleString>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return companyName;
        }
        public SimpleString SaveCompanyName(SimpleString name, string url)
        {

            SimpleString companyName = null;

            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.PutAsJsonAsync(new Uri(URL + url), name).Result;
            
            if (response.IsSuccessStatusCode)
            {
                companyName =
                    response.Content.ReadAsAsync<SimpleString>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return companyName;
        }
        public async Task<IEnumerable<Company>> GetCompanies(string url)
        {

            IEnumerable<Company> companies = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            
            if (response.IsSuccessStatusCode)
            {
                companies =
                    await response.Content.ReadAsAsync<IEnumerable<Company>>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return companies;
        }
        public async Task<Company> GetCompany(string url)
        {

            Company company = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            
            if (response.IsSuccessStatusCode)
            {
                company =
                    await response.Content.ReadAsAsync<Company>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return company;
        }
        public Company CreateCompany(Company company, string url)
        {

            Company companyResp = null;

            HttpResponseMessage response = client.PostAsJsonAsync(new Uri(URL + url), company).Result;
            
            if (response.IsSuccessStatusCode)
            {
                companyResp =
                    response.Content.ReadAsAsync<Company>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return companyResp;
        }
        public Company SaveCompany(Company company, string url)
        {            

            Company companyResp = null;

            HttpResponseMessage response = client.PutAsJsonAsync(new Uri(URL + url), company).Result;
            
            if (response.IsSuccessStatusCode)
            {
                companyResp =
                    response.Content.ReadAsAsync<Company>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return companyResp;
        }

        public async Task<IEnumerable<CompanyCategory>> GetCompanyCategories(string url)
        {

            IEnumerable<CompanyCategory> categories = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            
            if (response.IsSuccessStatusCode)
            {
                categories =
                    await response.Content.ReadAsAsync<IEnumerable<CompanyCategory>>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return categories;
        }

        public async Task<CompanyCategory> GetCompanyCategory(string url)
        {

            CompanyCategory category = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            
            if (response.IsSuccessStatusCode)
            {
                category =
                    await response.Content.ReadAsAsync<CompanyCategory>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return category;
        }
        public CompanyCategory CreateCompanyCategory(CompanyCategory companyCategory, string url)
        {

            CompanyCategory categoryResp = null;

            HttpResponseMessage response = client.PostAsJsonAsync(new Uri(URL + url), companyCategory).Result;
            
            if (response.IsSuccessStatusCode)
            {
                categoryResp =
                    response.Content.ReadAsAsync<CompanyCategory>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return categoryResp;
        }
        public CompanyCategory SaveCompanyCategory(CompanyCategory companyCategory, string url)
        {

            CompanyCategory categoryResp = null;

            HttpResponseMessage response = client.PutAsJsonAsync(new Uri(URL + url), companyCategory).Result;
            
            if (response.IsSuccessStatusCode)
            {
                categoryResp =
                    response.Content.ReadAsAsync<CompanyCategory>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return categoryResp;
        }

        public async Task<IEnumerable<EventType>> GetEventTypes(string url)
        {

            IEnumerable<EventType> eventTypes = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            
            if (response.IsSuccessStatusCode)
            {
                eventTypes =
                    await response.Content.ReadAsAsync<IEnumerable<EventType>>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return eventTypes;
        }

        public async Task<EventType> GetEventType(string url)
        {

            EventType eventType = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            
            if (response.IsSuccessStatusCode)
            {
                eventType =
                    await response.Content.ReadAsAsync<EventType>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return eventType;
        }
        public EventType CreateEventType(EventType type, string url)
        {

            EventType eventType = null;

            HttpResponseMessage response = client.PostAsJsonAsync(new Uri(URL + url), type).Result;
            
            if (response.IsSuccessStatusCode)
            {
                eventType =
                    response.Content.ReadAsAsync<EventType>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return eventType;
        }
        public EventType SaveEventType(EventType type, string url)
        {;

            EventType eventType = null;

            HttpResponseMessage response = client.PutAsJsonAsync(new Uri(URL + url), type).Result;
            
            if (response.IsSuccessStatusCode)
            {
                eventType =
                    response.Content.ReadAsAsync<EventType>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return eventType;
        }
        public async Task<IEnumerable<Event>> GetEvents(string url)
        {

            IEnumerable<Event> events = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            
            if (response.IsSuccessStatusCode)
            {
                events =
                    await response.Content.ReadAsAsync<IEnumerable<Event>>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return events;
        }

        public async Task<Event> GetEvent(string url)
        {

            Event _event = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            
            if (response.IsSuccessStatusCode)
            {
                _event =
                    await response.Content.ReadAsAsync<Event>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return _event;
        }
        public Event CreateEvent(Event newEvent, string url)
        {

            Event _event = null;

            HttpResponseMessage response = client.PostAsJsonAsync(new Uri(URL + url), newEvent).Result;
            
            if (response.IsSuccessStatusCode)
            {
                _event =
                    response.Content.ReadAsAsync<Event>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return _event;
        }
        public Event SaveEvent(Event newEvent, string url)
        {

            Event _event = null;

            HttpResponseMessage response = client.PutAsJsonAsync(new Uri(URL + url), newEvent).Result;
            
            if (response.IsSuccessStatusCode)
            {
                _event =
                    response.Content.ReadAsAsync<Event>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return _event;
        }
        #endregion

        #region Player

        public async Task<Player> AddPlayer(string name, string url)
        {

            Player user = null;
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = await client.PostAsJsonAsync(new Uri(URL + url), name);
            if (response.IsSuccessStatusCode)
            {
                user =
                    await response.Content.ReadAsAsync<Player>();
                Console.WriteLine("{0}", user);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return user;
        }

        public async Task<Player> GetPlayer(string url)
        {

            Player player = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            if (response.IsSuccessStatusCode)
            {
                player = await response.Content.ReadAsAsync<Player>();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return player;
        }

        public async Task<Inventory> GetPlayerInventory(string url)
        {

            Inventory inventory = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            if (response.IsSuccessStatusCode)
            {
                inventory =
                    await response.Content.ReadAsAsync<Inventory>();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return inventory;
        }

        public async Task<IEnumerable<Player>> GetAllPlayers(string url)
        {

            IEnumerable<Player> player = null;

            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));
            if (response.IsSuccessStatusCode)
            {
                player =
                    await response.Content.ReadAsAsync<IEnumerable<Player>>();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return player;
        }

        public async Task<bool> BuyOrSell(int playerId, int companyId, int stocks, string url)
        {

            Transaction transaction = new Transaction(playerId, companyId, stocks);

            bool resp = false;
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = await client.PostAsJsonAsync(new Uri(URL + url), transaction);
            if (response.IsSuccessStatusCode)
            {
                resp =
                    await response.Content.ReadAsAsync<bool>();
                Console.WriteLine("{0}", resp);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return resp;
        }
        #endregion


        #region Game
        public async Task<bool> isGameRunning(string url)
        {

            Boolean running = false;
            // List data response.
            HttpResponseMessage response = await client.GetAsync(new Uri(URL + url));  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                running =
                    await response.Content.ReadAsAsync<Boolean>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
                Console.WriteLine("{0}", running);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            //Make any other calls using HttpClient here.
            return running;
        }

        public bool StartGame(string url)
        {

            Boolean running = false;
            // List data response.
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.GetAsync(new Uri(URL + url)).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                running =
                    response.Content.ReadAsAsync<Boolean>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                Console.WriteLine("{0}", running);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            //Make any other calls using HttpClient here.
            return running;
        }

        public bool StopGame(string url)
        {

            Boolean running = false;
            // List data response.
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.GetAsync(new Uri(URL + url)).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                running =
                    response.Content.ReadAsAsync<Boolean>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                Console.WriteLine("{0}", running);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            //Make any other calls using HttpClient here.
            return running;
        }

        public void ResetGame(string url)
        {

            string running = "";
            // List data response.
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.GetAsync(new Uri(URL + url)).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                running =
                    response.Content.ReadAsAsync<string>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                Console.WriteLine("{0}", running);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            //return Task.CompletedTask;
            //Make any other calls using HttpClient here.
        }

        #endregion
        public void DisposeClient()
        {

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            //client.Dispose();
        }
    }
}