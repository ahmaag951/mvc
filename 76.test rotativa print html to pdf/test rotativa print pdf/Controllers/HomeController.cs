using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test_rotativa_print_pdf.Controllers
{
    public class HomeController : Controller
    {
        // 1. install rotativa from nuget
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExportPdf()
        {
            return new ActionAsPdf("Index")
            {
                FileName = Server.MapPath("~/Files/Index.pdf")
            };
        }
    }
}