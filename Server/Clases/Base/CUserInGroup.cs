using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Clases.Base
{
    public class UserInGroup
    {
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public int RoleID { get; set; }
        public bool Muted { get; set; }
    }
}
