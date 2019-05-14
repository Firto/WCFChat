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
        void RLogin(RUser usr); // Підтверження про вхід
        [OperationContract(IsOneWay = true)]
        void RLeave(); // Підтверджуєм що ми вийшли

        [OperationContract(IsOneWay = true)]
        void RChangeOnline(RUser usr);
        [OperationContract(IsOneWay = true)]
        void RNewUser(RUser usr);

        [OperationContract(IsOneWay = true)]
        void RGroups(RMUserInGroup[] groups); // Відправляєм всі групи
        [OperationContract(IsOneWay = true)]
        void RLeaveGroup(RGroup group); // Відправляємо що група видалена
        [OperationContract(IsOneWay = true)]
        void RNewGroup(RMUserInGroup usrInGrp); // Відправляємо нову группу
        [OperationContract(IsOneWay = true)]
        void RNewUsersInGroup(RMUserInGroup[] users); // Відправляємо що додано нових юзерів
        [OperationContract(IsOneWay = true)]
        void RLeaveUserInGroup(RGroup group, RUser usr);

        [OperationContract(IsOneWay = true)]
        void RNewMessage(RUser user, RGroupMessage msg); // Відправляємо що додано нове повідомлення
        //[OperationContract(IsOneWay = true)]
        //void WritingMessage(RUser usr, RUserInGroup usrInGrp, int miliseconds);

    }
}
