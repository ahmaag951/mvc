using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Custom_Model_Binder.Models;

namespace Custom_Model_Binder.CustomModelBinders
{
    // there are alot of IModelBinders choose the one that on system.web.mvc
    public class MyCustomDateBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
            string Day = request.Form.Get("Day");
            string Month = request.Form.Get("Month");
            string Year = request.Form.Get("Year");

            return new HomeModel { Date = Day + "/" + Month + "/" + Year };
        }
    }
}