﻿using BusinessLogic;
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

    }
}