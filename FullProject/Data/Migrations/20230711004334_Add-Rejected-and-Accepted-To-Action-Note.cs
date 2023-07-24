using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullProject.Migrations
{
    public partial class AddRejectedandAcceptedToActionNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Action",
                newName: "Rejected_Note");

            migrationBuilder.AddColumn<string>(
                name: "Accepted_Note",
                table: "Action",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted_Note",
                table: "Action");

            migrationBuilder.RenameColumn(
                name: "Rejected_Note",
                table: "Action",
                newName: "Note");
        }
    }
}
