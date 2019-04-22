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
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Dictionary<ChatService.Group, ChatService.UserInGroup> som;
            if (clin.GetMyGroups(out som)) {
                foreach (var item in som)
                {
                    ss.Children.Add(new GroupItem(item.Key, item.Value, clin));
                }

            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clin.Leave();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Create_Group(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
