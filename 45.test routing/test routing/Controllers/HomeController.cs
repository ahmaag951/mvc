using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test_routing.Controllers
{
    public class HomeController : Controller
    {
        // Please see RouteConfig.cs class
        public ActionResult Index()
        {
            return View();
        }

    }
}
