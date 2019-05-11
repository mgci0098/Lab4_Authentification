using Microsoft.EntityFrameworkCore.Migrations;

namespace Laborator2.Migrations
{
    public partial class CEva3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Starea",
                table: "Obiective",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Importanta",
                table: "Obiective",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Starea",
                table: "Obiective",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Importanta",
                table: "Obiective",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
