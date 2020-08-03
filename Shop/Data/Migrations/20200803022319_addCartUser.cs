using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class addCartUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Cart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Cart",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ClienteId",
                table: "Cart",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Clientes_ClienteId",
                table: "Cart",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Clientes_ClienteId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ClienteId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Cart");
        }
    }
}
