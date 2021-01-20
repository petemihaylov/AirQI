using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBase.Migrations
***REMOVED***
    public partial class SlaMarkers : Migration
    ***REMOVED***
        protected override void Up(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.AlterColumn<string>(
                name: "ico",
                table: "Markers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SlaMarkers",
                columns: table => new
                ***REMOVED***
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    MaxValue = table.Column<int>(nullable: false),
                    LocationBoundaries = table.Column<string>(nullable: true)
               ***REMOVED***,
                constraints: table =>
                ***REMOVED***
                    table.PrimaryKey("PK_SlaMarkers", x => x.Id);
               ***REMOVED***);
       ***REMOVED***

        protected override void Down(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.DropTable(
                name: "SlaMarkers");

            migrationBuilder.AlterColumn<string>(
                name: "ico",
                table: "Markers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
