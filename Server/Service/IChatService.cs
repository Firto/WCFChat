using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Server.Clases.Base;

namespace Server.Service
{
    public enum TypeGetUsers {
        All = 0,
        OnlyInGroup,
        OnlyOutInGroup,
    }

    public enum TypeGetMessage {
        All = 0,
        Last,
        First
    }

    [ServiceContract (CallbackContract = typeof(ICallBack))]
    public interface IChatService
    {
        [OperationContract]
        bool Register(string Login, string Password, out User usr);
        [OperationContract]
        bool Login(string Login, string Password, out User usr, out string authKey);
        [OperationContract]
        bool Leave(string AuthKey);
        [OperationContract]
        bool GetUsers(string AuthKey, TypeGetUsers tps, out List<User> usr, int GroupID = 0);
        [OperationContract]
        bool CreateGroup(string AuthKey, string Name);
        [OperationContract]
        bool RemoveGroup(string AuthKey, int ID);
        [OperationContract]
        bool AddUsersToGroup(string AuthKey, int ID, List<int> IDs);
        [OperationContract]
        bool GetMyGroups(string AuthKey, out Dictionary<Group, UserInGroup> group);
        [OperationContract]
        bool GetMessages(string AuthKey, int groupID, TypeGetMessage tgm, int count, out List<GroupMessage> grMsg);
        [OperationContract]
        bool SendMessage(string AuthKey, int groupID, string message);
    }
   

}
