using System.Web;
using System.Web.Mvc;

namespace Dropdown_changes_another_dropdown
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}