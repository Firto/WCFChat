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
                if (value) plashkaLoading.Height = Double.NaN;
                else plashkaLoading.Height = 0;
            }
        }

        public GroupWrite(GroupItem itmn)
        {
            InitializeComponent();
            this.itmn = itmn;
            GetMessages();
        }

        public void GetMessages() {
            new Task(() => {
                IsLoading = true;
                int countMessages = itmn.client.Client.GetCountMessages(itmn.baseUserInGroup.Group.ID);
                if (countMessages < 1) return;
                RGroupMessage[] messages = itmn.client.Client.GetMessages(itmn.baseUserInGroup.Group.ID, true, countMessages > 30 ? 30 : countMessages, msges.Children.Count);
                if (messages == null || messages.Length < 1) return;

                foreach (var item in messages)
                    msges.Children.Add(new GroupMessage(item));

                IsLoading = false;
            }).Start();
            
        }

        private void SendMsg(object sender, RoutedEventArgs e)
        {
            itmn.client.Client.SendMessage(itmn.BaseUserInGroup.Group.ID, msg.Text);
        }

        public void ReciveMessage(ChatService.RGroupMessage msg) {
            msges.Children.Add(new GroupMessage(msg));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
