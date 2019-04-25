﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Server.Base;
using Server.Base.Tables;

namespace Server.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, UseSynchronizationContext = false, ConcurrencyMode = ConcurrencyMode.Multiple)] // Створюється один клас ChatService для усіх юзерів
    public class ChatService : IChatService
    {
        IChatServiceCallBack Callback {
            get => OperationContext.Current.GetCallbackChannel<IChatServiceCallBack>();
        }

        Context mainbBase = new Context();

        List<OnlineUser> onlineUsers = new List<OnlineUser>();

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

        void IChatService.Register(string Login1, string Email, string Password, string repeatPassword)
        {
            string errMsg;
            if (Login1.Length < 1) { Callback.Error("Input login!"); return; }
            if (mainbBase.Users.FirstOrDefault((x) => x.Login == Login1) != null) { Callback.Error("User with this login is already exists!"); return; }
            if (Email.Length < 1) { Callback.Error("Input email!"); return; }
            if (!Common.IsOkEmail(Email)) { Callback.Error("Incorrect email!"); return; }
            if (mainbBase.Users.FirstOrDefault((x) => x.Email == Email) != null) { Callback.Error("User with this email is already exists!"); return; }
            if (!Common.IsOkPassword(Password, out errMsg)) { Callback.Error(errMsg); return; }
            if (repeatPassword != Password) { Callback.Error("Input correct repeat password!"); return; }

            string hasedPassword = Common.GetMD5(Password);

            lock (onlineUsers)
            {
                User usr = mainbBase.Users.Add(new Base.Tables.User { Login = Login1, PasswordHash = Common.GetMD5(Password), Email = Email, DCreate = DateTime.Now, LastActivity = DateTime.Now, Blocked = false });
                OnlineUser ussr = onlineUsers.FirstOrDefault((x) => x.BaseUser.ID == usr.ID);
                if (ussr == null)
                    onlineUsers.Add(new OnlineUser(usr, mainbBase, onlineUsers, Callback));
                else ussr.Sessions.Add(new USession(ussr, Callback));
                Console.WriteLine("Register: " + usr.Login);
                Console.WriteLine("Login: " + usr.Login);
            }
        }

        void IChatService.Login(string Login, string Password)
        {
            if (Login.Length < 1) { Callback.Error("Input login!"); return; }
            if (Password.Length < 1) { Callback.Error("Input password!"); return; }
            string hasedPassword = Common.GetMD5(Password);

            lock (onlineUsers)
            {
                User usr = mainbBase.Users.FirstOrDefault((x) => x.Login == Login && x.PasswordHash == hasedPassword);

                if (usr != null)
                {
                    OnlineUser ussr = onlineUsers.FirstOrDefault((x) => x.BaseUser.ID == usr.ID);
                    if (ussr == null)
                    {
                        onlineUsers.Add(new OnlineUser(usr, mainbBase, onlineUsers, Callback));
                        Console.WriteLine("FLogin: " + usr.Login);
                    }
                    else
                    {
                        ussr.Sessions.Add(new USession(ussr, Callback));
                        Console.WriteLine("SLogin: " + usr.Login);
                    }
                   
                }
                else Callback.Error("Incorrect password or login!");
            }
        }

        void IChatService.Leave()
        {
            lock (onlineUsers)
            {
                OnlineUser usr = onlineUsers.FirstOrDefault((x) => x.Sessions.FirstOrDefault((s) => s.Callback == Callback) != null);
                if (usr != null)
                {
                    USession uSes = usr.Sessions.FirstOrDefault((s) => s.Callback == Callback);
                    uSes.Callback.ReciveLeave();
                    
                    usr.Sessions.Remove(uSes);
                    if (usr.Sessions.Count < 1)
                    {
                        onlineUsers.Remove(usr);
                        Console.WriteLine("FLeave: " + usr.BaseUser.Login);
                    }
                    else Console.WriteLine("SLeave: " + usr.BaseUser.Login);
                }
            }
        }

        void IChatService.SendMessage(int groupID, string message)
        {
            throw new NotImplementedException();
        }

        int IChatService.GetCountUsers()
        {
            throw new NotImplementedException();
        }

        int IChatService.GetCountMessages(int groupID)
        {
            throw new NotImplementedException();
        }

        void IChatService.GetMyGroups()
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null) usen.GetMyGroups();
            else Callback.ReciveLeave();
        }

        void IChatService.CreateGroup(string Name)
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null) usen.CreateGroup(Name);
            else Callback.ReciveLeave();
        }

        void IChatService.LeaveGroup(int ID)
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null) usen.LeaveFromGroup(ID);
            else Callback.ReciveLeave();
        }

        void IChatService.AddUsersToGroup(int ID, List<int> IDs)
        {
            throw new NotImplementedException();
        }

        void IChatService.GetUsers(TypeGetUsers tps, int count, int offset, int GroupID)
        {
            throw new NotImplementedException();
        }

        void IChatService.GetMessages(int groupID, TypeGetMessage tgm, int count, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
