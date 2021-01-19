using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBase.Migrations
***REMOVED***
    public partial class MarkersUpdate : Migration
    ***REMOVED***
        protected override void Up(MigrationBuilder migrationBuilder)
        ***REMOVED***
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
       ***REMOVED***

        protected override void Down(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.DropColumn(
                name: "ico",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Markers");
       ***REMOVED***
   ***REMOVED***
***REMOVED***
