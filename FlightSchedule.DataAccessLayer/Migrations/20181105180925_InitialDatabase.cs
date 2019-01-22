using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightSchedule.DataAccessLayer.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OriginCityId = table.Column<int>(nullable: false),
                    DestinationCityId = table.Column<int>(nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AgencyId = table.Column<int>(nullable: false),
                    OriginCityId = table.Column<int>(nullable: false),
                    DestinationCityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RouteId = table.Column<int>(nullable: false),
                    DepartureTime = table.Column<DateTimeOffset>(nullable: false),
                    ArrivalTime = table.Column<DateTimeOffset>(nullable: false),
                    AirlineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "DepartureDate", "DestinationCityId", "OriginCityId" },
                values: new object[] { 5555, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44444, 3333 });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_RouteId",
                table: "Flights",
                column: "RouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
