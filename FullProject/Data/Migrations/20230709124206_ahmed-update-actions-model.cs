using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class ahmedupdateactionsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Action_Order_Id_Orders",
                table: "Action");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionType_Action_Id_Actions",
                table: "ActionType");

            migrationBuilder.DropIndex(
                name: "IX_ActionType_Id_Actions",
                table: "ActionType");

            migrationBuilder.DropIndex(
                name: "IX_Action_Id_Orders",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "Id_Actions",
                table: "ActionType");

            migrationBuilder.DropColumn(
                name: "Id_Orders",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "Note_Actions",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "State_Actions",
                table: "Action");

            migrationBuilder.RenameColumn(
                name: "Num_Actions",
                table: "Action",
                newName: "Id_projects");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "ActionType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Actions3",
                table: "ActionType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Actions2",
                table: "ActionType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Actions1",
                table: "ActionType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Action1_Note",
                table: "Action",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Action1_Status",
                table: "Action",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Action2_Note",
                table: "Action",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Action2_Status",
                table: "Action",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Action3_Note",
                table: "Action",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Action3_Paper",
                table: "Action",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Action_Id_projects",
                table: "Action",
                column: "Id_projects");

            migrationBuilder.AddForeignKey(
                name: "FK_Action_Project_Id_projects",
                table: "Action",
                column: "Id_projects",
                principalTable: "Project",
                principalColumn: "Id_Projects",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Action_Project_Id_projects",
                table: "Action");

            migrationBuilder.DropIndex(
                name: "IX_Action_Id_projects",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "Action1_Note",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "Action1_Status",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "Action2_Note",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "Action2_Status",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "Action3_Note",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "Action3_Paper",
                table: "Action");

            migrationBuilder.RenameColumn(
                name: "Id_projects",
                table: "Action",
                newName: "Num_Actions");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "ActionType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Actions3",
                table: "ActionType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Actions2",
                table: "ActionType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Actions1",
                table: "ActionType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Actions",
                table: "ActionType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Orders",
                table: "Action",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Note_Actions",
                table: "Action",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State_Actions",
                table: "Action",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ActionType_Id_Actions",
                table: "ActionType",
                column: "Id_Actions");

            migrationBuilder.CreateIndex(
                name: "IX_Action_Id_Orders",
                table: "Action",
                column: "Id_Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Action_Order_Id_Orders",
                table: "Action",
                column: "Id_Orders",
                principalTable: "Order",
                principalColumn: "Id_Orders",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionType_Action_Id_Actions",
                table: "ActionType",
                column: "Id_Actions",
                principalTable: "Action",
                principalColumn: "Id_Actions",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
