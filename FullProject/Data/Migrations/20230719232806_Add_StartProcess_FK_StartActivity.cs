using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class Add_StartProcess_FK_StartActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StartActivity_Order_Id_Orders",
                table: "StartActivity");

            migrationBuilder.RenameColumn(
                name: "Id_Orders",
                table: "StartActivity",
                newName: "id_SProcess");

            migrationBuilder.RenameColumn(
                name: "Id_StartActivities",
                table: "StartActivity",
                newName: "Id_StartActivity");

            migrationBuilder.RenameIndex(
                name: "IX_StartActivity_Id_Orders",
                table: "StartActivity",
                newName: "IX_StartActivity_id_SProcess");

            migrationBuilder.AddForeignKey(
                name: "FK_StartActivity_StartProcess_id_SProcess",
                table: "StartActivity",
                column: "id_SProcess",
                principalTable: "StartProcess",
                principalColumn: "Id_SProcess",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StartActivity_StartProcess_id_SProcess",
                table: "StartActivity");

            migrationBuilder.RenameColumn(
                name: "id_SProcess",
                table: "StartActivity",
                newName: "Id_Orders");

            migrationBuilder.RenameColumn(
                name: "Id_StartActivity",
                table: "StartActivity",
                newName: "Id_StartActivities");

            migrationBuilder.RenameIndex(
                name: "IX_StartActivity_id_SProcess",
                table: "StartActivity",
                newName: "IX_StartActivity_Id_Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_StartActivity_Order_Id_Orders",
                table: "StartActivity",
                column: "Id_Orders",
                principalTable: "Order",
                principalColumn: "Id_Orders",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
