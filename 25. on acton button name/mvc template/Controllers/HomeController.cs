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

        [HttpPost]
        [ActionName("Page")]
        [OnAction(ButtonName = "Add")]
        public string Add(string name)
        {
            return "Add" + name;
        }

        [HttpPost]
        [ActionName("Page")]
        [OnAction(ButtonName = "Edit")]
        public string Edit(string name)
        {
            return "Edit" + name;
        }
    }
}
