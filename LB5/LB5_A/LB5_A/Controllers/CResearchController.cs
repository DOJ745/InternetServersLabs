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

            foreach (string key in Request.Headers)
            {
                var value = Request.Headers[key];
                response.AppendLine(value + "<br />");
            }

            response.AppendLine("Raw URI - " + Request.RawUrl + "<br />");
            response.AppendLine("Status - " + Response.Status + "<br />");
            response.AppendLine("Body (form) - " + Request.Form + "<br />");

            Response.Write(response.ToString());
            ViewBag.Rd = routeDictionary;

            return View();
        }
    }
}