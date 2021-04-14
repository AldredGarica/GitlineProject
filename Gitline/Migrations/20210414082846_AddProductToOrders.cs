using Microsoft.EntityFrameworkCore.Migrations;

namespace Gitline.Migrations
{
    public partial class AddProductToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductOrder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_ProductId",
                table: "ProductOrder",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Inventory_ProductId",
                table: "ProductOrder",
                column: "ProductId",
                principalTable: "Inventory",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Inventory_ProductId",
                table: "ProductOrder");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrder_ProductId",
                table: "ProductOrder");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductOrder");
        }
    }
}
