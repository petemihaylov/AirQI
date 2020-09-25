using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBase.Migrations
***REMOVED***
    public partial class Init : Migration
    ***REMOVED***
        protected override void Up(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                ***REMOVED***
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true)
               ***REMOVED***,
                constraints: table =>
                ***REMOVED***
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
               ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                ***REMOVED***
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 250, nullable: true),
                    LastName = table.Column<string>(maxLength: 250, nullable: true),
                    Password = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
               ***REMOVED***,
                constraints: table =>
                ***REMOVED***
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
               ***REMOVED***);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId",
                unique: true);
       ***REMOVED***

        protected override void Down(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
       ***REMOVED***
   ***REMOVED***
***REMOVED***
