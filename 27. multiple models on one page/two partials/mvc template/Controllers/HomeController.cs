using mvc_template.Models;
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

        public ActionResult LoadPartial1() {
            return PartialView("_Partial1", new Model1());
        }

        public ActionResult LoadPartial2()
        {
            return PartialView("_Partial2", new Model2());
        }
    }
}
