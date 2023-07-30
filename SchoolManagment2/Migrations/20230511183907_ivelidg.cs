using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagment2.Migrations
{
    public partial class ivelidg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "B_Id",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "C_Id",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "B_Id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "C_Id",
                table: "Students");
        }
    }
}
