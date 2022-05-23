using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proj1.Migrations
{
    public partial class addConstraint3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_bookingRs_passengerRId_flightRId",
                table: "bookingRs");

            migrationBuilder.CreateIndex(
                name: "IX_bookingRs_passengerRId_flightRId",
                table: "bookingRs",
                columns: new[] { "passengerRId", "flightRId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_bookingRs_passengerRId_flightRId",
                table: "bookingRs");

            migrationBuilder.CreateIndex(
                name: "IX_bookingRs_passengerRId_flightRId",
                table: "bookingRs",
                columns: new[] { "passengerRId", "flightRId" });
        }
    }
}
