using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using check_box_list.Models;

namespace check_box_list.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var availbleFruitsList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Apple", Value = "Apple1"},
                new SelectListItem {Text = "Pear", Value = "Pear2"},
                new SelectListItem {Text = "Banana", Value = "Banana3"},
                new SelectListItem {Text = "Orange", Value = "Orange4"},
            };
            var model = new HomeModel
            {
                AvailbleFruits = availbleFruitsList
            };
            return View(model);
        }

        [HttpPost]
        public string Index(HomeModel model)
        {
            string output = "";
            foreach (var item in model.SelectedFruits)
            {
                output += item + " ";
            }
            return output;
        }
    }
}
