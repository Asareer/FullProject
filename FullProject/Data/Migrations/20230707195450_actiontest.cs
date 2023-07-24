using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class actiontest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Actions",
                table: "ActionType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ActionType_Id_Actions",
                table: "ActionType",
                column: "Id_Actions");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionType_Action_Id_Actions",
                table: "ActionType",
                column: "Id_Actions",
                principalTable: "Action",
                principalColumn: "Id_Actions",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionType_Action_Id_Actions",
                table: "ActionType");

            migrationBuilder.DropIndex(
                name: "IX_ActionType_Id_Actions",
                table: "ActionType");

            migrationBuilder.DropColumn(
                name: "Id_Actions",
                table: "ActionType");
        }
    }
}
