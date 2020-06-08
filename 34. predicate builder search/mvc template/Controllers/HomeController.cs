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
            var list = _EmployeeProxy.Items;
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(Employee employee)
        {
            var list = _EmployeeProxy.GetEmployees(employee);
            return View(list);
        }

    }
}
