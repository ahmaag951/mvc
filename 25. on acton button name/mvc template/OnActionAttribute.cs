using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_template
{
    public class OnActionAttribute : ActionMethodSelectorAttribute
    {
        public string ButtonName { get; set; }

        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            var request = controllerContext.RequestContext.HttpContext.Request;
            return !string.IsNullOrEmpty(request.Form[this.ButtonName]);
        }

    }
}