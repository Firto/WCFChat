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
        ChatService.RGroup baseGroup;
        ChatService.RUserInGroup baseUserInGroup;

        public ChatService.RGroup BaseGroup { get => baseGroup; set {
                baseGroup = value;
                ItemWithName.Content = baseGroup.Name;
            } }

        public ChatService.RUserInGroup BaseUserInGroup { get => baseUserInGroup; set {
                baseUserInGroup = value;
            } }

        public GroupItem(ChatService.RGroup grp, ChatService.RUserInGroup usr, ChatClient cl)
        {
            InitializeComponent();
            client = cl;
            BaseGroup = grp;
            BaseUserInGroup = usr;
        }

        public void SendMessage() {

        }

    }
}
