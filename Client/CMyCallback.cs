
using System.ServiceModel;
using System.Windows;

namespace Client
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public class MyCallback : ChatService.IChatServiceCallback
    {
        public void Error(string message)
        {
            MessageBox.Show(message);
        }
    }
}
