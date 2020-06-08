using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {
       /*
        The steps:
        * 1. from nuget search on 'log4net' and select apache log4net
        * 2. in global.asx
        * 3. in web.config and create folder in the solution for loggings
        * 4. here
        */
        public ActionResult Index()
        {
            ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logger.Error("This is my custom error message");
            return View();
        }

    }
}
