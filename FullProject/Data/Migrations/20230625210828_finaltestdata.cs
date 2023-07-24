using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class finaltestdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id_Actions = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Actions = table.Column<int>(type: "int", nullable: false),
                    State_Actions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note_Actions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Orders = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id_Actions);
                    table.ForeignKey(
                        name: "FK_Action_Order_Id_Orders",
                        column: x => x.Id_Orders,
                        principalTable: "Order",
                        principalColumn: "Id_Orders",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionType",
                columns: table => new
                {
                    Id_ActionsTypes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actions1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actions2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actions3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionType", x => x.Id_ActionsTypes);
                });

            migrationBuilder.CreateTable(
                name: "Examination",
                columns: table => new
                {
                    Id_Examinations = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Smell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Homogeneity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examination", x => x.Id_Examinations);
                });

            migrationBuilder.CreateTable(
                name: "GenerlData",
                columns: table => new
                {
                    Id_GeneralDatas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addrees_Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_B = table.Column<int>(type: "int", nullable: false),
                    Telephone = table.Column<int>(type: "int", nullable: false),
                    Cellphone = table.Column<int>(type: "int", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telecis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerlData", x => x.Id_GeneralDatas);
                });

            migrationBuilder.CreateTable(
                name: "Process2",
                columns: table => new
                {
                    Id_SProcesses = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Processes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes_Processes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Orders = table.Column<int>(type: "int", nullable: false)
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
                    Result3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Final_Report = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Processes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes_Processes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Orders = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ProductData",
                columns: table => new
                {
                    Id_ProductDatas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Product = table.Column<int>(type: "int", nullable: false),
                    Item_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Trande = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country_Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Num_Batch = table.Column<int>(type: "int", nullable: false),
                    Type_Package = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_production = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Size2 = table.Column<double>(type: "float", nullable: false),
                    Numper = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    match_Statment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    match_Periods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Num_Sample = table.Column<int>(type: "int", nullable: false),
                    Num_Report = table.Column<int>(type: "int", nullable: false),
                    Date_Report = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result_Report = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductData", x => x.Id_ProductDatas);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id_ProductTypes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Class = table.Column<int>(type: "int", nullable: false),
                    Class_Product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productivity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Num_Register = table.Column<int>(type: "int", nullable: false),
                    Date_Product = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id_ProductTypes);
                });

            migrationBuilder.CreateTable(
                name: "StartActivity",
                columns: table => new
                {
                    Id_SProcesses = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Processes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes_Processes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Orders = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartActivity", x => x.Id_SProcesses);
                    table.ForeignKey(
                        name: "FK_StartActivity_Order_Id_Orders",
                        column: x => x.Id_Orders,
                        principalTable: "Order",
                        principalColumn: "Id_Orders",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxPayer",
                columns: table => new
                {
                    Id_TaxPayers = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_TaxPayers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrip_TaxPayers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Office = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type_TaxPayers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_H = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day_TaxPayers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time_TaxPayers = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Num_TaxPayers = table.Column<int>(type: "int", nullable: false),
                    Date_M = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPayer", x => x.Id_TaxPayers);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Action_Id_Orders",
                table: "Action",
                column: "Id_Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Process2_Id_Orders",
                table: "Process2",
                column: "Id_Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Process3_Id_Orders",
                table: "Process3",
                column: "Id_Orders");

            migrationBuilder.CreateIndex(
                name: "IX_StartActivity_Id_Orders",
                table: "StartActivity",
                column: "Id_Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "ActionType");

            migrationBuilder.DropTable(
                name: "Examination");

            migrationBuilder.DropTable(
                name: "GenerlData");

            migrationBuilder.DropTable(
                name: "Process2");

            migrationBuilder.DropTable(
                name: "Process3");

            migrationBuilder.DropTable(
                name: "ProductData");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "StartActivity");

            migrationBuilder.DropTable(
                name: "TaxPayer");
        }
    }
}
