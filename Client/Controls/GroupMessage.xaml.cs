﻿using System;
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

namespace Client.Controls
{
    /// <summary>
    /// Interaction logic for GroupMessage.xaml
    /// </summary>
    public partial class GroupMessage : UserControl
    {
        ChatService.RGroupMessage baseMsg;

        public GroupMessage(ChatService.RGroupMessage msg)
        {
            InitializeComponent();

            UserName.Content = msg.User.Login;
            Teext.Content = msg.MessageSource;

            baseMsg = msg;
        }
    }
}
