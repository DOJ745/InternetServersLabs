using LB4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LB4.Controllers
{
    public class DictController : Controller
    {
        // GET: Dict
        PhoneBookContext db = new PhoneBookContext();
        public ActionResult Index()
        {
            ViewBag.PhoneBooks = db.Contacts.OrderBy(entry => entry.LastName);
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult AddSave(string lastName, string phone)
        {
            db.Contacts.Add(new Contact() { LastName = lastName, Number = phone });
            db.SaveChanges();
            ViewBag.PhoneBooks = db.Contacts;
            return Redirect("/Dict/Index");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            ViewBag.Id = id;
            ViewBag.PhoneBooks = db.Contacts;
            return View();
        }

        [HttpPost]
        public RedirectResult UpdateSave(string id, string lastName, string phone)
        {
            Contact contact = db.Contacts.Find(Int32.Parse(id));
            if (contact != null)
            {
                contact.LastName = lastName;
                contact.Number = phone;
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.PhoneBooks = db.Contacts;
            }

            ViewBag.PhoneBooks = db.Contacts;
            return Redirect("/Dict/Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSave(string id)
        {
            Contact contact = db.Contacts.Find(Int32.Parse(id));
            if (contact != null)
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();
                ViewBag.PhoneBooks = db.Contacts;
            }
            return View("Index");
        }
    }
}