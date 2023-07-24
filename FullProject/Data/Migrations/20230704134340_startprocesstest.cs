using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class startprocesstest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StartActivity_Order_Id_Orders",
                table: "StartActivity");

            migrationBuilder.DropTable(
                name: "Process2");

            migrationBuilder.DropTable(
                name: "Process3");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StartActivity",
                table: "StartActivity");

            migrationBuilder.RenameTable(
                name: "StartActivity",
                newName: "StartProcesses");

            migrationBuilder.RenameIndex(
                name: "IX_StartActivity_Id_Orders",
                table: "StartProcesses",
                newName: "IX_StartProcesses_Id_Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "StartProcesses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Purpose",
                table: "StartProcesses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StartProcesses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "StartProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Final_Report",
                table: "StartProcesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Result3",
                table: "StartProcesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StartProcesses",
                table: "StartProcesses",
                column: "Id_SProcesses");

            migrationBuilder.AddForeignKey(
                name: "FK_StartProcesses_Order_Id_Orders",
                table: "StartProcesses",
                column: "Id_Orders",
                principalTable: "Order",
                principalColumn: "Id_Orders",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StartProcesses_Order_Id_Orders",
                table: "StartProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StartProcesses",
                table: "StartProcesses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "StartProcesses");

            migrationBuilder.DropColumn(
                name: "Final_Report",
                table: "StartProcesses");

            migrationBuilder.DropColumn(
                name: "Result3",
                table: "StartProcesses");

            migrationBuilder.RenameTable(
                name: "StartProcesses",
                newName: "StartActivity");

            migrationBuilder.RenameIndex(
                name: "IX_StartProcesses_Id_Orders",
                table: "StartActivity",
                newName: "IX_StartActivity_Id_Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "StartActivity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Purpose",
                table: "StartActivity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StartActivity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StartActivity",
                table: "StartActivity",
                column: "Id_SProcesses");

            migrationBuilder.CreateTable(
                name: "Process2",
                columns: table => new
                {
                    Id_SProcesses = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Orders = table.Column<int>(type: "int", nullable: false),
                    Date_Processes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes_Processes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process2", x => x.Id_SProcesses);
                    table.ForeignKey(
                        name: "FK_Process2_Order_Id_Orders",
                        column: x => x.Id_Orders,
                        principalTable: "Order",
                        principalColumn: "Id_Orders",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Process3",
                columns: table => new
                {
                    Id_SProcesses = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Orders = table.Column<int>(type: "int", nullable: false),
                    Date_Processes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Final_Report = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes_Processes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process3", x => x.Id_SProcesses);
                    table.ForeignKey(
                        name: "FK_Process3_Order_Id_Orders",
                        column: x => x.Id_Orders,
                        principalTable: "Order",
                        principalColumn: "Id_Orders",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Process2_Id_Orders",
                table: "Process2",
                column: "Id_Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Process3_Id_Orders",
                table: "Process3",
                column: "Id_Orders");

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
