using System.ServiceModel;
using System.Collections.Generic;

namespace ServiceLib
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        List<Models.Telephone> GetDict();
        [OperationContract]
        string GetAll();
        [OperationContract]
        string AddDict(string surname, string number);
        [OperationContract]
        string UpdDict(int id, string surname, string number);
        [OperationContract]
        string DelDict(int id);
    }
}
