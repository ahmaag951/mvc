leeksnet.AspNet.WebApi.Wadl - Readme
====================================

For information about this package, see the blog posts below:
 * http://blogs.msdn.com/b/stuartleeks/archive/2014/05/20/teaching-asp-net-web-api-to-wadl.aspx
 * http://blogs.msdn.com/b/stuartleeks/archive/2014/06/22/teaching-asp-net-web-api-to-wadl-via-nuget.aspx

 Quick start
 -----------
 After installing the package, build and run the solution and navigate to /Help/Wadl to see the generated output.

 The WADL output is based on the API Explorer metadata. You can control which APIs are documented (and therefore included in the WADL output) using the ApiExplorerSettings attribute as shown below. 
 This attribute can be applied at the controller level or the individual action level. 
 
 E.g.
    [ApiExplorerSettings(IgnoreApi=true)]
    public class AccountController : ApiController
