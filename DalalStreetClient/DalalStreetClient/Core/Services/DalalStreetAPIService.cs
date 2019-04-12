using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DalalStreetClient.Core.Services
{
    public class DalalStreetAPIService
    {
        public static string URL = "https://localhost:44364/api";
        private string UrlParameters = "";
        
        private HttpClient client;

        public DalalStreetAPIService(string url) : this(url, "")
        {
        }

        public DalalStreetAPIService(string url, string UrlParameters)
        {
            client = new HttpClient();
            this.UrlParameters = UrlParameters;
            client.BaseAddress = new Uri(URL + url);
            //application/json-patch+json
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public class GameRunning
        {
            public bool Running { get; set; }

        }

        public bool Delete()
        {
            string result = "";

            HttpResponseMessage response = client.DeleteAsync(UrlParameters).Result;
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
        public IEnumerable<SimpleString> GetCompanyNames()
        {
            IEnumerable<SimpleString> companyNames = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                companyNames =
                    response.Content.ReadAsAsync<IEnumerable<SimpleString>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return companyNames;
        }
        public SimpleString GetCompanyName()
        {
            SimpleString companyName = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
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
        public SimpleString CreateCompanyName(SimpleString name)
        {
            SimpleString companyName = null;

            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.PostAsJsonAsync(UrlParameters, name).Result;
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
        public SimpleString SaveCompanyName(SimpleString name)
        {
            SimpleString companyName = null;

            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.PutAsJsonAsync(UrlParameters, name).Result;
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
        public IEnumerable<Company> GetCompanies()
        {
            IEnumerable<Company> companies = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                companies =
                    response.Content.ReadAsAsync<IEnumerable<Company>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return companies;
        }
        public Company GetCompany()
        {
            Company company = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                company =
                    response.Content.ReadAsAsync<Company>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return company;
        }
        public Company CreateCompany(Company company)
        {
            Company companyResp = null;

            HttpResponseMessage response = client.PostAsJsonAsync(UrlParameters, company).Result;
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
        public Company SaveCompany(Company company)
        {
            Company companyResp = null;

            HttpResponseMessage response = client.PutAsJsonAsync(UrlParameters, company).Result;
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

        public IEnumerable<CompanyCategory> GetCompanyCategories()
        {
            IEnumerable<CompanyCategory> categories = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                categories =
                    response.Content.ReadAsAsync<IEnumerable<CompanyCategory>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return categories;
        }

        public CompanyCategory GetCompanyCategory()
        {
            CompanyCategory category = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                category =
                    response.Content.ReadAsAsync<CompanyCategory>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return category;
        }
        public CompanyCategory CreateCompanyCategory(CompanyCategory companyCategory)
        {
            CompanyCategory categoryResp = null;

            HttpResponseMessage response = client.PostAsJsonAsync(UrlParameters, companyCategory).Result;
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
        public CompanyCategory SaveCompanyCategory(CompanyCategory companyCategory)
        {
            CompanyCategory categoryResp = null;

            HttpResponseMessage response = client.PutAsJsonAsync(UrlParameters, companyCategory).Result;
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

        public IEnumerable<EventType> GetEventTypes()
        {
            IEnumerable<EventType> eventTypes = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                eventTypes =
                    response.Content.ReadAsAsync<IEnumerable<EventType>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return eventTypes;
        }

        public EventType GetEventType()
        {
            EventType eventType = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
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
        public EventType CreateEventType(EventType type)
        {
            EventType eventType = null;

            HttpResponseMessage response = client.PostAsJsonAsync(UrlParameters, type).Result;
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
        public EventType SaveEventType(EventType type)
        {
            EventType eventType = null;

            HttpResponseMessage response = client.PutAsJsonAsync(UrlParameters, type).Result;
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
        public IEnumerable<Event> GetEvents()
        {
            IEnumerable<Event> events = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                events =
                    response.Content.ReadAsAsync<IEnumerable<Event>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return events;
        }

        public Event GetEvent()
        {
            Event _event = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
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
        public Event CreateEvent(Event newEvent)
        {
            Event _event = null;

            HttpResponseMessage response = client.PostAsJsonAsync(UrlParameters, newEvent).Result;
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
        public Event SaveEvent(Event newEvent)
        {
            Event _event = null;

            HttpResponseMessage response = client.PutAsJsonAsync(UrlParameters, newEvent).Result;
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

        public Player AddPlayer(string name)
        {
            Player user = null;
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.PostAsJsonAsync(UrlParameters, name).Result;
            if (response.IsSuccessStatusCode)
            {
                user =
                    response.Content.ReadAsAsync<Player>().Result;
                Console.WriteLine("{0}", user);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return user;
        }

        public Player GetPlayer()
        {
            Player player = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                player =
                    response.Content.ReadAsAsync<Player>().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return player;
        }

        public Inventory GetPlayerInventory()
        {
            IEnumerable <Inventory> inventory = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                inventory =
                    response.Content.ReadAsAsync<IEnumerable<Inventory>>().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            Inventory i = new Inventory();
            try
            {
                foreach(Inventory inv in inventory)
                {
                    i = inv;
                }
            } catch (Exception e)
            {
                return i;
            }
            return i;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            IEnumerable <Player> player = null;

            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                player =
                    response.Content.ReadAsAsync<IEnumerable<Player>>().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return player;
        }

        public bool BuyOrSell(int playerId, int companyId, int stocks)
        {
            Transaction transaction = new Transaction(playerId, companyId, stocks);
                
            bool resp = false;
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.PostAsJsonAsync(UrlParameters, transaction).Result;
            if (response.IsSuccessStatusCode)
            {
                resp =
                    response.Content.ReadAsAsync<bool>().Result;
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
        public bool isGameRunning()
        {
            Boolean running = false;
            // List data response.
            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                running =
                    response.Content.ReadAsAsync<Boolean> ().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                Console.WriteLine("{0}", running);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            //Make any other calls using HttpClient here.
            return running;           
        }

        public bool StartGame()
        {
            Boolean running = false;
            // List data response.
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
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

        public bool StopGame()
        {
            Boolean running = false;
            // List data response.
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
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

        public void ResetGame()
        {
            string running = "";
            // List data response.
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
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
            //Make any other calls using HttpClient here.
        }

        #endregion
        public void DisposeClient()
        {
            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
    }
}