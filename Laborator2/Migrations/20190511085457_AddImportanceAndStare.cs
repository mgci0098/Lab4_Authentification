using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Laborator2.Migrations
{
    public partial class AddImportanceAndStare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "Obiective",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Obiective",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Importance",
                table: "Obiective",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Stare",
                table: "Obiective",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Added",
                table: "Obiective");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Obiective");

            migrationBuilder.DropColumn(
                name: "Importance",
                table: "Obiective");

            migrationBuilder.DropColumn(
                name: "Stare",
                table: "Obiective");
        }
    }
}
