using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class test12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Order_OrderId_Orders",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_OrderId_Orders",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "OrderId_Orders",
                table: "Project");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Id_Orders",
                table: "Project",
                column: "Id_Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Order_Id_Orders",
                table: "Project",
                column: "Id_Orders",
                principalTable: "Order",
                principalColumn: "Id_Orders",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Order_Id_Orders",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_Id_Orders",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "OrderId_Orders",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_OrderId_Orders",
                table: "Project",
                column: "OrderId_Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Order_OrderId_Orders",
                table: "Project",
                column: "OrderId_Orders",
                principalTable: "Order",
                principalColumn: "Id_Orders");
        }
    }
}
