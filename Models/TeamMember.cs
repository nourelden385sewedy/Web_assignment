using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Web_assissignment.Models
{
    public class TeamMember
    {
        [Key] public int TeamMember_id { get; set; }
        [MaxLength(100)] public string Name { get; set; }
        [MaxLength(100)] [Unique] public string Email { get; set; }
        [MaxLength(50)] public string Role { get; set; }

        // Navigation Property
        public ICollection<Taskk> Tasks { get; set; }
    }
}
