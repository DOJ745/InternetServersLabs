using System.Collections.Generic;

namespace PhonesLib
{
    public interface IPhoneDictionary<T> where T : class
    {
        List<T> GetConList();
        T GetContact(long id);
        void Create(T item);
        void Update(T item);
        void Delete(long id);
    }
}
