using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBase.Migrations
{
    public partial class MarkersUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ico",
                table: "Markers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Markers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ico",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Markers");
        }
    }
}
