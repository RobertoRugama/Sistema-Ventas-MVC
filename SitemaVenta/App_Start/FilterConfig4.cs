﻿using System.Web;
using System.Web.Mvc;

namespace SitemaVenta
{
    public class FilterConfig4
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
