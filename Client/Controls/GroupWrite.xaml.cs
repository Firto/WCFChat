using Client.ChatService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.Controls
{
    /// <summary>
    /// Interaction logic for GroupWrite.xaml
    /// </summary>
    public partial class GroupWrite : UserControl
    {
        GroupItem itmn;
        //List<RUser> outsiders = new List<RUser>(); 
        public EventHandler OnLoading;

        public bool IsLoading
        {
            get => plashkaLoading.Height != 0;
            set {
                Application.Current.Dispatcher.Invoke((Action)delegate {
                    if (value) plashkaLoading.Height = Double.NaN;
                    else plashkaLoading.Height = 0;
                });
            }
        }

        public GroupWrite(GroupItem itmn)
        {
            InitializeComponent();
            this.itmn = itmn;
            GetMessages();
            
            MsgScrolls.ScrollToBottom();
            GetOutsiders();
           
        }

        public void GetMessages() {
            int count = msges.Children.Count-1;
            new Task(() => {
                IsLoading = true;
                int countMessages = itmn.client.Client.GetCountMessages(itmn.baseUserInGroup.Group.ID);
                if (countMessages - count > 0)
                {
                    Dictionary<RUser, RGroupMessage> messages = itmn.client.Client.GetMessages(itmn.baseUserInGroup.Group.ID, true, countMessages - count > 30 ? 30 : countMessages - count, count);
                    if (messages != null && messages.Count > 0)
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate {
                            foreach (var item in messages)
                                msges.Children.Insert(0, new GroupMessage(item.Key, item.Value));
                            itmn.SetExample(new GroupMessageMini(((GroupMessage)msges.Children[msges.Children.Count - 2]).baseUsr, ((GroupMessage)msges.Children[msges.Children.Count - 2]).baseMsg));
                            
                        });
                        
                    }
                }
                IsLoading = false;
            }).Start();
            
        }

        private void GetOutsiders()
        {
            new Task(() => {
                RUser[] users = itmn.client.Client.GetUsersOutGroup(itmn.baseUserInGroup.Group.ID, -1, -1);
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    foreach (var item in users)
                        canAddUsers.Children.Add(new CCheckUserItem(item));
                });
            }).Start();

        }

        private void SendMsg(object sender, RoutedEventArgs e)
        {
            itmn.client.Client.SendMessage(itmn.BaseUserInGroup.Group.ID, msg.Text);
            msg.Text = String.Empty;
        }

        public void ReciveMessage(RUser usr, RGroupMessage grpMsg) {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                bool isTo = MsgScrolls.VerticalOffset + 20 >= MsgScrolls.ViewportHeight;
                itmn.SetExample(new GroupMessageMini(usr, grpMsg));
                msges.Children.Insert(msges.Children.Count - 1, new GroupMessage(usr, grpMsg));
                if (isTo) MsgScrolls.ScrollToBottom();
            });
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Msg_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) SendMsg(null, null);
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            anim.Begin();
        }

        private void MsgScrolls_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (MsgScrolls.VerticalOffset == 0 && IsLoading == false) GetMessages();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (hidenBox.Visibility != Visibility.Visible)
            {
                hidenBox.Visibility = Visibility.Visible;
                mainItems.Children.Remove(AddUsersItem);
                mainItems.Visibility = Visibility.Collapsed;
                mainMain.Children.Add(AddUsersItem);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ExitFromAddUsers(object sender, RoutedEventArgs e)
        {
            if (hidenBox.Visibility != Visibility.Collapsed)
            {
                hidenBox.Visibility = Visibility.Collapsed;
                mainMain.Children.Remove(AddUsersItem);
                mainItems.Visibility = Visibility.Visible;
                mainItems.Children.Add(AddUsersItem);
            }
        }
    }
}
