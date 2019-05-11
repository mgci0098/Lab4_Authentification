using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Laborator2.Migrations
{
    public partial class AddClosedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "closedAt",
                table: "Obiective",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "closedAt",
                table: "Obiective");
        }
    }
}
