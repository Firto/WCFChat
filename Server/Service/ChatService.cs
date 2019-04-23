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
using Server.Clases.OnlineBase;

namespace Server.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] // Створюється один клас ChatService для усіх юзерів
    public class ChatService : IChatService
    {
        IChatServiceCallBack Callback {
            get => OperationContext.Current.GetCallbackChannel<IChatServiceCallBack>();
        }

        List<OnlineUser> users = new List<OnlineUser>();
        List<OnlineGroup> groups = new List<OnlineGroup>();

        //void Register(string Login, string Password) {
        //    //usr = null;
        //    //try
        //    //{
        //    //    using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatBase"].ConnectionString))
        //    //    {
        //    //        if (cnn.Query<User>($"SELECT TOP(1) ID FROM Users WHERE Login = '{Login}';").Count() == 0)
        //    //        {
        //    //            cnn.Query($"INSERT INTO Users VALUES ('{Login}', '{Password.GetHashCode().ToString()}', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 0 );");
        //    //            usr = cnn.Query<User>($"SELECT * FROM Users WHERE Login = '{Login}' AND PasswordHash = '{Password.GetHashCode().ToString()}';").ToList().First();
        //    //            return true;
        //    //        }
        //    //        else Callback.Error("User with Login = " + Login + " is already registered;");
        //    //    }
        //    //    return false;
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    return false;
        //    //}
        //}

        //void Login(string Login, string Password) {
        //    //usr = null;
        //    //authKey = null;
        //    //try
        //    //{
        //    //    using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatBase"].ConnectionString))
        //    //    {
        //    //        usr = cnn.Query<User>($"SELECT * FROM Users WHERE Login = '{Login}' AND PasswordHash = '{Password.GetHashCode().ToString()}';").FirstOrDefault();
        //    //        OnlineUser ss = new OnlineUser(Callback);
        //    //        users.Add(ss);
        //    //        authKey = ss.AuthKey;
        //    //        return usr != null;
        //    //    }
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    return false;
        //    //}
        //}

        //void Leave(string AuthKey) {
        //    throw new NotImplementedException();
        //}

        //void SendMessage(string AuthKey, int groupID, string message) {
        //    throw new NotImplementedException();
        //}

        //void AddUsersToGroup(string AuthKey, int ID, List<int> IDs)
        //{
        //    throw new NotImplementedException();
        //}

        //void CreateGroup(string AuthKey, string Name) {
        //    throw new NotImplementedException();
        //}

        //void GetMessages(string AuthKey, int groupID, TypeGetMessage tgm, int count, int offcet){
        //    throw new NotImplementedException();
        //}

        //void GetMyGroups(string AuthKey){
        //    throw new NotImplementedException();
        //}

        //void GetUsers(string AuthKey, TypeGetUsers tps, int count, int offcet, int GroupID = 0){
        //    throw new NotImplementedException();
        //}

        //int GetCountUsers(string AuthKey) {
        //    throw new NotImplementedException();
        //}

        //int GetCountMessages(string AuthKey, int groupID) {
        //    throw new NotImplementedException();
        //}

        //void RemoveGroup(string AuthKey, int ID) {
        //    throw new NotImplementedException();
        //}

        void IChatService.Register(string Login, string Password)
        {
            throw new NotImplementedException();
        }

        void IChatService.Login(string Login, string Password)
        {
            throw new NotImplementedException();
        }

        void IChatService.Leave(string AuthKey)
        {
            throw new NotImplementedException();
        }

        void IChatService.SendMessage(string AuthKey, int groupID, string message)
        {
            throw new NotImplementedException();
        }

        int IChatService.GetCountUsers(string AuthKey)
        {
            throw new NotImplementedException();
        }

        int IChatService.GetCountMessages(string AuthKey, int groupID)
        {
            throw new NotImplementedException();
        }

        void IChatService.GetMyGroups(string AuthKey)
        {
            throw new NotImplementedException();
        }

        void IChatService.CreateGroup(string AuthKey, string Name)
        {
            throw new NotImplementedException();
        }

        void IChatService.RemoveGroup(string AuthKey, int ID)
        {
            throw new NotImplementedException();
        }

        void IChatService.AddUsersToGroup(string AuthKey, int ID, List<int> IDs)
        {
            throw new NotImplementedException();
        }

        void IChatService.GetUsers(string AuthKey, TypeGetUsers tps, int count, int offset, int GroupID)
        {
            throw new NotImplementedException();
        }

        void IChatService.GetMessages(string AuthKey, int groupID, TypeGetMessage tgm, int count, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
