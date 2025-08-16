using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDolistMVC.Migrations
{
    /// <inheritdoc />
    public partial class TaskNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaskNote",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskNote",
                table: "Tasks");
        }
    }
}
