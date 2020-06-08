using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Custom_Model_Binder.CustomModelBinders;
using Custom_Model_Binder.Models;

namespace Custom_Model_Binder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
             From this url
             * https://www.codeproject.com/Articles/605595/ASP-NET-MVC-Custom-Model-Binder
             */
            return View();
        }

        // 1. add class
        // 2. register it to global.asx
        [HttpPost]
        public string Post([ModelBinder(typeof(MyCustomDateBinder))] HomeModel model)
        {
            return model.Date;
        }
    }
}
