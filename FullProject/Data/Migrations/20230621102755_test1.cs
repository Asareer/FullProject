using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id_Orders = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Process = table.Column<int>(type: "int", nullable: false),
                    States = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paper_Pledge = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id_Orders);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id_Projects = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Project = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Project = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type_Project = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locate_Project = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    area_Project = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property_Project = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_Project = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner2_Project = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Num_Phone = table.Column<int>(type: "int", nullable: false),
                    Id_Orders = table.Column<int>(type: "int", nullable: false),
                    OrderId_Orders = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id_Projects);
                    table.ForeignKey(
                        name: "FK_Project_Order_OrderId_Orders",
                        column: x => x.OrderId_Orders,
                        principalTable: "Order",
                        principalColumn: "Id_Orders",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_OrderId_Orders",
                table: "Project",
                column: "OrderId_Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
