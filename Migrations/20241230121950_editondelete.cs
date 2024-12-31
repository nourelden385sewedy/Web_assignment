using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_assissignment.Migrations
{
    /// <inheritdoc />
    public partial class editondelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_Project_id",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TeamMembers_TeamMember_id",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_Project_id",
                table: "Tasks",
                column: "Project_id",
                principalTable: "Projects",
                principalColumn: "Project_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TeamMembers_TeamMember_id",
                table: "Tasks",
                column: "TeamMember_id",
                principalTable: "TeamMembers",
                principalColumn: "TeamMember_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_Project_id",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TeamMembers_TeamMember_id",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_Project_id",
                table: "Tasks",
                column: "Project_id",
                principalTable: "Projects",
                principalColumn: "Project_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TeamMembers_TeamMember_id",
                table: "Tasks",
                column: "TeamMember_id",
                principalTable: "TeamMembers",
                principalColumn: "TeamMember_id");
        }
    }
}
