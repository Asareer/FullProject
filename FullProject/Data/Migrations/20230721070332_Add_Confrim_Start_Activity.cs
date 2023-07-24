using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class Add_Confrim_Start_Activity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Confirm",
                table: "StartActivity",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirm",
                table: "StartActivity");
        }
    }
}
