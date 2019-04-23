using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Base.Tables
{

    public class GroupMessage
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Group")]
        public int GroupID { get; set; }

        [Required]
        [StringLength(1000)]
        public string MessageSource { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }
    }
}
