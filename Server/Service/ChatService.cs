using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Server.Clases;
using Server.Clases.Base;

namespace Server.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        List<OnlineUser> users = new List<OnlineUser>();

        ICallBack Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<ICallBack>();
            }
        }

        public bool AddUsersToGroup(string AuthKey, int ID, List<int> IDs)
        {
            
            OnlineUser usr = users.FirstOrDefault((x) => x.AuthKey == AuthKey);
            if (usr != null)
                return usr.AddUsersToGroup(ID, IDs);
            return false;
        }

        public bool CreateGroup(string AuthKey, string Name)
        {
            OnlineUser usr = users.FirstOrDefault((x) => x.AuthKey == AuthKey);
            if (usr != null)
                return usr.CreateGroup(Name);
            return false;
        }

        public bool GetMessages(string AuthKey, int groupID, TypeGetMessage tgm, int count, out List<GroupMessage> grMsg)
        {
            grMsg = null;
            OnlineUser usr = users.FirstOrDefault((x) => x.AuthKey == AuthKey);
            if (usr != null)
                return usr.GetMessages(groupID, tgm, count, out grMsg);
            return false;
        }

        public bool GetMyGroups(string AuthKey, out Dictionary<Group, UserInGroup> group)
        {
            group = null;
            OnlineUser usr = users.FirstOrDefault((x) => x.AuthKey == AuthKey);
            if (usr != null)
                return usr.GetMyGroups(out group);
            return false;
        }

        public bool GetUsers(string AuthKey, TypeGetUsers tps, out List<User> usmr, int GroupID = 0)
        {
            usmr = null;
            OnlineUser usr = users.FirstOrDefault((x) => x.AuthKey == AuthKey);
            if (usr != null)
                return usr.GetUsers(tps,out usmr, GroupID);
            return false;
        }

        public bool Leave(string AuthKey)
        {
            OnlineUser usr = users.FirstOrDefault((x) => x.AuthKey == AuthKey);
            if (usr != null) 
                return users.Remove(usr);
            return false;
        }

        public bool Login(string Login, string Password, out User usr, out string authKey)
        {
            usr = null;
            authKey = null;
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatBase"].ConnectionString))
                {
                    usr = cnn.Query<User>($"SELECT * FROM Users WHERE Login = '{Login}' AND PasswordHash = '{Password.GetHashCode().ToString()}';").FirstOrDefault();
                    OnlineUser ss = new OnlineUser(Callback);
                    users.Add(ss);
                    authKey = ss.AuthKey;
                    return usr != null;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Register(string Login, string Password, out User usr)
        {
            usr = null;
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatBase"].ConnectionString))
                {
                    if (cnn.Query<User>($"SELECT TOP(1) ID FROM Users WHERE Login = '{Login}';").Count() == 0)
                    {
                        cnn.Query($"INSERT INTO Users VALUES ('{Login}', '{Password.GetHashCode().ToString()}', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 0 );");
                        usr = cnn.Query<User>($"SELECT * FROM Users WHERE Login = '{Login}' AND PasswordHash = '{Password.GetHashCode().ToString()}';").ToList().First();
                        return true;
                    }
                    else Callback.Error("User with Login = " + Login + " is already registered;");
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveGroup(string AuthKey, int ID)
        {
            throw new NotImplementedException();
        }

        public bool SendMessage(string AuthKey, int groupID, string message) {
            OnlineUser usr = users.FirstOrDefault((x) => x.AuthKey == AuthKey);
            if (usr != null)
                return usr.SendMessage(groupID, message);
            return false;
        }
    }
}
