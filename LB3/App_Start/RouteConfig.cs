using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LB3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DictStartPage",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "Index" }
            );

            /*
            // ----------- ADD -----------

            routes.MapRoute(
                name: "DictAddPage",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "Add" }
            );

            routes.MapRoute(
                name: "DictAddSave",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "AddSave" }
            );

            // ----------- UPDATE -----------

            routes.MapRoute(
                name: "DictUpdatePage",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "Update" }
            );

            routes.MapRoute(
                name: "DictUpdateSave",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "UpdateSave" }
            );

            // ----------- DELETE -----------

            routes.MapRoute(
                name: "DictDeletePage",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "Delete" }
            );

            routes.MapRoute(
                name: "DictDeleteSave",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "DeleteSave" }
            );*/

            // ----------- DEFAULT -----------

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
