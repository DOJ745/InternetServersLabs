using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LB5_B.Controllers
{
    public class CHResearchController : Controller
    {
        private static int counter = 0;

        // GET: CHResearch
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [OutputCache(Duration = 5)]
        public ActionResult AD()
        {
            Response.Write("<h3>Counter: " + (++counter) + "</h3>");
            return View("Index");
        }

        [HttpPost]
        [OutputCache(Duration = 7)]
        public ActionResult AP(int x, int y)
        {
            Response.Write("<h3>Counter: " + DateTime.Now.ToString() + " --- Result --- " + (x + y) + "</h3>");
            return View("Index");
        }
    }
}