using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBase.Migrations
***REMOVED***
    public partial class Init : Migration
    ***REMOVED***
        protected override void Up(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                ***REMOVED***
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 250, nullable: true),
                    LastName = table.Column<string>(maxLength: 250, nullable: true),
                    Password = table.Column<string>(nullable: false)
               ***REMOVED***,
                constraints: table =>
                ***REMOVED***
                    table.PrimaryKey("PK_Users", x => x.UserId);
               ***REMOVED***);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                ***REMOVED***
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    UserId = table.Column<int>(nullable: false)
               ***REMOVED***,
                constraints: table =>
                ***REMOVED***
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
               ***REMOVED***);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId",
                unique: true);
       ***REMOVED***

        protected override void Down(MigrationBuilder migrationBuilder)
        ***REMOVED***
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
       ***REMOVED***
   ***REMOVED***
***REMOVED***
