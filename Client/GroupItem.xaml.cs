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

namespace Client
{
    /// <summary>
    /// Interaction logic for GroupItem.xaml
    /// </summary>
    public partial class GroupItem : UserControl
    {
        ChatClient client;
        ChatService.Group grp;
        ChatService.UserInGroup usr;

        public GroupItem(ChatService.Group grp, ChatService.UserInGroup usr, ChatClient cl)
        {
            InitializeComponent();
            client = cl;
            this.grp = grp;
            this.usr = usr;
            ItemWithName.Content = grp.Name;
        }

        public void SendMessage() {

        }


    }
}
