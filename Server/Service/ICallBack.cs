using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Server.Base.Tables;

namespace Server.Service
{
    public interface IChatServiceCallBack 
    {
        // Головні
        [OperationContract(IsOneWay = true)]
        void Error(string message); // Помилка
        [OperationContract(IsOneWay = true)]
        void Message(string message); // Повідомлення

        [OperationContract(IsOneWay = true)]
        void ReciveMyGroups(Dictionary<Group, UserInGroup> group); // Відправляєм всі групи
        [OperationContract(IsOneWay = true)]
        void ReciveLeave(); // Підтверджуєм що ми вийшли
        [OperationContract(IsOneWay = true)]
        void ReciveLogin(User usr); // Підтверження про вхід
        [OperationContract(IsOneWay = true)]
        void ReciveGetUsers(List<User> usr); // Відправляємо юзерів
        [OperationContract(IsOneWay = true)]
        void ReciveNewGroup(Group group); // Відправляємо нову группу
        [OperationContract(IsOneWay = true)]
        void ReciveRemoveGroup(Group group); // Відправляємо що група видалена
        [OperationContract(IsOneWay = true)]
        void ReciveAddedUsers(Group group, Dictionary<User, UserInGroup> users); // Відправляємо що додано нових юзерів
        [OperationContract(IsOneWay = true)]
        void ReciveNewMessage(Group group, User user, GroupMessage msg); // Відправляємо що додано нове повідомлення

    }
}
