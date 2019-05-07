using Client.ChatService;
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

namespace Client.Pages
{
    /// <summary>
    /// Interaction logic for LoginedPage.xaml
    /// </summary>
    public partial class LoginedPage : Page
    {
        ChatClient clin;

        const int countGetUsers = 50;

        GroupCreateItem createGroupitem = null;

        public LoginedPage(ChatClient clin)
        {
            InitializeComponent();

            this.clin = clin;
            clin.Events.OnReciveGroups += OnReciveGroups;
            clin.Events.OnReciveLeaveGroup += OnLeaveGroup;
            clin.Events.OnReciveNewGroup += OnNewGroup;

            createGroupitem = new GroupCreateItem(clin, countGetUsers);
            createGroupitem.OnOk += OnCreateGroup;
            createGroupitem.OnCancel += OnCancelCreateGroup;
            
        }

        private void OnLeaveGroup(RGroup rgp) {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                
                foreach (UIElement item in ss.Children)
                {
                    if (item is GroupItem && ((GroupItem)item).BaseUserInGroup.Group.ID == rgp.ID) {
  
                        ss.Children.Remove(item);
                        break;
                    }
                }
            });
        }

        public void OnNewGroup(RMUserInGroup usrInGrp) {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                ss.Children.Add(new GroupItem(usrInGrp, clin, OnChangeSelectedGroup));
                OnCancelCreateGroup();
            });
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                clin.Client.GetMyGroups();
            }
            catch (Exception)
            {
            }
        }

        

        private void OnReciveGroups(RMUserInGroup[] grps) {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                ss.Children.Clear();
                foreach (var item in grps)
                    ss.Children.Add(new GroupItem(item, clin, OnChangeSelectedGroup));
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clin.Client.Leave();
            }
            catch (Exception)
            {
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void OnCreateGroup() {
            if (Common.UIElementCollectionToList(ss.Children).FirstOrDefault((x) => x is GroupCreateItem) != null)
                ss.Children.Remove(Common.UIElementCollectionToList(ss.Children).FirstOrDefault((x) => x is GroupCreateItem));
        }

        private void OnCancelCreateGroup() {
            if (Common.UIElementCollectionToList(ss.Children).FirstOrDefault((x) => x is GroupCreateItem) != null)
                ss.Children.Remove(Common.UIElementCollectionToList(ss.Children).FirstOrDefault((x) => x is GroupCreateItem));
        }

        private void Create_Group(object sender, RoutedEventArgs e)
        {
            if (Common.UIElementCollectionToList(ss.Children).FirstOrDefault((x) => x is GroupCreateItem) == null) ss.Children.Insert(0, createGroupitem);
            else ss.Children.Remove(Common.UIElementCollectionToList(ss.Children).FirstOrDefault((x) => x is GroupCreateItem));
        }

        public void OnChangeSelectedGroup(object obj, EventArgs e) {
            if (((GroupItem)obj).Selected) {
                writeMsg.Child = ((GroupItem)obj).WriteMessages;
                foreach (var item in ss.Children)
                {
                    if (item is GroupItem) {
                        GroupItem gss = (GroupItem)item;
                        if (gss.BaseUserInGroup.Group.ID != ((GroupItem)obj).BaseUserInGroup.Group.ID)
                            gss.Selected = false;
                    }
                }
            }
        }
    }
}
