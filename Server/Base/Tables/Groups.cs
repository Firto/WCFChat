using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Base.Tables
{
    public class Group
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ICollection<GroupMessage> GroupsMessages { get; set; }
        public virtual ICollection<UserInGroup> UsersInGroups { get; set; }
    }
}
