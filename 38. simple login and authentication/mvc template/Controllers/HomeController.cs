using System.Web.Security;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {       
        UserProxy _UserProxy = new UserProxy();


        // In web.config in system.web section you have to add "authentication mode" forms
        public ActionResult Index()
        {
            
            return View();
        }

        [Authorize]
        public ActionResult Main()
        {
            
            return View();
        }

        
        public ActionResult Login(User user)
        {
            if (_UserProxy.IsUserExists(user))
            {
                FormsAuthentication.SetAuthCookie(user.Username, true);                
                return RedirectToAction("Main");
            }

            return Content("Wrong username and password");
        }

        public string NotAuthorized() {
            return "Sorry, you are not authorized";
        }

    }
}
