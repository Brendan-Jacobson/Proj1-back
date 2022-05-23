using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proj1.Migrations
{
    public partial class addConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "flightId",
                table: "bookingRs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "passengerId",
                table: "bookingRs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bookingRs_passengerId_flightId",
                table: "bookingRs",
                columns: new[] { "passengerId", "flightId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_bookingRs_passengerId_flightId",
                table: "bookingRs");

            migrationBuilder.DropColumn(
                name: "flightId",
                table: "bookingRs");

            migrationBuilder.DropColumn(
                name: "passengerId",
                table: "bookingRs");
        }
    }
}
