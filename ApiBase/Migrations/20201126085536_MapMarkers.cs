using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBase.Migrations
***REMOVED***
    public partial class MapMarkers : Migration
    ***REMOVED***
        protected override void Up(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.AlterColumn<double>(
                name: "longitude",
                table: "Markers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "latitude",
                table: "Markers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
       ***REMOVED***

        protected override void Down(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.AlterColumn<int>(
                name: "longitude",
                table: "Markers",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "latitude",
                table: "Markers",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
       ***REMOVED***
   ***REMOVED***
***REMOVED***
