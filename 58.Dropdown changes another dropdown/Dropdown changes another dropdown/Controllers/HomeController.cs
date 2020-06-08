using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Dropdown_changes_another_dropdown.Models;

namespace Dropdown_changes_another_dropdown.Controllers
{
    public class HomeController : Controller
    {
        TestEntities _db = new TestEntities();

        public ActionResult Index()
        {
            ViewBag.Countries = _db.Countries.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }); ;
            //ViewBag.Cities = _db.Cities.ToList();

            return View();
        }

        public JsonResult GetCities(int CountryId)
        {
            var cities = _db.Cities.Where(r => r.CountryIdFk == CountryId).ToList().Select(x=> new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return Json(cities, JsonRequestBehavior.AllowGet);
        }

    }
}
