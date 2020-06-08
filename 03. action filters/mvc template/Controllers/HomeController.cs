using mvc_template.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {
        // Please go to FilterConfig.cs
        // To see the global filter that we have 
        public ActionResult Index()
        {
            var action = "action";
            return View();
        }

        // This custom filter will be called only for this action
        // Then the global filter will be called
        [CustomActionFilter]
        public void TestCustomActionFilter()
        {

        }

    }
}
