using System.Web;
using System.Web.Mvc;

namespace redirect_to_action_with_model
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}