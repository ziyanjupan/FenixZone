﻿using FeinxZone.Attributes;
using System.Web;
using System.Web.Mvc;

namespace FeinxZone
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AuthAttribute());
        }
    }
}
