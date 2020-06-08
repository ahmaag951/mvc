using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Structure_Map.Controllers
{
    public class HomeController : Controller
    {
        GreetingService greetingService = new GreetingService();

        public string Index()
        {
            return greetingService.SayHello();
        }

    }
}
