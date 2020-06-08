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
            // in web.config in systemm.web open the custom errors
            // if you Created page with name "Error" in Views => Shared 
            // it will be the default error handling page
            throw new StackOverflowException();
            return View();
        }

        [HandleError(View = "DivideByZeroCustomErrorPage", ExceptionType = typeof(DivideByZeroException))]
        public void TestDivideByZeroException() {

            throw new DivideByZeroException();
        }

    }
}
