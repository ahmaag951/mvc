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

        public ActionResult GetPDF()
        {
            string path = "D:/a.pdf";
            if (System.IO.File.Exists(path))
            {
                return File(path, "application/pdf");
            }
            else
            {
                return null;
            }
        }

    }
}
