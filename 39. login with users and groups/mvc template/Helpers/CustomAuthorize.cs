using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using BusinessLogic;

namespace mvc_template.Helpers
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        GroupUserProxy _GroupUserProxy = new GroupUserProxy();

        public string Group { get; set; }

        // Called when the process require authorization

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = filterContext.HttpContext.User.Identity.Name;
            if (!_GroupUserProxy.IsUserInGroup(user, Group))
            {
                //var returnUrl = filterContext.HttpContext.Request.Url.PathAndQuery;
                //filterContext.Result = new RedirectResult(returnUrl);
                filterContext.Result = new RedirectResult("~/Home/Login");
            }
            
            base.OnAuthorization(filterContext);
        }


        // Process requests that fail the authorization
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}