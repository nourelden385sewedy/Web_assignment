using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web_assissignment.Migrations
{
    /// <inheritdoc />
    public partial class initial_create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Project_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Project_id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    TeamMember_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.TeamMember_id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Task_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Project_id = table.Column<int>(type: "int", nullable: false),
                    TeamMember_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Task_id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_Project_id",
                        column: x => x.Project_id,
                        principalTable: "Projects",
                        principalColumn: "Project_id");
                    table.ForeignKey(
                        name: "FK_Tasks_TeamMembers_TeamMember_id",
                        column: x => x.TeamMember_id,
                        principalTable: "TeamMembers",
                        principalColumn: "TeamMember_id");
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Project_id", "Description", "End_date", "Name", "Start_date" },
                values: new object[,]
                {
                    { 1, "Web application project 1", new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web Application", new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Web application complete the cotent", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web Application Content", new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "TeamMember_id", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "Nour@gmail.com", "Nour", "Web Pentester" },
                    { 2, "Hamsa@gmail.com", "Hamsa", "Developer" },
                    { 3, "Wasfy@gmail.com", "Wasfy", "Researcher" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Task_id", "Deadline", "Description", "Priority", "Project_id", "Status", "TeamMember_id", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developing the web application ", "High", 1, "Completed", 1, "Developing" },
                    { 2, new DateTime(2024, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Make Penetration Testing", "High", 1, "In Progress", 1, "Penetration Testing" },
                    { 3, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fill Content of the website", "Low", 1, "Pending", 1, "Fill Content" },
                    { 4, new DateTime(2024, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Security Consulting tips", "Medium", 1, "Pending", 1, "Security Consulting" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Project_id",
                table: "Tasks",
                column: "Project_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TeamMember_id",
                table: "Tasks",
                column: "TeamMember_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
