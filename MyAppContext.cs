using Microsoft.EntityFrameworkCore;
using Web_assissignment.Models;

namespace Web_assissignment
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions options) : base(options) { }

        public DbSet<Projectt> Projects { get; set; }
        public DbSet<Taskk> Tasks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamMember>().HasData
                (
                    new TeamMember { TeamMember_id = 1, Name = "Nour", Email = "Nour@gmail.com", Role = "Web Pentester" },
                    new TeamMember { TeamMember_id = 2, Name = "Hamsa", Email = "Hamsa@gmail.com", Role = "Developer" },
                    new TeamMember { TeamMember_id = 3, Name = "Wasfy", Email = "Wasfy@gmail.com", Role = "Researcher" }
                );

            modelBuilder.Entity<Projectt>().HasData
                (
                    new Projectt { Project_id = 1, Name = "Web Application", Description = "Web application project 1", Start_date = new DateTime(2024, 12, 15), End_date = new DateTime(2024, 12, 18) },
                    new Projectt { Project_id = 2, Name = "Web Application Content", Description = "Web application complete the cotent", Start_date = new DateTime(2024, 12, 20), End_date = new DateTime(2024, 12, 25) }
                );

            modelBuilder.Entity<Taskk>().HasData
                (
                    new Taskk { Task_id = 1, Title = "Developing", Description = "Developing the web application ", Status = "Completed", Priority = "High", Deadline = new DateTime(2024, 12, 18), Project_id = 1, TeamMember_id = 1 },
                    new Taskk { Task_id = 2, Title = "Penetration Testing", Description = "Make Penetration Testing", Status = "In Progress", Priority = "High", Deadline = new DateTime(2024, 12, 19), Project_id = 1, TeamMember_id = 1 },
                    new Taskk { Task_id = 3, Title = "Fill Content", Description = "Fill Content of the website", Status = "Pending", Priority = "Low", Deadline = new DateTime(2024, 12, 25), Project_id = 1, TeamMember_id = 1 },
                    new Taskk { Task_id = 4, Title = "Security Consulting", Description = "Security Consulting tips", Status = "Pending", Priority = "Medium", Deadline = new DateTime(2024, 12, 28), Project_id = 1, TeamMember_id = 1 }
                );
        }
    }
}
