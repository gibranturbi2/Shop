using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class FixinOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Ordens",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordens_ClienteId",
                table: "Ordens",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordens_Clientes_ClienteId",
                table: "Ordens",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordens_Clientes_ClienteId",
                table: "Ordens");

            migrationBuilder.DropIndex(
                name: "IX_Ordens_ClienteId",
                table: "Ordens");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Ordens");
        }
    }
}
