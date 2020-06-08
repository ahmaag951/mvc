using System.Web.Security;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using mvc_template.Helpers;

namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {
        UserProxy _UserProxy = new UserProxy();

        public ActionResult Index()
        {

            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            if (_UserProxy.IsUserExists(user))
            {
                FormsAuthentication.SetAuthCookie(user.Username, true);

            }

            return RedirectToAction("Index");
        }

        [CustomAuthorize(Group = "Admins")]
        public string Admin()
        {
            return "This page for admins only";
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


    }
}
