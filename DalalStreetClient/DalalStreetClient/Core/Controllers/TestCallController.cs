using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DalalStreetClient.Core.Controllers
{
    public class TestCallController
    {
        private const string URL = "http://localhost:8080/greeting";
        private static string UrlParameters = "";

        private static TestCallController Controller;
        private HttpClient client;

        private TestCallController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static TestCallController GetInstance()
        {
            if (Controller == null)
            {
                Controller = new TestCallController();
            }
            return Controller;
        }

        public class Greeting
        {
            public string Id { get; set; }
            public string Content { get; set; }

        }

        public Greeting MakeCall()
        {
            Greeting greeting = null;
            // List data response.
            HttpResponseMessage response = client.GetAsync(UrlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                greeting =
                    response.Content.ReadAsAsync<Greeting>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                Console.WriteLine("{0} - {1}", greeting.Id, greeting.Content);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            //Make any other calls using HttpClient here.
            return greeting;
            /*
             var dataObjects = response.Content.ReadAsAsync<IEnumerable<Greeting>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    g = d;
                    Console.WriteLine("{0} - {1}", d.Id, d.Content);
                }
             * */

        }

        public void DisposeClient()
        {
            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
    }
}