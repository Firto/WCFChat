using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Linq;
using Server.Service;
using System;

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

        public void Leave(OnlineUser usr) {
            UserInGroup usrGrp = UsersInGroups.FirstOrDefault((x) => x.UserID == usr.BaseUser.ID);
            if (usrGrp != null)
            {
                if (usrGrp.RoleID == 1)
                {
                    Console.WriteLine("Remove group " + this.Name + " by " + usr.BaseUser.Login);
                    this.Deleted = true;
                    foreach (var item in usr.OnlineUsers)
                    {
                        usrGrp = item.BaseUser.UsersInGroups.FirstOrDefault((x) => x.GroupID == ID);
                        if (usrGrp != null)
                        {
                            usr.MainBase.UsersInGroups.Remove(usrGrp);
                            item.CallBack.ReciveLeaveGroup(new RGroup(this));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Leave group " + this.Name + " by " + usr.BaseUser.Login);
                    usr.MainBase.UsersInGroups.Remove(usrGrp);
                    usr.CallBack.ReciveLeaveGroup(new RGroup(this));
                }
                usr.MainBase.SaveChanges();
            }
            else usr.CallBack.Error("Incorrect group!");
        }
    }

    [DataContract]
    public class RGroup
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Deleted { get; set; }

        public RGroup(Group grp) {
            ID = grp.ID;
            Name = grp.Name;
            Deleted = grp.Deleted;
        }
    }
}
