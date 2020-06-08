using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;

namespace Structure_Map.Controllers
{
    public class HomeController : Controller
    {
        private IGreetingService greetingService;
        public HomeController()
        {
            var container = new Container();
            container.Configure(x => x.For<IGreetingService>().Use<GreetingService>());
            greetingService = container.GetInstance<GreetingService>(); ;
        }

        public string Index()
        {
            // 1. from nuget Install-Package structuremap -Version 3.1.9.463
            // 2. here configuration for the structure map

            return greetingService.SayHello();
        }

    }
}
