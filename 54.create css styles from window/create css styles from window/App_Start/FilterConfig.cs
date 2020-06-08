using System.Web;
using System.Web.Mvc;

namespace create_css_styles_from_window
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}