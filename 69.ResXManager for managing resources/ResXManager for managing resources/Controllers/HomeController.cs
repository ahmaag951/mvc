using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResXManager_for_managing_resources.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // 1. From extensions install ResXManager
            // 2. close all visual studio windows and wait for the scheduled tasks to be finished
            // 3. in tools menu you will find the resex manager and enjoy
            return View();
        }
    }
}