using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Persistence.Migrations
{
    public partial class StudProfNewAttriubutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Professors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Professors");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true);
        }
    }
}
