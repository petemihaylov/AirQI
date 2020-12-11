using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBase.Migrations
***REMOVED***
    public partial class Init : Migration
    ***REMOVED***
        protected override void Up(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                ***REMOVED***
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
               ***REMOVED***,
                constraints: table =>
                ***REMOVED***
                    table.PrimaryKey("PK_Notifications", x => x.Id);
               ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                ***REMOVED***
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 250, nullable: true),
                    LastName = table.Column<string>(maxLength: 250, nullable: true),
                    UserRole = table.Column<string>(nullable: false)
               ***REMOVED***,
                constraints: table =>
                ***REMOVED***
                    table.PrimaryKey("PK_Users", x => x.Id);
               ***REMOVED***);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
       ***REMOVED***

        protected override void Down(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Users");
       ***REMOVED***
   ***REMOVED***
***REMOVED***
