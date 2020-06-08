using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(test_owin.Startup1))]

namespace test_owin
{
    public class Startup1
    {
        // 1. Create empty project 
        // 2. from nuget install owin => install-package Microsoft.Owin.Host.SystemWeb –Pre
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            // 3. this will code add to the owin pipeline middleware
            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, World!");
            });
        }
    }
}
