using Microsoft.EntityFrameworkCore.Migrations;

namespace Laborator2.Migrations
{
    public partial class CEva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Importance",
                table: "Obiective");

            migrationBuilder.DropColumn(
                name: "Stare",
                table: "Obiective");

            migrationBuilder.AddColumn<int>(
                name: "Importanta",
                table: "Obiective",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Starea",
                table: "Obiective",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Importanta",
                table: "Obiective");

            migrationBuilder.DropColumn(
                name: "Starea",
                table: "Obiective");

            migrationBuilder.AddColumn<string>(
                name: "Importance",
                table: "Obiective",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Stare",
                table: "Obiective",
                nullable: true);
        }
    }
}
