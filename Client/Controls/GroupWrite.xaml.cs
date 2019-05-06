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
        public GroupWrite(GroupItem itmn)
        {
            InitializeComponent();
            this.itmn = itmn;
        }

        private void SendMsg(object sender, RoutedEventArgs e)
        {
            itmn.client.Client.SendMessage(itmn.BaseUserInGroup.Group.ID, msg.Text);
        }

        public void ReciveMessage(ChatService.RGroupMessage msg) {
            msges.Children.Add(new GroupMessage(msg));
        }
    }
}
