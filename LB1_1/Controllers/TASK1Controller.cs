using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LB1_1.Controllers
{
    public class TASK1Controller : Controller
    {
        // GET: TASK1
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Reqest()
        {
            HttpContextBase context = this.HttpContext;
            HttpRequestBase rq = context.Request;
            ViewBag.Request = rq;
            return View();
        }
        public ActionResult Responsex()
        {
            return View();
        }
    }
}