using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class Add_TaxPayerData_Table_And_Fk__StartProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxPayerData",
                columns: table => new
                {
                    Id_TaxPayerData = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Process = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_SProcess = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name_TaxPayers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrip_TaxPayers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Office = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_SProcess = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPayerData", x => x.Id_TaxPayerData);
                    table.ForeignKey(
                        name: "FK_TaxPayerData_StartProcess_id_SProcess",
                        column: x => x.id_SProcess,
                        principalTable: "StartProcess",
                        principalColumn: "Id_SProcess",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxPayerData_id_SProcess",
                table: "TaxPayerData",
                column: "id_SProcess");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxPayerData");
        }
    }
}
