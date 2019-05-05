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

        bool selected = false;

        public bool Selected {
            get => selected;
            set {
                if (value) mns.Background = new SolidColorBrush(Color.FromArgb(255, 179, 188, 243));
                else mns.Background = new SolidColorBrush(Color.FromArgb(255, 179, 211, 243));
                OnChangeSelecte?.Invoke(value, null);
                selected = value;
            }
        }

        public event EventHandler OnChangeSelecte;

        public ChatService.RGroup BaseGroup { get => baseGroup; set {
                baseGroup = value;
                ItemWithName.Content = baseGroup.Name;
            } }

        public ChatService.RUserInGroup BaseUserInGroup { get => baseUserInGroup; set {
                baseUserInGroup = value;
            } }

        public GroupItem(ChatService.RGroup grp, ChatService.RUserInGroup usr, ChatClient cl, EventHandler evnt)
        {
            InitializeComponent();
            client = cl;
            BaseGroup = grp;
            BaseUserInGroup = usr;
            OnChangeSelecte += evnt;
        }

        public void SendMessage() {

        }

        private void ExitFromGroup(object sender, RoutedEventArgs e)
        {
            if (baseUserInGroup.RoleID == 1)
            {
                if (MessageBox.Show("Are you sure delete group", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel) == MessageBoxResult.Cancel) return;
            }else if (MessageBox.Show("Are you sure leave group", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel) == MessageBoxResult.Cancel) return;

            try
            {
                client.Client.LeaveGroup(baseGroup.ID);
            }
            catch (Exception)
            {

               
            }
            
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            if (!Selected) Selected = true;
        }
    }
}
