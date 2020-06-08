using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Response.Cookies["MyCookie"].Value = "My cookie value";

            return View();
        }

        public string AnotherAction()
        {
            var cookie = "";

            if (Request.Cookies["MyCookie"] != null)
            {
                cookie = Request.Cookies["MyCookie"].Value.ToString();
            }
            return "This is from a cookie: " + cookie;
        }

    }
}
