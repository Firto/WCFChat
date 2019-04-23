using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Base.Tables
{
    public class Role
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<UserInGroup> UsersInGroups { get; set; }
    }
}
