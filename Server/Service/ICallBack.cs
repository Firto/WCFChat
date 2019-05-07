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
        void ReciveMyGroups(RMUserInGroup[] groups); // Відправляєм всі групи
        [OperationContract(IsOneWay = true)]
        void ReciveLeave(); // Підтверджуєм що ми вийшли
        [OperationContract(IsOneWay = true)]
        void ReciveLogin(RUser usr); // Підтверження про вхід
        [OperationContract(IsOneWay = true)]
        void ReciveNewGroup(RMUserInGroup usrInGrp); // Відправляємо нову группу
        [OperationContract(IsOneWay = true)]
        void ReciveLeaveGroup(RGroup group); // Відправляємо що група видалена
        [OperationContract(IsOneWay = true)]
        void ReciveChangeOnline(RUser usr);
        [OperationContract(IsOneWay = true)]
        void ReciveNewUser(RUser usr);
        [OperationContract(IsOneWay = true)]
        void ReciveAddedUsers(RGroup group, RMUserInGroup[] users); // Відправляємо що додано нових юзерів
        [OperationContract(IsOneWay = true)]
        void ReciveNewMessage(RGroupMessage msg); // Відправляємо що додано нове повідомлення

    }
}
