using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proj1.Migrations
{
    public partial class addConstraint2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookingRs_flightRs_flightRId",
                table: "bookingRs");

            migrationBuilder.DropForeignKey(
                name: "FK_bookingRs_passengerRs_passengerRId",
                table: "bookingRs");

            migrationBuilder.DropIndex(
                name: "IX_bookingRs_passengerId_flightId",
                table: "bookingRs");

            migrationBuilder.DropIndex(
                name: "IX_bookingRs_passengerRId",
                table: "bookingRs");

            migrationBuilder.DropColumn(
                name: "flightId",
                table: "bookingRs");

            migrationBuilder.DropColumn(
                name: "passengerId",
                table: "bookingRs");

            migrationBuilder.AlterColumn<int>(
                name: "passengerRId",
                table: "bookingRs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "flightRId",
                table: "bookingRs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookingRs_passengerRId_flightRId",
                table: "bookingRs",
                columns: new[] { "passengerRId", "flightRId" });

            migrationBuilder.AddForeignKey(
                name: "FK_bookingRs_flightRs_flightRId",
                table: "bookingRs",
                column: "flightRId",
                principalTable: "flightRs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookingRs_passengerRs_passengerRId",
                table: "bookingRs",
                column: "passengerRId",
                principalTable: "passengerRs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookingRs_flightRs_flightRId",
                table: "bookingRs");

            migrationBuilder.DropForeignKey(
                name: "FK_bookingRs_passengerRs_passengerRId",
                table: "bookingRs");

            migrationBuilder.DropIndex(
                name: "IX_bookingRs_passengerRId_flightRId",
                table: "bookingRs");

            migrationBuilder.AlterColumn<int>(
                name: "passengerRId",
                table: "bookingRs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "flightRId",
                table: "bookingRs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_bookingRs_passengerRId",
                table: "bookingRs",
                column: "passengerRId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookingRs_flightRs_flightRId",
                table: "bookingRs",
                column: "flightRId",
                principalTable: "flightRs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookingRs_passengerRs_passengerRId",
                table: "bookingRs",
                column: "passengerRId",
                principalTable: "passengerRs",
                principalColumn: "Id");
        }
    }
}
