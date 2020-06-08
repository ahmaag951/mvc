using System.Web;
using System.Web.Mvc;

namespace Custom_control_extension_methods
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}