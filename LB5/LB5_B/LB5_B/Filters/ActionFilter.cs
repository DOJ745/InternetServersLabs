using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LB5_B.Filters
{
    public class ActionFilter: FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<div class=\"container\"><h3>ACTION filter executed</h3></div>");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<div class=\"container\"><h3>ACTION filter executing...</h3></div>");
        }
    }
}