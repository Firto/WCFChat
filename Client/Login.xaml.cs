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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        ChatClient Clin = null;
        public Login(ChatClient clin)
        {
            InitializeComponent();
            this.Clin = clin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text.Length < 1 || txtPass.Password.Length < 1) {  MessageBox.Show("Input all boxes!", "Login", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            if (!Clin.Login(txtLogin.Text, txtPass.Password)) { MessageBox.Show("Incorrect pass or login!", "Login", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            Clin.SetPage(new LoginedPage(Clin));
        }

        private void Button_Register(object sender, RoutedEventArgs e)
        {
            Clin.SetPage(new Register(Clin));
        }
    }
}
