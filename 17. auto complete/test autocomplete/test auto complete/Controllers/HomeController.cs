using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test_auto_complete.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Edit() {
            
            
            return View();
        }



        public ActionResult AutoComplete(string term) {
            List<Emp> list = new List<Emp>();

            list.Add(new Emp(){ Name = "abc"  });
            list.Add(new Emp() { Name = "abb" });
            list.Add(new Emp() { Name = "cba" });
            list.Add(new Emp() { Name = "abd" });
            
            var model = list.Where(r=>r.Name.StartsWith(term)).Select(r => new { 
                label = r.Name
            });

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }

    public class Emp {
        //public int Id { get; set; }
        public string Name { get; set; }
    }
}
