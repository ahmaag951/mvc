﻿using System.Web;
using System.Web.Mvc;

namespace Custom_Model_Binder
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}