using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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

    [DataContract]
    public class RUser {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string PasswordHash { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public DateTime DCreate { get; set; }
        [DataMember]
        public DateTime LastActivity { get; set; }
        [DataMember]
        public bool Blocked { get; set; }

        public RUser(User usr) {
            ID = usr.ID;
            Login = usr.Login;
            PasswordHash = usr.PasswordHash;
            Email = usr.Email;
            DCreate = usr.DCreate;
            LastActivity = usr.LastActivity;
            Blocked = usr.Blocked;
        }
    }
}
