using DalalStreetClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DalalStreetClient.Core.Services
{
    public class DalalStreetAPIService
    {
        private const string URL = "https://localhost:44364/api";
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
        public IEnumerable<Company> GetCompany()
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
        public IEnumerable<CompanyCategory> GetCompanyCategory()
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
        public IEnumerable<EventType> GetEventType()
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
        public IEnumerable<Event> GetEvent()
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

        public bool isGameRunning()
        {
            GameRunning running = null;
            // List data response.
            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                running =
                    response.Content.ReadAsAsync<GameRunning>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                Console.WriteLine("{0}", running.Running);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            //Make any other calls using HttpClient here.
            return running.Running;           
        }

        public bool StartGame()
        {
            GameRunning par = new GameRunning();
            par.Running = true;
            Boolean running = false;
            // List data response.
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.PostAsJsonAsync(UrlParameters, true).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
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
            GameRunning par = new GameRunning();
            par.Running = false;
            Boolean running = false;
            // List data response.
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            HttpResponseMessage response = client.PostAsJsonAsync(UrlParameters, false).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
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

        public void DisposeClient()
        {
            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
    }
}