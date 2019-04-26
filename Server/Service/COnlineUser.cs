using Server.Base;
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
            callback.ReciveLogin(new RUser(baseOnlineUser.BaseUser));
            Console.WriteLine("SLogin: " + baseOnlineUser.BaseUser.Login);
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
            lock (BaseOnlineUser.MainBase)
            {
                UserInGroup usrGrp = BaseOnlineUser.BaseUser.UsersInGroups.FirstOrDefault((x) => x.UserID == BaseOnlineUser.BaseUser.ID);
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
                                foreach (var ites in BaseOnlineUser.Sessions)
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
        }

        public void CreateGroup(string Name)
        {
            lock (BaseOnlineUser.MainBase)
            {
                if (Name.Length < 1) { Callback.Error("Input group name!"); return; }
                if (BaseOnlineUser.MainBase.Groups.FirstOrDefault((x) => x.Name == Name && x.Deleted == false) != null) { Callback.Error("Group with this name is already registered!");  return; }

                Group newGrp = BaseOnlineUser.MainBase.Groups.Add(new Group { Name = Name, Deleted = false });
                UserInGroup usrInGrp = BaseOnlineUser.MainBase.UsersInGroups.Add(new UserInGroup { GroupID = newGrp.ID, UserID = BaseOnlineUser.BaseUser.ID, RoleID = 1, Muted = false });
                BaseOnlineUser.MainBase.SaveChanges();

                foreach (var item in BaseOnlineUser.Sessions)
                    item.Callback.ReciveNewGroup(new RGroup(newGrp), new RUserInGroup(usrInGrp));
            }
        }

        public void GetMyGroups()
        {
            lock (BaseOnlineUser.MainBase)
            {
                Dictionary<RGroup, RUserInGroup> usersInGroups = new Dictionary<RGroup, RUserInGroup>();
                foreach (var item in BaseOnlineUser.BaseUser.UsersInGroups)
                    usersInGroups.Add(new RGroup(item.Group), new RUserInGroup(item));
                Callback.ReciveMyGroups(usersInGroups);
            }
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

        public OnlineUser(User baseUser, Context mainBase, List<OnlineUser> onlineUsers, IChatServiceCallBack callback) {
            BaseUser = baseUser;
            MainBase = mainBase;
            OnlineUsers = onlineUsers;
            AddSession(new USession(this, callback));

            Console.WriteLine("FLogin: " + baseUser.Login);
        }

        public void AddSession(USession sess) {
            if (Sessions.FirstOrDefault((x) => x.Callback == sess.Callback) == null)
            {
                sess.OnLeave += SessionLeave;
                Sessions.Add(sess);
            }
        }

        private void SessionLeave(USession sees) {
            Sessions.Remove(sees);
            OnSessionLeave?.Invoke(sees);
            if (Sessions.Count < 1) OnUserLeave?.Invoke(this);
        }
    }
}
