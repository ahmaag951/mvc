using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_selected_list.Models;

namespace test_selected_list.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var obList = new List<Ob>();
            obList.Add(new Ob { Id = 1, Name = "abc" });
            obList.Add(new Ob { Id = 2, Name = "def" });
            //new SelectList(list, value, name, selected)
            ViewBag.List = new SelectList(obList.OrderBy(g => g.Name),
"Id", "Name");

            //---------------------------------------------------------------------
            var selectListItem = new List<SelectListItem>();
            selectListItem.Add(new SelectListItem { Value = "1", Text = "abc" });
            selectListItem.Add(new SelectListItem { Value = "2", Text = "def" });
            ViewBag.ListItems = selectListItem;


            ViewBag.MyValue = "ahmad";
            ViewBag.MyValueList = selectListItem;
            ViewBag.MyNestedValue = new Ob { Id = 2, Name = "def" };
            // If you want to create select list item from list
                 /*       ViewBag.Genres =
            storeDB.Genres
            .OrderBy(g => g.Name)
            .AsEnumerable()
            .Select(g => new SelectListItem
            {
                Text = g.Name,
                Value = g.GenreId.ToString(),
                Selected = album.GenreId == g.GenreId
            });*/


            return View();
        }

        [HttpPost]
        public void Index(MyModel model)
        {
            
        }

    }

    public class Ob
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class BusinessLayer
    {
        public List<Ob> GetList()
        {
            var obList = new List<Ob>();
            obList.Add(new Ob { Id = 1, Name = "abc" });
            obList.Add(new Ob { Id = 2, Name = "def" });
            return obList;
        }

    }
}
