using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class newtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StartProcesses_Order_Id_Orders",
                table: "StartProcesses");

            migrationBuilder.DropTable(
                name: "Examination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StartProcesses",
                table: "StartProcesses");

            migrationBuilder.DropColumn(
                name: "Descrip_TaxPayers",
                table: "TaxPayer");

            migrationBuilder.DropColumn(
                name: "Office",
                table: "TaxPayer");

            migrationBuilder.DropColumn(
                name: "Type_TaxPayers",
                table: "TaxPayer");

            migrationBuilder.DropColumn(
                name: "Date_Processes",
                table: "StartProcesses");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "StartProcesses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "StartProcesses");

            migrationBuilder.DropColumn(
                name: "Final_Report",
                table: "StartProcesses");

            migrationBuilder.DropColumn(
                name: "Notes_Processes",
                table: "StartProcesses");

            migrationBuilder.DropColumn(
                name: "Result3",
                table: "StartProcesses");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "StartProcesses");

            migrationBuilder.RenameTable(
                name: "StartProcesses",
                newName: "StartActivity");

            migrationBuilder.RenameColumn(
                name: "Id_SProcesses",
                table: "StartActivity",
                newName: "Id_StartActivities");

            migrationBuilder.RenameIndex(
                name: "IX_StartProcesses_Id_Orders",
                table: "StartActivity",
                newName: "IX_StartActivity_Id_Orders");

            migrationBuilder.AddColumn<int>(
                name: "Id_Processes2",
                table: "TaxPayer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Processes2",
                table: "ProductType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Homogeneity",
                table: "ProductData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id_Processes3",
                table: "ProductData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Smell",
                table: "ProductData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Taste",
                table: "ProductData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id_Processes2",
                table: "GenerlData",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                column: "Id_StartActivities");

            migrationBuilder.CreateTable(
                name: "Process2",
                columns: table => new
                {
                    Id_Processes2 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Orders = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process2", x => x.Id_Processes2);
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
                    Id_Processes2 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Final_Report = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Orders = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process3", x => x.Id_Processes2);
                    table.ForeignKey(
                        name: "FK_Process3_Order_Id_Orders",
                        column: x => x.Id_Orders,
                        principalTable: "Order",
                        principalColumn: "Id_Orders",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxPayer_Id_Processes2",
                table: "TaxPayer",
                column: "Id_Processes2");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_Id_Processes2",
                table: "ProductType",
                column: "Id_Processes2");

            migrationBuilder.CreateIndex(
                name: "IX_ProductData_Id_Processes3",
                table: "ProductData",
                column: "Id_Processes3");

            migrationBuilder.CreateIndex(
                name: "IX_GenerlData_Id_Processes2",
                table: "GenerlData",
                column: "Id_Processes2");

            migrationBuilder.CreateIndex(
                name: "IX_Process2_Id_Orders",
                table: "Process2",
                column: "Id_Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Process3_Id_Orders",
                table: "Process3",
                column: "Id_Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_GenerlData_Process2_Id_Processes2",
                table: "GenerlData",
                column: "Id_Processes2",
                principalTable: "Process2",
                principalColumn: "Id_Processes2",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductData_Process3_Id_Processes3",
                table: "ProductData",
                column: "Id_Processes3",
                principalTable: "Process3",
                principalColumn: "Id_Processes2",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_Process2_Id_Processes2",
                table: "ProductType",
                column: "Id_Processes2",
                principalTable: "Process2",
                principalColumn: "Id_Processes2",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StartActivity_Order_Id_Orders",
                table: "StartActivity",
                column: "Id_Orders",
                principalTable: "Order",
                principalColumn: "Id_Orders",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxPayer_Process2_Id_Processes2",
                table: "TaxPayer",
                column: "Id_Processes2",
                principalTable: "Process2",
                principalColumn: "Id_Processes2",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenerlData_Process2_Id_Processes2",
                table: "GenerlData");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductData_Process3_Id_Processes3",
                table: "ProductData");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_Process2_Id_Processes2",
                table: "ProductType");

            migrationBuilder.DropForeignKey(
                name: "FK_StartActivity_Order_Id_Orders",
                table: "StartActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxPayer_Process2_Id_Processes2",
                table: "TaxPayer");

            migrationBuilder.DropTable(
                name: "Process2");

            migrationBuilder.DropTable(
                name: "Process3");

            migrationBuilder.DropIndex(
                name: "IX_TaxPayer_Id_Processes2",
                table: "TaxPayer");

            migrationBuilder.DropIndex(
                name: "IX_ProductType_Id_Processes2",
                table: "ProductType");

            migrationBuilder.DropIndex(
                name: "IX_ProductData_Id_Processes3",
                table: "ProductData");

            migrationBuilder.DropIndex(
                name: "IX_GenerlData_Id_Processes2",
                table: "GenerlData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StartActivity",
                table: "StartActivity");

            migrationBuilder.DropColumn(
                name: "Id_Processes2",
                table: "TaxPayer");

            migrationBuilder.DropColumn(
                name: "Id_Processes2",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "Homogeneity",
                table: "ProductData");

            migrationBuilder.DropColumn(
                name: "Id_Processes3",
                table: "ProductData");

            migrationBuilder.DropColumn(
                name: "Smell",
                table: "ProductData");

            migrationBuilder.DropColumn(
                name: "Taste",
                table: "ProductData");

            migrationBuilder.DropColumn(
                name: "Id_Processes2",
                table: "GenerlData");

            migrationBuilder.RenameTable(
                name: "StartActivity",
                newName: "StartProcesses");

            migrationBuilder.RenameColumn(
                name: "Id_StartActivities",
                table: "StartProcesses",
                newName: "Id_SProcesses");

            migrationBuilder.RenameIndex(
                name: "IX_StartActivity_Id_Orders",
                table: "StartProcesses",
                newName: "IX_StartProcesses_Id_Orders");

            migrationBuilder.AddColumn<string>(
                name: "Descrip_TaxPayers",
                table: "TaxPayer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Office",
                table: "TaxPayer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type_TaxPayers",
                table: "TaxPayer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Processes",
                table: "StartProcesses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "StartProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                name: "Notes_Processes",
                table: "StartProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Result3",
                table: "StartProcesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "StartProcesses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StartProcesses",
                table: "StartProcesses",
                column: "Id_SProcesses");

            migrationBuilder.CreateTable(
                name: "Examination",
                columns: table => new
                {
                    Id_Examinations = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Homogeneity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Smell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Taste = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examination", x => x.Id_Examinations);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StartProcesses_Order_Id_Orders",
                table: "StartProcesses",
                column: "Id_Orders",
                principalTable: "Order",
                principalColumn: "Id_Orders",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
