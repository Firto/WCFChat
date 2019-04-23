using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Base.Tables
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Login { get; set; }

        [Required]
        [StringLength(1000)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        public DateTime DCreate { get; set; }

        [Required]
        public DateTime LastActivity { get; set; }

        [Required]
        public bool Blocked { get; set; }

        public virtual ICollection<GroupMessage> GroupsMessages { get; set; }

        public virtual ICollection<UserInGroup> UsersInGroups { get; set; }
    }
}
