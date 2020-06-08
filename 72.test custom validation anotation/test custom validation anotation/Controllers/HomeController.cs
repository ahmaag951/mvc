using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_custom_validation_anotation.Models;

namespace test_custom_validation_anotation.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // Please go to the model to see the custom validation
        public string Index(model m) {
            return "You passed a model and the model's state is: " + ModelState.IsValid.ToString();
        }
    }
}
