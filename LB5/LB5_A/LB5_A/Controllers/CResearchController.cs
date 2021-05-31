using System.Text;
using System.Web.Mvc;

using System.Web.Routing;

namespace LB5_A.Controllers
{
    public class CResearchController : Controller
    {
        [AcceptVerbs("GET", "POST")]
        public ActionResult C01(string data)
        {
            RouteData routeData = this.RouteData;

            RouteValueDictionary routeDictionary = this.RouteData.Values;
            ViewBag.Rd = routeDictionary;

            return View();
        }

        [AcceptVerbs("GET", "POST")]
        public ActionResult C02()
        {
            RouteData routeData = this.RouteData;

            RouteValueDictionary routeDictionary = this.RouteData.Values;
            StringBuilder response = new StringBuilder();

            response.AppendLine("<h3>Headers</h3>");
            foreach (string key in Request.Headers)
            {
                var value = Request.Headers[key];
                response.AppendLine(value + "<br />");
            }

            response.AppendLine("<p>Status code - <h5>" + Response.Status + "</h5></p>");
            response.AppendLine("<p>Body (form) - <h5>" + Request.Form + "</h5></p>");

            Response.Write(response.ToString());
            ViewBag.Rd = routeDictionary;

            return View();
        }
    }
}