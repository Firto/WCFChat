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
        }

        private void OnLeaveGroup(RGroup rgp) {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                foreach (GroupItem item in ss.Children)
                {
                    if (item.BaseGroup.ID == rgp.ID) {
                        ss.Children.Remove(item);
                        break;
                    }
                }
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
                List<UIElement> elmnts = UIElementCollectionToList(ss.Children);
                GroupItem itmn = null;
                foreach (var item in grps)
                {
                    itmn = (GroupItem)elmnts.FirstOrDefault((x) => ((GroupItem)x).BaseGroup.ID == item.Key.ID);
                    if (itmn == null) ss.Children.Add(new GroupItem(item.Key, item.Value, clin));
                    else
                    {
                        itmn.BaseGroup = item.Key;
                        itmn.BaseUserInGroup = item.Value;
                    }
                }
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

        private void Create_Group(object sender, RoutedEventArgs e)
        {
            try
            {
                clin.Client.CreateGroup("Soewrmatic");
            }
            catch (Exception)
            {
            }
            
        }
    }
}
