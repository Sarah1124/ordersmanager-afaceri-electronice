using Microsoft.EntityFrameworkCore.Migrations;

namespace OrdersManager.Data.Migrations
{
    public partial class AddOrderProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.RenameTable(
                name: "OrderProducts",
                newName: "OrderProductses");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProductses",
                newName: "IX_OrderProductses_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProductses",
                newName: "IX_OrderProductses_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProductses",
                table: "OrderProductses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductses_Orders_OrderId",
                table: "OrderProductses",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductses_Products_ProductId",
                table: "OrderProductses",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductses_Orders_OrderId",
                table: "OrderProductses");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductses_Products_ProductId",
                table: "OrderProductses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProductses",
                table: "OrderProductses");

            migrationBuilder.RenameTable(
                name: "OrderProductses",
                newName: "OrderProducts");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductses_ProductId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductses_OrderId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
