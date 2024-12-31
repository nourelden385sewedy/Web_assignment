using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_assissignment.Models
{
    public class Taskk
    {
        [Key] public int Task_id { get; set; }
        [MaxLength(100)] public string Title { get; set; }
        [MaxLength(100)] public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }

        // Navigation Property
        public int Project_id { get; set; }
        [ForeignKey("Project_id")]
        public Projectt Project { get; set; }

        //
        public int TeamMember_id { get; set; }
        [ForeignKey("TeamMember_id")]
        public TeamMember TeamMember { get; set; }
    }
}
