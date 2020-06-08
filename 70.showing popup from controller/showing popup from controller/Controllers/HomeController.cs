using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace showing_popup_from_controller.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // 1. Add static class called Helper for example and add static method called "SetPopupMessageResponse" so you can use it from the controller as you want
            // 2. go to the view
            this.SetPopupMessageResponse(PopupMessageResponse.SetSuccess("تم الحفظ بنجاح", closeLabel: "إغلاق"));
            return View();
        }
    }
}