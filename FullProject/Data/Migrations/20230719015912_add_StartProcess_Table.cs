using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class add_StartProcess_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StartProcess",
                columns: table => new
                {
                    Id_SProcess = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_projects = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartProcess", x => x.Id_SProcess);
                    table.ForeignKey(
                        name: "FK_StartProcess_Project_Id_projects",
                        column: x => x.Id_projects,
                        principalTable: "Project",
                        principalColumn: "Id_Projects",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StartProcess_Id_projects",
                table: "StartProcess",
                column: "Id_projects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StartProcess");
        }
    }
}
