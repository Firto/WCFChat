using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Client
{
    public delegate void SetPage(Page pg);

    public class ChatClient
    {
        public ChatService.ChatServiceClient client = new ChatService.ChatServiceClient(new InstanceContext(new MyCallback()));

        public ChatService.User usr;
        string authKey = String.Empty;
        public string AuthKey => authKey;

        List<Page> pages = new List<Page>();

        public event SetPage OnSetPage;

        public bool Login(string Login, string Password) {
            return client.Login(Login, Password, out usr, out authKey);
        }

        public void SetPage(Page pg) {
            if (pages.FirstOrDefault((x) => x.GetType().FullName == pg.GetType().FullName) != null)
                OnSetPage?.Invoke(pages.FirstOrDefault((x) => x.GetType().FullName == pg.GetType().FullName));
            else {
                pages.Add(pg);
                OnSetPage?.Invoke(pg);
            }

        }

        public bool Register(string Login, string Password)
        {
            return client.Register(Login, Password, out usr);
        }

        public bool GetMyGroups(out Dictionary<ChatService.Group, ChatService.UserInGroup> usrInGroup) {
            usrInGroup = null;
            return client.GetMyGroups(authKey, out usrInGroup);
        }

        public void Leave() {
            client.Leave(authKey);
            SetPage(new Login(this));
        }
    }
}
