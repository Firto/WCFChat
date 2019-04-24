
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using Client.ChatService;

namespace Client
{
    public delegate void LogIn(RUser usr);
    public delegate void Do();
    public delegate void MyGroups(Dictionary<RGroup, RUserInGroup> grps);
    [CallbackBehavior(UseSynchronizationContext = false)]
    public class MyCallback : ChatService.IChatServiceCallback
    {
        public event LogIn OnLogin;
        public event Do OnLeave;
        public event MyGroups OnReciveGroups;

        public void Error(string message)
        {
            MessageBox.Show(message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Message([MessageParameter(Name = "message")] string message1)
        {
            throw new System.NotImplementedException();
        }

        public void ReciveAddedUsers(RGroup group, Dictionary<RUser, RUserInGroup> users)
        {
            throw new System.NotImplementedException();
        }

        public void ReciveGetUsers(RUser[] usr)
        {
            throw new System.NotImplementedException();
        }

        public void ReciveLeave()
        {
            OnLeave?.Invoke();
        }

        public void ReciveLogin(RUser usr)
        {
            OnLogin?.Invoke(usr);
        }

        public void ReciveMyGroups(Dictionary<RGroup, RUserInGroup> group)
        {
            OnReciveGroups?.Invoke(group);
        }

        public void ReciveNewGroup(RGroup group)
        {
            throw new System.NotImplementedException();
        }

        public void ReciveNewMessage(RGroup group, RUser user, RGroupMessage msg)
        {
            throw new System.NotImplementedException();
        }

        public void ReciveRemoveGroup(RGroup group)
        {
            throw new System.NotImplementedException();
        }
    }
}
