using Microsoft.EntityFrameworkCore.Migrations;

namespace Gitline.Migrations
{
    public partial class AddOrderProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductOrderID",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductOrderID",
                table: "Order",
                column: "ProductOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ProductOrder_ProductOrderID",
                table: "Order",
                column: "ProductOrderID",
                principalTable: "ProductOrder",
                principalColumn: "ProductOrderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_ProductOrder_ProductOrderID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductOrderID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductOrderID",
                table: "Order");
        }
    }
}
