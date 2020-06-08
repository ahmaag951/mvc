using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Structure_Map
{
    public class GreetingService2 : IGreetingService
    {
        public string SayHello()
        {
            return "Hello GreetingService2";
        }
    }
}