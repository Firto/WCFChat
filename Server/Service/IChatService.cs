using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Server.Clases.Base;

namespace Server.Service
{
    public enum TypeGetUsers { // типи доставання изерів з бази
        All = 0, // усіх єзерів
        OnlyInGroup, // тілкі ті що в групі
        OnlyOutInGroup, // тількі ті що не в групі
    }

    public enum TypeGetMessage { // типи доставання повідомлень з бази
        All = 0,
        Last, //  З кінця
        First // З початку
    }

    [ServiceContract (CallbackContract = typeof(IChatServiceCallBack))]
    public interface IChatService
    {
        // Головні
        [OperationContract(IsOneWay = true)]
        void Register(string Login, string Password); // Регістрація
        [OperationContract(IsOneWay = true)]
        void Login(string Login, string Password); // Вхід
        [OperationContract(IsOneWay = true)]
        void Leave(string AuthKey); // виходимо

        [OperationContract(IsOneWay = true)]
        void SendMessage(string AuthKey, int groupID, string message); // відправляємо повідомлення

        // Кількість
        [OperationContract]
        int GetCountUsers(string AuthKey); // беремо кількість юзерів
        [OperationContract]
        int GetCountMessages(string AuthKey, int groupID); // беремо кількість повідомлень

        // Групи
        [OperationContract(IsOneWay = true)]
        void GetMyGroups(string AuthKey); // беремо групи
        [OperationContract(IsOneWay = true)]
        void CreateGroup(string AuthKey, string Name); // Створюємо группу
        [OperationContract(IsOneWay = true)]
        void RemoveGroup(string AuthKey, int ID); // Видаляємо группу
        [OperationContract(IsOneWay = true)]
        void AddUsersToGroup(string AuthKey, int ID, List<int> IDs); // Добавляємо користувачів в групу

        // Навантажені
        [OperationContract(IsOneWay = true)]
        void GetUsers(string AuthKey, TypeGetUsers tps, int count, int offset, int GroupID = 0); // беремо юзерів
        [OperationContract(IsOneWay = true)]
        void GetMessages(string AuthKey, int groupID, TypeGetMessage tgm, int count, int offset); // беремо повідомлення
    }
   

}
