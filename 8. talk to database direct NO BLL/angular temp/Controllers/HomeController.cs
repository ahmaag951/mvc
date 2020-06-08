using angular_temp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace angular_temp.Controllers
{
    public class HomeController : Controller
    {
        private FacultyEntities _db = new FacultyEntities();
        public ActionResult Index()
        {
            
            // The ADD operation
            // db.SecUsers.Add(user);
            // db.SaveChanges();
            // Don't forget to override dispose
            return View(_db.Departments.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

    }
}
