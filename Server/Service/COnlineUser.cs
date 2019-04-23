using Server.Base;
using Server.Base.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service
{
    public class OnlineUser
    {
        public User BaseUser { get; private set; }
        public Context MainBase { get; set; }
        public List<OnlineUser> OnlineUsers { get; private set; }
        public IChatServiceCallBack CallBack { get; private set; }

        public OnlineUser(User baseUser, Context mainBase, List<OnlineUser> onlineUsers, IChatServiceCallBack callback) {
            BaseUser = baseUser;
            MainBase = mainBase;
            OnlineUsers = onlineUsers;
            CallBack = callback;

            callback.ReciveLogin(baseUser);
        }
    }
}
