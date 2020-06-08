using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tempdata.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TempData["temp1"] = "temp1";
            TempData["temp2"] = "temp2";
            TempData["temp3"] = "temp3"; // this wont live to the third request, if you want it to do that do keep()
            TempData["tempAjax"] = "tempAjax"; 
            return View();
        }

        public ActionResult AnotherRequest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AnotherRequestByAjax()
        {
            var temp = TempData["tempAjax"];
            return Json(Url.Action("AnotherRequestByAjaxGet", "Home"));
        }

        public ActionResult AnotherRequestByAjaxGet()
        {
            var temp = TempData["tempAjax"];
            return View();
        }

        public ActionResult ThirdRequest()
        {
            return View();
        }
    }
}
