﻿using Server.Base;
using Server.Base.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service
{
    public delegate void SDo(USession s);
    public delegate void OUDo(OnlineUser s);

    public class USession {

        public OnlineUser BaseOnlineUser { get; private set; }
        public IChatServiceCallBack Callback { get; private set; }
        public event SDo OnLeave;

        public USession(OnlineUser baseOnlineUser, IChatServiceCallBack callback)
        {
            BaseOnlineUser = baseOnlineUser;
            Callback = callback;
            ((ICommunicationObject)callback).Closed += Leave;
        }

        private void Leave(object obj, EventArgs e) {
            ((ICommunicationObject)Callback).Closed -= Leave;
            OnLeave?.Invoke(this);
        }

        public void Leave() {
            Callback.ReciveLeave();
            Leave(null, null);
        }

        public void LeaveFromGroup(int ID)
        {
            UserInGroup usrGrp = BaseOnlineUser.BaseUser.UsersInGroups.FirstOrDefault((x) => x.GroupID == ID);
            if (usrGrp != null)
            {
                Group grp = usrGrp.Group;
                if (usrGrp.RoleID == 1)
                {
                    Console.WriteLine("Remove group " + grp.Name + " by " + BaseOnlineUser.BaseUser.Login);
                    foreach (var item in BaseOnlineUser.OnlineUsers)
                    {
                        usrGrp = item.BaseUser.UsersInGroups.FirstOrDefault((x) => x.GroupID == ID);
                        if (usrGrp != null)
                        {
                            foreach (var ites in item.Sessions)
                                ites.Callback.ReciveLeaveGroup(new RGroup(grp));
                        }
                    }
                    BaseOnlineUser.MainBase.Groups.Remove(grp);
                }
                else
                {
                    Console.WriteLine("Leave group " + grp.Name + " by " + BaseOnlineUser.BaseUser.Login);
                    BaseOnlineUser.MainBase.UsersInGroups.Remove(usrGrp);
                    foreach (var ites in BaseOnlineUser.Sessions)
                        ites.Callback.ReciveLeaveGroup(new RGroup(grp));
                }
                BaseOnlineUser.MainBase.SaveChanges();
            }
            else Callback.ReciveLeaveGroup(new RGroup(new Group { ID = ID }));
        }

        public void CreateGroup(string Name, int[] IDs)
        {
            if (Name.Length < 1) { Callback.Error("Input group name!"); return; }
            if (BaseOnlineUser.MainBase.Groups.FirstOrDefault((x) => x.Name == Name && x.Deleted == false) != null) { Callback.Error("Group with this name is already registered!"); return; }

            Group newGrp = BaseOnlineUser.MainBase.Groups.Add(new Group { Name = Name, Deleted = false });
            UserInGroup usrInGrp = BaseOnlineUser.MainBase.UsersInGroups.Add(new UserInGroup { GroupID = newGrp.ID, UserID = BaseOnlineUser.BaseUser.ID, RoleID = 1, Muted = false });
            BaseOnlineUser.MainBase.SaveChanges();

            foreach (var item in BaseOnlineUser.Sessions)
                item.Callback.ReciveNewGroup(new RMUserInGroup(usrInGrp));

            if (IDs != null) AddUsersToGroup(newGrp.ID, IDs);

            return;
        }

        public void GetMyGroups()
        {
            List<RMUserInGroup> usersInGroups = new List<RMUserInGroup>();
            if (BaseOnlineUser.BaseUser.UsersInGroups != null) foreach (var item in BaseOnlineUser.BaseUser.UsersInGroups)
                    usersInGroups.Add(new RMUserInGroup(item));
            Callback.ReciveMyGroups(usersInGroups.ToArray());
        }

        public void AddUsersToGroup(int ID, int[] IDs)
        {
            UserInGroup usrGrp = BaseOnlineUser.BaseUser.UsersInGroups.FirstOrDefault((x) => x.GroupID == ID);
            if (usrGrp != null) {
                if (usrGrp.RoleID > 3) { Callback.Error("You are rab, you can't add new users!"); return; }
                List<UserInGroup> users = new List<UserInGroup>();
                User tmp;
                foreach (var item in IDs)
                {
                    
                    tmp = BaseOnlineUser.MainBase.Users.FirstOrDefault((x) => x.ID == item);
                    if (tmp == null) { Callback.Error("Incorrect user ID!"); return; }
                    if (null != tmp.UsersInGroups && tmp.UsersInGroups.FirstOrDefault((x) => x.GroupID == ID) != null) { Callback.Error("User already in this group ID!"); return; }
                    users.Add(BaseOnlineUser.MainBase.UsersInGroups.Add(new UserInGroup { GroupID = ID, UserID = item, FriendID = BaseOnlineUser.BaseUser.ID, RoleID = 4 }));
                }

                BaseOnlineUser.MainBase.SaveChanges();

                UserInGroup tomp;
                foreach (var item in BaseOnlineUser.OnlineUsers) {
                    tomp = users.FirstOrDefault((s) => s.User.ID == item.BaseUser.ID);
                    if (tomp != null)
                        foreach (var res in item.Sessions) res.Callback.ReciveNewGroup(new RMUserInGroup(tomp));
                } 

            }
            else Callback.ReciveLeaveGroup(new RGroup(new Group { ID = ID }));
        }

        public void SendMessage(int groupID, string message)
        {
            UserInGroup usrGrp = BaseOnlineUser.BaseUser.UsersInGroups.FirstOrDefault((x) => x.GroupID == groupID);

            if (usrGrp == null) { Callback.ReciveLeaveGroup(new RGroup(new Group { ID = groupID })); return; }
            if (message.Length < 1) return;

            GroupMessage msg = BaseOnlineUser.MainBase.GroupsMessages.Add(new GroupMessage { UserID = usrGrp.UserID, GroupID = usrGrp.GroupID, MessageSource = message });
            BaseOnlineUser.MainBase.SaveChanges();

            foreach (var item in BaseOnlineUser.OnlineUsers.Where((x) => x.BaseUser.UsersInGroups.FirstOrDefault((z) => z.GroupID == usrGrp.GroupID) != null))
                item.Sessions.ForEach((x) => x.Callback.ReciveNewMessage(new RUser(usrGrp.User, false ) ,new RGroupMessage(msg)));
        }

        public static USession GetSession(List<OnlineUser> usrs, IChatServiceCallBack callback)
        {
            foreach (var item in usrs)
                foreach (var somi in item.Sessions)
                    if (somi.Callback == callback) return somi;
            return null;
        }

    }

    public class OnlineUser
    {
        public List<OnlineUser> OnlineUsers { get; private set; }
        public List<USession> Sessions { get; private set; } = new List<USession>();
        public Context MainBase { get; private set; }
        public User BaseUser { get; private set; }

        public event SDo OnSessionLeave;
        public event OUDo OnUserLeave;

        public OnlineUser(User baseUser, Context mainBase, List<OnlineUser> onlineUsers) {
            BaseUser = baseUser;
            MainBase = mainBase;
            OnlineUsers = onlineUsers;

            onlineUsers.ForEach((x) => x.Sessions.ForEach((s) => s.Callback.ReciveChangeOnline(new RUser(baseUser, true))));
            Console.WriteLine("FLogin: " + baseUser.Login);
        }

        public void AddSession(USession sess) {
            if (Sessions.FirstOrDefault((x) => x.Callback == sess.Callback) == null)
            {
                sess.OnLeave += SessionLeave;
                Sessions.Add(sess);
                sess.Callback.ReciveLogin(new RUser(BaseUser, true));
                Console.WriteLine("SLogin: " + BaseUser.Login);
            }
        }

        private void SessionLeave(USession sees) {
            Sessions.Remove(sees);
            OnSessionLeave?.Invoke(sees);
            if (Sessions.Count < 1) OnUserLeave?.Invoke(this);
        }
    }
}
