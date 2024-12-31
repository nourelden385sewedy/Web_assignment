using System.ComponentModel.DataAnnotations;

namespace Web_assissignment.Models
{
    public class Projectt
    {
        [Key] public int Project_id { get; set; }
        [MaxLength(100)] public string Name { get; set; }
        [MaxLength(500)] public string Description { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }

        // Navigation Property
        public ICollection<Taskk> Tasks { get; set; }
    }
}
