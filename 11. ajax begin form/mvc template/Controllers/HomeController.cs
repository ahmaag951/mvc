using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {
        EmployeeProxy _EmployeeProxy = new EmployeeProxy();
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _EmployeeProxy.Update(emp);
            }
            return PartialView("_SimplePartial");
        }

    }
}
