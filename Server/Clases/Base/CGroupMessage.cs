using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Clases.Base
{
    public class GroupMessage
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public string MessageSource { get; set; }
        public bool Deleted { get; set; }
    }
}
