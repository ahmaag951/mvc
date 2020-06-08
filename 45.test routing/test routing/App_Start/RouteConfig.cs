using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace test_routing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var regexNumbersOnly = @"\d+";

            routes.MapRoute(
                name: "Default",
                url: "Home/Index/id",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                // you can put constrains using the regular expressions
                // this is not working it has a problem
                constraints: new { id = regexNumbersOnly }
            );

            // If a route matches the url, it will stop searching ...
            routes.MapRoute(
                // if you used a redundant name an exception will happen
                name: "Default1",
                // the curly praces { } means that it matches abc or any word other than abc, but the default is abc
                url: "{abc}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}