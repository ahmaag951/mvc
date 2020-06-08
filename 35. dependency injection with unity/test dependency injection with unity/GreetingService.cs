using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_dependency_injection_with_unity
{
    public class GreetingService : IGreetingService
    {
        public string SayHello()
        {
            return "Hello from GreetingService";
        }
    }
}