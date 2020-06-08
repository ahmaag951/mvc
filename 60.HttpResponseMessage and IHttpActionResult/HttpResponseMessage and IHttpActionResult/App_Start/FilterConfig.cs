using System.Web;
using System.Web.Mvc;

namespace HttpResponseMessage_and_IHttpActionResult
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
