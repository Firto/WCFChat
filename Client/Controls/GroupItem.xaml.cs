﻿using Client.ChatService;
using Client.Controls;
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
        public ChatClient client;
        public ChatService.RMUserInGroup baseUserInGroup;
        public GroupWrite WriteMessages { get; private set; }
        public List<RMUserInGroup> users = new List<RMUserInGroup>();
        bool selected = false;

        public bool Selected {
            get => selected;
            set {
                if (value) mns.Background = new SolidColorBrush(Color.FromArgb(255, 179, 188, 243));
                else mns.Background = new SolidColorBrush(Color.FromArgb(255, 179, 211, 243));
                selected = value;
                OnChangeSelecte?.Invoke(this, null);
            }
        }

        public event EventHandler OnChangeSelecte;

        public ChatService.RMUserInGroup BaseUserInGroup { get => baseUserInGroup; set {
                ItemWithName.Content = value.Group.Name;
                baseUserInGroup = value;
            } }

        public GroupItem(ChatService.RMUserInGroup usr, ChatClient cl, EventHandler evnt)
        {
            InitializeComponent();
            client = cl;
            BaseUserInGroup = usr;
            OnChangeSelecte += evnt;
            WriteMessages = new GroupWrite(this);

            GetUsers();
        }

        private void GetUsers() {
            new Task(() => {
                users.AddRange(client.Client.GetUsersInGroup(baseUserInGroup.Group.ID, -1, -1));
            }).Start();
        }

        private void ExitFromGroup(object sender, RoutedEventArgs e)
        {
            if (baseUserInGroup.Role.Name == "Creator")
            {
                if (MessageBox.Show("Are you sure delete group", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel) == MessageBoxResult.Cancel) return;
            }else if (MessageBox.Show("Are you sure leave group", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel) == MessageBoxResult.Cancel) return;

            try
            {
                client.Client.LeaveGroup(baseUserInGroup.Group.ID);
            }
            catch (Exception)
            {

               
            }
            
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            if (!Selected) Selected = true;
        }

        public void ReciveMessage(RUser usr, RGroupMessage grp) {
            WriteMessages.ReciveMessage(usr, grp);
        }

        public void SetExample(UIElement control) {
            status.Child = control;
        }

        public void OnChangeOnline(RUser user)
        {
            int i = 0; for (; i < users.Count; i++)
                if (users[i].User.ID == user.ID)
                {
                    users[i].User.Online = user.Online;
                    break;
                }
        }

        public void OnNewUsers(RMUserInGroup[] userss)
        {
            foreach (var user in userss)
            {
                if (users.FirstOrDefault((x) => x.User.ID == user.User.ID) == null)
                    users.Add(user);
            }
        }

        private void GetUsersOutGroup()
        {
           
        }
    }
}
