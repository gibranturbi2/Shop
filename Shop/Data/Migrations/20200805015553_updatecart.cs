using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class updatecart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Clientes_ClienteId",
                table: "Cart");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteId",
                table: "Cart",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Cart",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_ClienteId",
                table: "Cart",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_ClienteId",
                table: "Cart");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Cart",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Cart",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Clientes_ClienteId",
                table: "Cart",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
