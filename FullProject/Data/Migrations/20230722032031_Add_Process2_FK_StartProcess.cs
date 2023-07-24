using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class Add_Process2_FK_StartProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process2_Order_Id_Orders",
                table: "Process2");

            migrationBuilder.DropIndex(
                name: "IX_Process2_Id_Orders",
                table: "Process2");

            migrationBuilder.AddColumn<int>(
                name: "id_SProcess",
                table: "Process2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Process2_id_SProcess",
                table: "Process2",
                column: "id_SProcess");

            migrationBuilder.AddForeignKey(
                name: "FK_Process2_StartProcess_id_SProcess",
                table: "Process2",
                column: "id_SProcess",
                principalTable: "StartProcess",
                principalColumn: "Id_SProcess",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Process2_StartProcess_id_SProcess",
                table: "Process2");

            migrationBuilder.DropIndex(
                name: "IX_Process2_id_SProcess",
                table: "Process2");

            migrationBuilder.DropColumn(
                name: "id_SProcess",
                table: "Process2");

            migrationBuilder.CreateIndex(
                name: "IX_Process2_Id_Orders",
                table: "Process2",
                column: "Id_Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Process2_Order_Id_Orders",
                table: "Process2",
                column: "Id_Orders",
                principalTable: "Order",
                principalColumn: "Id_Orders",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
