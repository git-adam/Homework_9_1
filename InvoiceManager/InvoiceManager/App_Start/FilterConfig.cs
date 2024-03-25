﻿using System.Web;
using System.Web.Mvc;

namespace InvoiceManager
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomExceptionFilter());
            filters.Add(new HandleErrorAttribute());
        }

        public class CustomExceptionFilter : IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                var exception = filterContext.Exception;
                //logowanie do pliku
            }
        }

    }
}
