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
                readContacts = (List<Contact>)deserializer.Deserialize(reader);
            }
            return readContacts;
        }
    }
    public class DictController : Controller
    {
        // GET: Dict
        public ActionResult Index()
        {
            Contact createCollection = new Contact();
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

            Contact newContact = new Contact();
            newContact.lastname = lastname;
            newContact.phone = phone;

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