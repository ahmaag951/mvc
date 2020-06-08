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
            // The tempdata will live and reach the second page.
            // The view data will not survive an it will die.
            TempData["key"] = "Hello, I am a temp data.";
            ViewData["key"] = "Hello, I am a view data.";

            return View();
        }

        public ActionResult SecondPage()
        {

            return View();
        }

    }
}
