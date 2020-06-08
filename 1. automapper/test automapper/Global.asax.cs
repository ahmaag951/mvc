using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace test_automapper
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Note this line
            CreateMap();

        }

        private void CreateMap()
        {
            // The commented on is the default
            // AutoMapper.Mapper.CreateMap<User, UserModel>();
            // This is the custom mapping (if you want)
            AutoMapper.Mapper.CreateMap<User, UserModel>().ForMember(r => r.Name, s => s.MapFrom(t => t.FakeName));
        }
    }
}