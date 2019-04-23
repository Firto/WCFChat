
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using Client.ChatService;

namespace Client
{
    public delegate void LogIn(User usr);
    public delegate void Do();

    [CallbackBehavior(UseSynchronizationContext = false)]
    public class MyCallback : ChatService.IChatServiceCallback
    {
        public event LogIn OnLogin;
        public event Do OnLeave;

        public void Error(string message)
        {
            MessageBox.Show(message);
        }

        public void Message([MessageParameter(Name = "message")] string message1)
        {
            throw new System.NotImplementedException();
        }

        public void ReciveAddedUsers(Group group, Dictionary<User, UserInGroup> users)
        {
            throw new System.NotImplementedException();
        }

        public void ReciveGetUsers(User[] usr)
        {
            throw new System.NotImplementedException();
        }

        public void ReciveLeave()
        {
            OnLeave?.Invoke();
        }

        public void ReciveLogin(User usr)
        {
            OnLogin?.Invoke(usr);
        }

        public void ReciveMyGroups(Dictionary<Group, UserInGroup> group)
        {
            throw new System.NotImplementedException();
        }

        public void ReciveNewGroup(Group group)
        {
            throw new System.NotImplementedException();
        }

        public void ReciveNewMessage(Group group, User user, GroupMessage msg)
        {
            throw new System.NotImplementedException();
        }

        public void ReciveRemoveGroup(Group group)
        {
            throw new System.NotImplementedException();
        }
    }
}
