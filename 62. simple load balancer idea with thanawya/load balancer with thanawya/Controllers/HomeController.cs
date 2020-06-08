using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace load_balancer_with_thanawya.Controllers
{
    enum mohafzat { cairo = 1, sharkya = 2 }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int golosNumber, int mohafzaId)
        {
            switch (mohafzaId)
            {
                case (int)mohafzat.cairo:
                    // talk to cairo server that has cairo database
                    break;
                case (int)mohafzat.sharkya:
                    // talk to sharkya server that has cairo database
                    break;
                default:
                    break;
            }
            return View();
        }
    }
}