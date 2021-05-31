using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LB5_B.Filters
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Write("<div class=\"container\"><h3>InvalidOperationException</h3></div>");
            filterContext.HttpContext.Response.Write($"<p>EXCEPTION filter: {filterContext.Exception.Message}</p>");
        }
    }
}