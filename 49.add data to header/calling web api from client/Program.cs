using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace calling_web_api_from_client
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             This url is very very important
             * https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
             */
            // 1. Install-Package Microsoft.AspNet.WebApi.Client
            RunAsync().Wait();


        }

        static async Task RunAsync()
        {
            var client = new HttpClient();
            // The web api project is deployed on localhost on this port
            // Run the web api project first
            // Then run the calling web api from client project 
            client.BaseAddress = new Uri("http://localhost:6472/");
            // This code sets the base URI for HTTP requests, and sets the Accept header to "application/json", 
            // which tells the server to send data in JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("MyCustomData", "MyCustomValue");

            HttpResponseMessage response = await client.GetAsync("api/values/get?id=4");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<string>();
                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
