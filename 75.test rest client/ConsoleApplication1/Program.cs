using RestClientDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            var countryCodeClient = new RestClientDotNet.RestClient(new NewtonsoftSerializationAdapter(), new Uri("http://localhost:5675/api/values?id=5"));
            var countryData = countryCodeClient.GetAsync<string>();

            Console.Read();
        }
    }
}
