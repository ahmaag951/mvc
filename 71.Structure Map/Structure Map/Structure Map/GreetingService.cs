using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Structure_Map
{
    public class GreetingService : IGreetingService
    {
        public string SayHello()
        {
            return "Hello from GreetingService";
        }
    }
}