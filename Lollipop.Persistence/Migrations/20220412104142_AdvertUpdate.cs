using Microsoft.EntityFrameworkCore.Migrations;

namespace Lollipop.Persistence.Migrations
{
    public partial class AdvertUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "Attributes",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Advertisements",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_AdvertisementId",
                table: "Attributes",
                column: "AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Advertisements_AdvertisementId",
                table: "Attributes",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Advertisements_AdvertisementId",
                table: "Attributes");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_AdvertisementId",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "Attributes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Advertisements",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
