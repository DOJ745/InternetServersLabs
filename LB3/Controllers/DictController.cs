using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LB3.Controllers
{
    public class DictController : Controller
    {
        // GET: Dict
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add() 
        {
            return View();
        }

        public string AddSave() 
        {
            /*string ip = requestContext.HttpContext.Request.UserHostAddress;
            var response = requestContext.HttpContext.Response;
            response.Write("<h2>Ваш IP-адрес: " + ip + "</h2>");*/
            //return "RETURN RESULT";

            // Извлечь отправленные данные из Request.Form 
            string lastname = Request.Form["lastname"];
            string phone = Request.Form["phone"];
            return lastname + " --- " + phone;
        }
        /*public ActionResult Update() { }
        public ActionResult UpdateSave() { }
        public ActionResult Delete() { }
        public ActionResult DeleteSave() { }*/
    }
}