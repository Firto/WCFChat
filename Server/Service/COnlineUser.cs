using Server.Base;
using Server.Base.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service
{
    public class USession {

        public OnlineUser BaseOnlineUser { get; private set; }
        public IChatServiceCallBack Callback { get; private set; }

        public USession(OnlineUser baseOnlineUser, IChatServiceCallBack callback)
        {
            BaseOnlineUser = baseOnlineUser;
            Callback = callback;

            callback.ReciveLogin(new RUser(baseOnlineUser.BaseUser));
        }

        public void LeaveFromGroup(int ID)
        {
            UserInGroup usrGrp = BaseOnlineUser.BaseUser.UsersInGroups.FirstOrDefault((x) => x.UserID == BaseOnlineUser.BaseUser.ID);
            if (usrGrp != null)
            {
                Group grp = usrGrp.Group;
                if (usrGrp.RoleID == 1)
                {
                    Console.WriteLine("Remove group " + grp.Name + " by " + BaseOnlineUser.BaseUser.Login);
                    grp.Deleted = true;
                    foreach (var item in BaseOnlineUser.OnlineUsers)
                    {
                        usrGrp = item.BaseUser.UsersInGroups.FirstOrDefault((x) => x.GroupID == ID);
                        if (usrGrp != null)
                        {
                            BaseOnlineUser.MainBase.UsersInGroups.Remove(usrGrp);
                            foreach (var ites in BaseOnlineUser.Sessions)
                                ites.Callback.ReciveLeaveGroup(new RGroup(grp));
                        }
                    }
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
            else Callback.Error("Incorrect group!");
        }

        public void CreateGroup(string Name)
        {
            if (BaseOnlineUser.MainBase.Groups.FirstOrDefault((x) => x.Name == Name && x.Deleted == false) == null)
            {
                Group newGrp = BaseOnlineUser.MainBase.Groups.Add(new Group { Name = Name, Deleted = false });
                UserInGroup usrInGrp = BaseOnlineUser.MainBase.UsersInGroups.Add(new UserInGroup { GroupID = newGrp.ID, UserID = BaseOnlineUser.BaseUser.ID, RoleID = 1, Muted = false });
                BaseOnlineUser.MainBase.SaveChanges();

                foreach (var item in BaseOnlineUser.Sessions)
                    item.Callback.ReciveNewGroup(new RGroup(newGrp), new RUserInGroup(usrInGrp));
            }
            else Callback.Error("Group with this name is already registered!");
        }

        public void GetMyGroups()
        {
            Dictionary<RGroup, RUserInGroup> usersInGroups = new Dictionary<RGroup, RUserInGroup>();
            foreach (var item in BaseOnlineUser.BaseUser.UsersInGroups)
                usersInGroups.Add(new RGroup(item.Group), new RUserInGroup(item));
            Callback.ReciveMyGroups(usersInGroups);
        }

        public static USession GetSession(List<OnlineUser> usrs, IChatServiceCallBack callback) {
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

        public OnlineUser(User baseUser, Context mainBase, List<OnlineUser> onlineUsers, IChatServiceCallBack callback) {
            BaseUser = baseUser;
            MainBase = mainBase;
            OnlineUsers = onlineUsers;
            Sessions.Add(new USession(this, callback));
        }
    }
}
