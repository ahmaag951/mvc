using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace caputcha.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // 1. Install CaptchaMvc via nuget
            // 2. In the view there will be every thing
            return View();
        }

        [HttpPost]
        public string SubmitAction()
        {
            return "Submited done";
        }
    }
}