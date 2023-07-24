using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class tset11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Order_Orders",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "Orders",
                table: "Project",
                newName: "OrderId_Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Project_Orders",
                table: "Project",
                newName: "IX_Project_OrderId_Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Order_OrderId_Orders",
                table: "Project",
                column: "OrderId_Orders",
                principalTable: "Order",
                principalColumn: "Id_Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Order_OrderId_Orders",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "OrderId_Orders",
                table: "Project",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Project_OrderId_Orders",
                table: "Project",
                newName: "IX_Project_Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Order_Orders",
                table: "Project",
                column: "Orders",
                principalTable: "Order",
                principalColumn: "Id_Orders");
        }
    }
}
