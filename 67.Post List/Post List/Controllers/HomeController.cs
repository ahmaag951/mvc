using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Post_List.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var gifts = new List<Gift>()
            {
                new Gift(){ Name = "G1", Price = 5.5},
                new Gift(){ Name = "G2", Price = 16.99},
            };
            return View(gifts);
        }

        [HttpPost]
        public string Index(IEnumerable<Gift> gifts)
        {
            string result = "";
            foreach (var gift in gifts)
            {
                result += gift.Name + " ";
            }

            return result;
        }

    }
}
