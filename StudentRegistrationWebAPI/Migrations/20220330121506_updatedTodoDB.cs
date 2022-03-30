using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegistrationWebAPI.Migrations
{
    public partial class updatedTodoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Checked",
                table: "Todos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checked",
                table: "Todos");
        }
    }
}
