﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LB4_NEW.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            ViewBag.url = Request.RawUrl;
            ViewBag.method = Request.HttpMethod;
            return View();
        }
    }
}