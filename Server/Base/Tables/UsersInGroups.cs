using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Base.Tables
{
    public class UserInGroup
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("User")]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Group")]
        public int GroupID { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleID { get; set; }

        public bool Muted { get; set; }

        public virtual Group Group { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
