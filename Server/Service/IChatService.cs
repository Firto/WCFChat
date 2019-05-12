using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Server.Base.Tables;

namespace Server.Service
{
    public enum TypeGetUsers { // типи доставання изерів з бази
        All = 0, // усіх єзерів
        OnlyInGroup, // тілкі ті що в групі
        OnlyOutInGroup, // тількі ті що не в групі
    }

    [ServiceContract (CallbackContract = typeof(IChatServiceCallBack))]
    public interface IChatService
    {
        // Головні
        [OperationContract(IsOneWay = true)]
        void Register(string Login, string Email, string Password, string repeatPassword); // Регістрація
        [OperationContract(IsOneWay = true)]
        void Login(string Login, string Password); // Вхід
        [OperationContract(IsOneWay = true)]
        void Leave(); // виходимо

        [OperationContract(IsOneWay = true)]
        void SendMessage(int groupID, string message); // відправляємо повідомлення

        // Групи
        [OperationContract(IsOneWay = true)]
        void GetMyGroups(); // беремо групи
        [OperationContract(IsOneWay = true)]
        void CreateGroup(string Name, int[] IDs); // Створюємо группу
        [OperationContract(IsOneWay = true)]
        void LeaveGroup(int ID); // Видаляємо группу
        [OperationContract(IsOneWay = true)]
        void AddUsersToGroup(int ID, int[] IDs); // Добавляємо користувачів в групу

        // Навантажені
        [OperationContract]
        RUser[] GetUsers(int offset, int count); // беремо юзерів
        [OperationContract]
        Dictionary<RUser, RGroupMessage> GetMessages(int groupID, bool reverced, int count, int offset); // беремо повідомлення
        [OperationContract]
        RMUserInGroup[] GetUsersInGroup(int groupID, int offset, int count); // беремо юзерів

        // Кількість
        [OperationContract]
        int GetCountUsers(); // беремо кількість юзерів
        [OperationContract]
        int GetCountUsersInGroup(int groupID);
        [OperationContract]
        int GetCountMessages(int groupID); // беремо кількість повідомлень
    }
   

}
