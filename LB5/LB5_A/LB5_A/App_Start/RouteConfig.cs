using System.Web.Mvc;
using System.Web.Routing;

namespace LB5_A
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "V2_ROUTES",
                url: "V2/{controller}/{action}/{id}",
                defaults: new {
                    controller = UrlParameter.Optional, 
                    action = UrlParameter.Optional,
                    id = UrlParameter.Optional
                });

            routes.MapRoute(
                name: "V3_ROUTES",
                url: "V3/{controller}/{action}/{id}",
                defaults: new
                {
                    controller = UrlParameter.Optional,
                    action = UrlParameter.Optional,
                    id = UrlParameter.Optional
                });

            routes.MapRoute(
                name: "M_START",
                url: "",
                defaults: new { controller = "MResearch", action = "M01", id = UrlParameter.Optional }
            );

        }
    }
}
