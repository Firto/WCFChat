using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Clases.Base
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DCreate { get; set; }
        public DateTime LastActivity { get; set; }
        public bool IsBlocked { get; set; }
    }
}
