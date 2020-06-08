using System.Web;
using System.Web.Mvc;

namespace web_api_calls_stored_procedure
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}