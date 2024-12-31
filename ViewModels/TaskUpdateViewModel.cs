using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using Web_assissignment.Models;

namespace Web_assissignment.ViewModels
{
    public class TaskUpdateViewModel
    {
        public Taskk Task { get; set; }

        //public int Task_id { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
        //public string Status { get; set; }
        //public string Priority { get; set; }
        //public DateTime Deadline { get; set; }
        public int Project_id { get; set; }
        public int TeamMember_id { get; set; }

        //public string Name { get; set; }
        //public string Description { get; set; }

        //
        public List<string> Priority_list { get; set; }
        public List<string> Status_list { get; set; }


        public List<Projectt> Projects_list { get; set; }
        public List<TeamMember> Team_members_list { get; set; }
    }
}
