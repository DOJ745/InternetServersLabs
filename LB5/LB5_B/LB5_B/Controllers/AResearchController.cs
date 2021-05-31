using LB5_B.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LB5_B.Controllers
{
    public class AResearchController : Controller
    {
        // GET: AResearch
        public ActionResult Index()
        {
            return View();
        }

        [ActionFilter]
        public ActionResult AA(int? id)
        {
            Response.Write("<div class=\"container\"><h2>AA Action(ID): " + id.Value + "</h2></div>");
            return View("Index");
        }

        [ExceptionFilter]
        public ActionResult AE()
        {
            throw new Exception("Exception message");
        }

        [ResultFilter]
        public ActionResult AR()
        {
            Response.Write("<div class=\"container\"><h2>AR Action</h2></div>");
            return View("Index");
        }

    }
}