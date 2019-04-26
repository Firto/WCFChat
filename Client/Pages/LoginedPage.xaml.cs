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

namespace Client
{
    /// <summary>
    /// Interaction logic for LoginedPage.xaml
    /// </summary>
    public partial class LoginedPage : Page
    {
        ChatClient clin;
        public LoginedPage(ChatClient clin)
        {
            InitializeComponent();
            this.clin = clin;
            clin.Events.OnReciveGroups += OnReciveGroups;
            clin.Events.OnReciveLeaveGroup += OnLeaveGroup;
            clin.Events.OnReciveNewGroup += OnNewGroup;
        }

        private void OnLeaveGroup(RGroup rgp) {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                
                foreach (UIElement item in ss.Children)
                {
                    if (item is GroupItem && ((GroupItem)item).BaseGroup.ID == rgp.ID) {
  
                        ss.Children.Remove(item);
                        break;
                    }
                }
            });
        }

        public void OnNewGroup(RGroup rgp, RUserInGroup usrInGrp) {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                ss.Children.Add(new GroupItem(rgp, usrInGrp, clin, OnChangeSelectedGroup));
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

        private List<UIElement> UIElementCollectionToList(UIElementCollection collection) {
            List<UIElement> elmnts = new List<UIElement>();
            foreach (UIElement item in collection)
                elmnts.Add(item);
            return elmnts;
        }

        private void OnReciveGroups(Dictionary<RGroup, RUserInGroup> grps) {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                ss.Children.Clear();
                foreach (var item in grps)
                    ss.Children.Add(new GroupItem(item.Key, item.Value, clin, OnChangeSelectedGroup));
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
            GroupCreateItem som = (GroupCreateItem)UIElementCollectionToList(ss.Children).FirstOrDefault((x) => x is GroupCreateItem);
            if (som != null)
            {
                try
                {
                    clin.Client.CreateGroup(som.groupName.Text);
                }
                catch (Exception) {

                }
            }
        }

        private void OnCancelCreateGroup() {
            GroupCreateItem som = (GroupCreateItem)UIElementCollectionToList(ss.Children).FirstOrDefault((x) => x is GroupCreateItem);
            if (som != null) ss.Children.Remove(som);
        }

        private void Create_Group(object sender, RoutedEventArgs e)
        {
            if (UIElementCollectionToList(ss.Children).FirstOrDefault((x) => x is GroupCreateItem) == null)
            {
                GroupCreateItem som = new GroupCreateItem();
                som.OnOk += OnCreateGroup;
                som.OnCancel += OnCancelCreateGroup;
                ss.Children.Insert(0, som);
            }
            else OnCancelCreateGroup();
        }

        public void OnChangeSelectedGroup(object obj, EventArgs e) {
            if (((bool)obj)) {
                foreach (var item in ss.Children)
                {
                    if (item is GroupItem) {
                        GroupItem gss = (GroupItem)item;
                        if (gss.Selected)
                        {
                            gss.Selected = false;
                            break;
                        }
                    }
                }
            }
        }
    }
}
