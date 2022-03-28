using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegistrationWebAPI.Migrations
{
    public partial class EmpData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "Employee",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentAddress",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeDOB",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeFirstName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeGender",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeLastName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeManager",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNumber",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PermanentAddress",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CurrentAddress",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeDOB",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeFirstName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeGender",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeLastName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeManager",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Employee",
                newName: "EmployeeName");
        }
    }
}
