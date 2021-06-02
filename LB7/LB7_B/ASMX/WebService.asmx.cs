using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ASMX
{
    /// <summary>
    /// Сводное описание для WebService
    /// </summary>
    /// 
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        Models.TelephoneDictionary telephoneDictionary = new Models.TelephoneDictionary();


        [WebMethod(Description = "Get JSON collection", EnableSession = true)]
        public string GetJSONCollection()
        {
            return telephoneDictionary.getAll();
        }

        [WebMethod(Description = "Get all contacts", EnableSession = true)]
        public List<Models.Telephone> GetContacts()
        {
            return telephoneDictionary.selectAll();
        }

        [WebMethod(Description = "Add new contact", EnableSession = true)]
        public string AddContact(string surname, string number)
        {
            telephoneDictionary.insert(surname, number);

            return "Contact successfully added!";
        }

        [WebMethod(Description = "Update contact by ID", EnableSession = true)]
        public string UpdateContact(int id, string surname, string number)
        {
            telephoneDictionary.update(id, surname, number);

            return "Contact successfully updated!";
        }

        [WebMethod(Description = "Delete contact by ID", EnableSession = true)]
        public string DeleteContact(int id)
        {
            telephoneDictionary.delete(id);

            return "Contact successfully deleted!";
        }
    }
}
