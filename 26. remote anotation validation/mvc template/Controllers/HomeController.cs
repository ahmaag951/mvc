﻿using System;
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
            return View(new User());
        }

        [HttpPost]
        public string Index(User user)
        {
            return "Post " + user.Email;
        }

        [HttpPost]        
        public ActionResult IsEmailExists(string name)
        {
            bool result = false; // Just for example
            return Json(result);
        }
    }
}
