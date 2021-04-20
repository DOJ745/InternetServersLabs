using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LB3.Controllers
{
    public class Contact
    {
        public static List<Contact> CONTACTS = new List<Contact>();
        public Contact() 
        {
            CONTACTS.Add(new Contact("Helkar", "+1 800 987 353"));
            CONTACTS.Add(new Contact("Bill", "+1 800 123 444"));
        }
        public Contact(string _lastname, string _phone) 
        {
            this.lastname = _lastname;
            this.phone = _phone;
        }
        public string lastname { get; set; }
        public string phone { get; set; }

        public static void writeJSON(List<Contact> _contacts) 
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(@"D:\json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, _contacts);
            }
            Console.WriteLine("Contacts has been saved to D:\\json.txt");
        }
        public static List<Contact> readJSON() 
        {
            List<Contact> readContacts;

            JsonSerializer deserializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader(@"D:\json.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                readContacts = deserializer.Deserialize<List<Contact>>(reader);
            }
            return readContacts;
        }

        public override string ToString()
        {
            return $"[{this.lastname} --- {this.phone}]";
        }
    }
    public class DictController : Controller
    {
        public static List<Contact> CURRENT_CONTACTS = new List<Contact>();
        // GET: Dict
        public ActionResult Index()
        {

            if (System.IO.File.Exists(@"D:\json.txt"))
            {
                CURRENT_CONTACTS = Contact.readJSON();
            }
            else
            {
                Contact createCollection = new Contact();
                CURRENT_CONTACTS = Contact.CONTACTS;
            }
            
            ViewData["Contacts"] = CURRENT_CONTACTS;
            return View();
        }
        public ActionResult Add() 
        {
            return View();
        }

        public string AddSave() 
        {
            string lastname = Request.Form["lastname"];
            string phone = Request.Form["phone"];

            Contact newContact = new Contact(lastname, phone);

            CURRENT_CONTACTS.Add(newContact);
            Contact.writeJSON(CURRENT_CONTACTS);
            return "<h2>Contact has been added - [" + lastname + " --- " + phone + "]</h2>";
        }

        public ActionResult Update() 
        {
            return View();
        }
        public string UpdateSave() 
        {
            string oldLastname = Request.Form["oldLastname"];
            string oldPhone = Request.Form["oldPhone"];

            string newLastname = Request.Form["lastname"];
            string newPhone = Request.Form["phone"];

            Contact oldContact = new Contact(oldLastname, oldPhone);
            CURRENT_CONTACTS.Remove(oldContact);

            Contact updatedContact = new Contact(newLastname, newPhone);
            CURRENT_CONTACTS.Add(updatedContact);

            return "<h2>Contact [" + oldLastname + " --- " + oldPhone + "] has been updated - " +
                "[" + newLastname + " --- " + newPhone + "]</h2>";
        }

        public ActionResult Delete() 
        {
            return View();
        }
        public string DeleteSave() 
        {
            string lastname = Request.Form["lastname"];
            string phone = Request.Form["phone"];

            Contact deletedContact = new Contact(lastname, phone);
            CURRENT_CONTACTS.Remove(deletedContact);
            Contact.writeJSON(CURRENT_CONTACTS);

            return "<h2>Contact has been deleted - [" + lastname + " --- " + phone + "]</h2>";
        }
    }
}