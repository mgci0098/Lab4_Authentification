using Microsoft.EntityFrameworkCore.Migrations;

namespace Laborator2.Migrations
{
    public partial class AddObiectivId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Obiective_ObiectivId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "ObiectivId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Obiective_ObiectivId",
                table: "Comments",
                column: "ObiectivId",
                principalTable: "Obiective",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Obiective_ObiectivId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "ObiectivId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Obiective_ObiectivId",
                table: "Comments",
                column: "ObiectivId",
                principalTable: "Obiective",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
