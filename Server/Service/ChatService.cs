using System;
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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] // Створюється один клас ChatService для усіх юзерів
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

            mainbBase.Users.Add(new Base.Tables.User { Login = Login1, PasswordHash = Common.GetMD5(Password), Email = Email, DCreate = DateTime.Now, LastActivity = DateTime.Now, Blocked = false });
            mainbBase.SaveChanges();
            User usr = mainbBase.Users.FirstOrDefault((x) => x.Login == Login1 && x.PasswordHash == hasedPassword);
            OnlineUser ussr = onlineUsers.FirstOrDefault((x) => x.BaseUser.ID == usr.ID);
            if (ussr == null)
            {
                ussr = new OnlineUser(usr, mainbBase, onlineUsers);
                ussr.OnUserLeave += LeaveOnlineUser;
                ussr.OnSessionLeave += LeaveUserSession;
                onlineUsers.Add(ussr);
                ussr.AddSession(new USession(ussr, Callback));
            }
            else ussr.AddSession(new USession(ussr, Callback));
        }

        void IChatService.Login(string Login, string Password)
        {
            if (Login.Length < 1) { Callback.Error("Input login!"); return; }
            if (Password.Length < 1) { Callback.Error("Input password!"); return; }
            string hasedPassword = Common.GetMD5(Password);

            User usr = mainbBase.Users.FirstOrDefault((x) => x.Login == Login && x.PasswordHash == hasedPassword);

            if (usr != null)
            {
                OnlineUser ussr = onlineUsers.FirstOrDefault((x) => x.BaseUser.ID == usr.ID);
                if (ussr == null)
                {
                    ussr = new OnlineUser(usr, mainbBase, onlineUsers);
                    ussr.OnUserLeave += LeaveOnlineUser;
                    ussr.OnSessionLeave += LeaveUserSession;
                    onlineUsers.Add(ussr);
                    ussr.AddSession(new USession(ussr, Callback));
                }
                else ussr.AddSession(new USession(ussr, Callback));

            }
            else Callback.Error("Incorrect password or login!");
        }

        void LeaveOnlineUser(OnlineUser usr) { // Event
            onlineUsers.Remove(usr);
            onlineUsers.ForEach((x) => x.Sessions.ForEach((s) => s.Callback.ReciveChangeOnline(new RUser(usr.BaseUser, false))));
            Console.WriteLine("FLeave: " + usr.BaseUser.Login);
        }

        void LeaveUserSession(USession ussi) // Event
        {
            Console.WriteLine("SLeave: " + ussi.BaseOnlineUser.BaseUser.Login);
           
        }

        void IChatService.Leave()
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null) usen.Leave();
            else Callback.ReciveLeave();
        }

        void IChatService.SendMessage(int groupID, string message)
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null) usen.SendMessage(groupID, message);
            else Callback.ReciveLeave();
        }

        int IChatService.GetCountUsers()
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null) return mainbBase.Users.Count() - 1;
            else { Callback.ReciveLeave(); return -1; }
        }

        int IChatService.GetCountUsersInGroup(int groupID)
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null)
            {
                Group grp = usen.BaseOnlineUser.BaseUser.UsersInGroups.FirstOrDefault((x) => x.GroupID == groupID)?.Group;
                if (grp != null) return grp.UsersInGroups.Count - 1;
                else
                {
                    Callback.Error("Incorrect group!");
                    Callback.ReciveLeaveGroup(new RGroup(new Group { ID = groupID }));
                    return -1;
                }
            }
            else { Callback.ReciveLeave(); return -1; }
        }

        int IChatService.GetCountMessages(int groupID)
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null)
            {
                Group grp = usen.BaseOnlineUser.BaseUser.UsersInGroups.FirstOrDefault((x) => x.GroupID == groupID)?.Group;
                if (grp != null) return grp.GroupsMessages.Count;
                else
                {
                    Callback.Error("Incorrect group!");
                    Callback.ReciveLeaveGroup(new RGroup(new Group { ID = groupID }));
                    return -1;
                }
            }
            else { Callback.ReciveLeave(); return -1; }
        }

        void IChatService.GetMyGroups()
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null) usen.GetMyGroups();
            else Callback.ReciveLeave();
        }

        void IChatService.CreateGroup(string Name, int[] IDs)
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null) usen.CreateGroup(Name, IDs);
            else Callback.ReciveLeave();

        }

        void IChatService.LeaveGroup(int ID)
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null) usen.LeaveFromGroup(ID);
            else Callback.ReciveLeave();
        }

        void IChatService.AddUsersToGroup(int ID, int[] IDs)
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null) usen.AddUsersToGroup(ID, IDs);
            else Callback.ReciveLeave();
        }

        RUser[] IChatService.GetUsers(int offset, int count)
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null)
            {

                IQueryable<User> users = mainbBase.Users.Where((x) => x.ID != usen.BaseOnlineUser.BaseUser.ID);
                if (offset > users.Count()) { Callback.Error("Incorrect offcet!"); return null; }
                if (offset > 0) users = users.Skip(offset);
                if (count > users.Count()) { Callback.Error("Incorrect count!"); return null; }
                if (count > 0) users.Take(count);
                List<RUser> rusers = new List<RUser>();
                foreach (var item in users)
                    rusers.Add(new RUser(item, false));
                return rusers.ToArray();
            }
            else { Callback.ReciveLeave(); return null; }
        }

        Dictionary<RUser, RGroupMessage> IChatService.GetMessages(int groupID, bool reverced, int count, int offset)
        {
            USession usen = USession.GetSession(onlineUsers, Callback);
            if (usen != null) {
                Group grp = usen.BaseOnlineUser.BaseUser.UsersInGroups.FirstOrDefault((x) => x.GroupID == groupID)?.Group;
                if (grp != null) {
                    List<GroupMessage> messages = grp.GroupsMessages.ToList();
                    if (reverced) messages.Reverse();
                    if (offset > messages.Count()) { Callback.Error("Incorrect offcet!"); return null; }
                    if (offset > 0) messages = messages.Skip(offset).ToList();
                    if (count > messages.Count()) { Callback.Error("Incorrect count!"); return null; }
                    if (count > 0) messages = messages.Take(count).ToList();
                    Dictionary<RUser, RGroupMessage> rmessages = new Dictionary<RUser, RGroupMessage>();
                    foreach (var item in messages)
                        rmessages.Add(new RUser(item.User, false), new RGroupMessage(item));
                    if (reverced) messages.Reverse();
                    return rmessages;
                }
                else
                {
                    Callback.Error("Incorrect group!");
                    Callback.ReciveLeaveGroup(new RGroup(new Group { ID = groupID }));
                    return null;
                }
            }
            else { Callback.ReciveLeave(); return null; }
        }
    }
}
