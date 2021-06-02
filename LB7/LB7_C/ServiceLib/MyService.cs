using System.Collections.Generic;

namespace ServiceLib
{
    public class MyService : IMyService
    {
        Models.TelephoneDictionary telephoneDictionary = new Models.TelephoneDictionary();


        public string GetAll()
        {
            return telephoneDictionary.getAll();
        }

        public List<Models.Telephone> GetDict()
        {
            return telephoneDictionary.selectAll();
        }

        public string AddDict(string surname, string number)
        {
            telephoneDictionary.insert(surname, number);

            return "Contact has been added!";
        }

        public string UpdDict(int id, string surname, string number)
        {
            telephoneDictionary.update(id, surname, number);

            return "Contact has been updated!";
        }

        public string DelDict(int id)
        {
            telephoneDictionary.delete(id);

            return "Contact has been deleted!";
        }
    }
}
