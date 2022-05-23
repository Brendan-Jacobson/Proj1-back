using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proj1.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "flightRs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flightRs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "passengerRs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengerRs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bookingRs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    passengerRId = table.Column<int>(type: "int", nullable: true),
                    flightRId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingRs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookingRs_flightRs_flightRId",
                        column: x => x.flightRId,
                        principalTable: "flightRs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_bookingRs_passengerRs_passengerRId",
                        column: x => x.passengerRId,
                        principalTable: "passengerRs",
                        principalColumn: "Id");
                    table.UniqueConstraint(
                        name: "UN_passengerRs_flightRs",
                        columns: x => new[] { x.passengerRId, x.flightRId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingRs_flightRId",
                table: "bookingRs",
                column: "flightRId");

            migrationBuilder.CreateIndex(
                name: "IX_bookingRs_passengerRId",
                table: "bookingRs",
                column: "passengerRId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingRs");

            migrationBuilder.DropTable(
                name: "flightRs");

            migrationBuilder.DropTable(
                name: "passengerRs");
        }
    }
}
