using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using redirect_to_action_with_model.Models;

namespace redirect_to_action_with_model.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var emp = new Employee() {Name = "Ahmad"};
            return RedirectToAction("Second", emp);
        }

        public string Second(Employee employee)
        {
            return "This is the second action: "  + employee.Name;
        }
    }
}
