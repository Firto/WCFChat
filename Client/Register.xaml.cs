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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        ChatClient clin = null;
        public Register(ChatClient clin)
        {
            InitializeComponent();
            this.clin = clin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text.Length < 1 || txtPass.Password.Length < 1 || txtPassR.Password != txtPass.Password)
                { MessageBox.Show("Incorrect inputed pass or login!", "Register", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (clin.Register(txtLogin.Text, txtPass.Password)) clin.SetPage(new Login(clin));
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            clin.SetPage(new Login(clin));
        }
    }
}
