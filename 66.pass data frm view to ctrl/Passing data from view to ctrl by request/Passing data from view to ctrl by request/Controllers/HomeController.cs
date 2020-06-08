using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Passing_data_from_view_to_ctrl_by_request.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // There are four ways to pass data from view to controller
            // 1. In the Request
            return View();
        }

        [HttpPost]
        public void IndexPost()
        {
            // This object is HttpRequestBase 
            // It contains name, value pairs in property called form
            var request = Request;
            var firstName = Request["firstName"];
        }


    }
}