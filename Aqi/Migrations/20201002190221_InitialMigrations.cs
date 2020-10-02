using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aqi.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    IdCountry = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.IdCountry);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    IdLocation = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Accuracy = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.IdLocation);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    IdCity = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CountryIdCountry = table.Column<int>(nullable: false),
                    LocationIdLocation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.IdCity);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryIdCountry",
                        column: x => x.CountryIdCountry,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_City_Location_LocationIdLocation",
                        column: x => x.LocationIdLocation,
                        principalTable: "Location",
                        principalColumn: "IdLocation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    IdStation = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CityIdCity = table.Column<int>(nullable: false),
                    CountryIdCountry = table.Column<int>(nullable: false),
                    LocationIdLocation = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.IdStation);
                    table.ForeignKey(
                        name: "FK_Stations_City_CityIdCity",
                        column: x => x.CityIdCity,
                        principalTable: "City",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stations_Country_CountryIdCountry",
                        column: x => x.CountryIdCountry,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stations_Location_LocationIdLocation",
                        column: x => x.LocationIdLocation,
                        principalTable: "Location",
                        principalColumn: "IdLocation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    IdMeasurement = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Metric = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<double>(nullable: false),
                    StationFK = table.Column<int>(nullable: false),
                    StationIdStation = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.IdMeasurement);
                    table.ForeignKey(
                        name: "FK_Measurement_Stations_StationIdStation",
                        column: x => x.StationIdStation,
                        principalTable: "Stations",
                        principalColumn: "IdStation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryIdCountry",
                table: "City",
                column: "CountryIdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_City_LocationIdLocation",
                table: "City",
                column: "LocationIdLocation");

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_StationIdStation",
                table: "Measurement",
                column: "StationIdStation");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_CityIdCity",
                table: "Stations",
                column: "CityIdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_CountryIdCountry",
                table: "Stations",
                column: "CountryIdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_LocationIdLocation",
                table: "Stations",
                column: "LocationIdLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
