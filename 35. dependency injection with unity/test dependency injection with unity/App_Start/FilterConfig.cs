using System.Web;
using System.Web.Mvc;

namespace test_dependency_injection_with_unity
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}