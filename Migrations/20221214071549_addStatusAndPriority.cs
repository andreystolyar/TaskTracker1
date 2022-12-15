using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Migrations
{
    public partial class addStatusAndPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Project",
                newName: "ProjectStatus");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "ProjectStatus",
                table: "Project",
                newName: "Status");
        }
    }
}
