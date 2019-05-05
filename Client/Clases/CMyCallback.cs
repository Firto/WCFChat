
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using Client.ChatService;

namespace Client
{
    public delegate void UsrEv(RUser usr);
    public delegate void GroupEV(RGroup grp);
    public delegate void GroupEVT(RGroup group, RUserInGroup usrInGrp);
    public delegate void Do();
    public delegate void MyGroups(Dictionary<RGroup, RUserInGroup> grps);
    [CallbackBehavior(UseSynchronizationContext = false)]
    public class MyCallback : ChatService.IChatServiceCallback
    {
        public event UsrEv OnLogin;
        public event UsrEv OnChangeOnline;
        public event UsrEv OnNewUser;
        public event Do OnLeave;
        public event MyGroups OnReciveGroups;
        public event GroupEV OnReciveLeaveGroup;
        public event GroupEVT OnReciveNewGroup;

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

        public void ReciveNewGroup(RGroup group, RUserInGroup usrInGrp)
        {
            OnReciveNewGroup?.Invoke(group, usrInGrp);
        }

        public void ReciveNewMessage(RGroup group, RUser user, RGroupMessage msg)
        {
            throw new System.NotImplementedException();
        }

        public void ReciveLeaveGroup(RGroup group)
        {
            OnReciveLeaveGroup?.Invoke(group);
        }

        public void ReciveChangeOnline(RUser usr)
        {
            OnChangeOnline?.Invoke(usr);
        }

        public void ReciveNewUser(RUser usr)
        {
            OnNewUser?.Invoke(usr);
        }
    }
}
