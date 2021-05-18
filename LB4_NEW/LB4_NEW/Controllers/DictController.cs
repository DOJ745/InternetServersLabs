using LB4_NEW.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace LB4_NEW.Controllers
{
    public class DictController : Controller
    {
        PhoneBookContext DB = new PhoneBookContext();


        // GET: Dict
        public ActionResult Index()
        {
            ViewBag.PhoneBooks = DB.Contacts.OrderBy(entry => entry.LastName);
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
            DB.Contacts.Add(new Contact() { LastName = lastName, Number = phone });
            DB.SaveChanges();

            ViewBag.PhoneBooks = DB.Contacts;
            return Redirect("/Dict/Index");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            ViewBag.Id = id;
            ViewBag.PhoneBooks = DB.Contacts;
            return View();
        }

        [HttpPost]
        public RedirectResult UpdateSave(string id, string lastName, string phone)
        {
            Contact contact = DB.Contacts.Find(Int32.Parse(id));
            if (contact != null)
            {
                contact.LastName = lastName;
                contact.Number = phone;

                DB.Entry(contact).State = EntityState.Modified;
                DB.SaveChanges();

                ViewBag.PhoneBooks = DB.Contacts;
            }

            ViewBag.PhoneBooks = DB.Contacts;
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
            Contact contact = DB.Contacts.Find(Int32.Parse(id));
            if (contact != null)
            {
                DB.Contacts.Remove(contact);
                DB.SaveChanges();

                ViewBag.PhoneBooks = DB.Contacts;
            }
            return View("Index");
        }
    }
}