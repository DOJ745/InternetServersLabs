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

        public static string getSortedStrCollection(List<Contact> collection)
        {
            string sortedCollection = "";
            var sortedContacts = collection.OrderBy(elem => elem.lastname);

            foreach (Contact contact in sortedContacts)
            {
                sortedCollection += contact.ToString() + "\n";
            }
            return sortedCollection;
        }
    }
    public class DictController : Controller
    {
        // GET: Dict
        public ActionResult Index()
        {
            List<Contact> currentCollection = new List<Contact>();
            string collection = "";

            if (System.IO.File.Exists(@"D:\json.txt"))
            {
                currentCollection = Contact.readJSON();
                collection = Contact.getSortedStrCollection(currentCollection);
            }
            else
            {
                Contact createCollection = new Contact();
                currentCollection = Contact.CONTACTS;
                collection = Contact.getSortedStrCollection(currentCollection);
            }
            
            ViewData["Contacts"] = collection;
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

            Contact.CONTACTS.Add(newContact);
            Contact.writeJSON(Contact.CONTACTS);
            return "<h2>Contact has been added - [" + lastname + " --- " + phone + "]</h2>";
        }

        /*public ActionResult Update() 
        {
            return View();
        }
        public ActionResult UpdateSave() 
        { 

        }
        public ActionResult Delete() 
        {
            return View();
        }
        public ActionResult DeleteSave() 
        {
            
        }*/
    }
}