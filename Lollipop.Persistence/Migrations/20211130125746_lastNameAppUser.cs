using Microsoft.EntityFrameworkCore.Migrations;

namespace Lollipop.Persistence.Migrations
{
    public partial class lastNameAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastName",
                table: "AspNetUsers");
        }
    }
}
