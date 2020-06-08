using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        // Now he doesn't now /Home/Test
        // He only knows /Home/Ahmad-Ezzat
        [ActionName("Ahmad-Ezzat")]
        public void Test() {
        
        }

    }
}
