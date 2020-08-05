using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class _1234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordens_Clientes_ClienteId",
                table: "Ordens");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteId",
                table: "Ordens",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordens_AspNetUsers_ClienteId",
                table: "Ordens",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordens_AspNetUsers_ClienteId",
                table: "Ordens");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Ordens",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordens_Clientes_ClienteId",
                table: "Ordens",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
