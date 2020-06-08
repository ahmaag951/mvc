using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_template.Helpers;

namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {
        // In web.config in configuration you have to add system.net with mail settings on it
        public ActionResult Index()
        {
            SendEmail("ahmad.ezzat2050@yahoo.com", "Hello");
            return View();
        }

        private bool SendEmail(string email, string body)
        {
            SMTPEmailSender sender = new SMTPEmailSender();

            string subject = "Test send email";
            string from = "abc@def.com"; // Can be from the web.config
            if (sender.SendEmail(from, email, null, null, subject, body, true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
