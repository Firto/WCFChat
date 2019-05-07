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
        }

        public void GetMessages() {
            int count = msges.Children.Count;
            new Task(() => {
                IsLoading = true;
                int countMessages = itmn.client.Client.GetCountMessages(itmn.baseUserInGroup.Group.ID);
                if (countMessages > 0)
                {
                    Dictionary<RUser, RGroupMessage> messages = itmn.client.Client.GetMessages(itmn.baseUserInGroup.Group.ID, false, countMessages > 30 ? 30 : countMessages, count);
                    if (messages != null && messages.Count > 0)
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate {
                            foreach (var item in messages)
                                msges.Children.Add(new GroupMessage(item.Key, item.Value));
                        });
                        
                    }
                }
                IsLoading = false;
            }).Start();
            
        }

        private void SendMsg(object sender, RoutedEventArgs e)
        {
            itmn.client.Client.SendMessage(itmn.BaseUserInGroup.Group.ID, msg.Text);
        }

        public void ReciveMessage(RUser usr, RGroupMessage grpMsg) {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                bool isTo = MsgScrolls.VerticalOffset > MsgScrolls.ViewportHeight;
                msges.Children.Add(new GroupMessage(usr, grpMsg));
                if (isTo) MsgScrolls.ScrollToBottom();
            });
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
