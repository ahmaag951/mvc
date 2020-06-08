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
            var theBigModel = new TheBigModel();
            var model1 = new Model1() { Prop1 = "p1" };
            var model2 = new Model2() { Prop2 = "p2" };

            theBigModel.Model1 = model1;
            theBigModel.Model2 = model2;
            return View(theBigModel);
        }

        public ActionResult LoadPartial1()
        {
            return PartialView("_Partial1", new Model1());
        }

        public ActionResult LoadPartial2()
        {
            return PartialView("_Partial2", new Model2());
        }
    }
}
