using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proj1.Migrations
{
    public partial class addAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "passengerRs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "passengerRs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "passengerRs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "passengerRs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArrivalAirport",
                table: "flightRs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "flightRs",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ArrivalTime",
                table: "flightRs",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "DepartureAirport",
                table: "flightRs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "flightRs",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DepartureTime",
                table: "flightRs",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "PassengerLimit",
                table: "flightRs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "passengerRs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "passengerRs");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "passengerRs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "passengerRs");

            migrationBuilder.DropColumn(
                name: "ArrivalAirport",
                table: "flightRs");

            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "flightRs");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "flightRs");

            migrationBuilder.DropColumn(
                name: "DepartureAirport",
                table: "flightRs");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "flightRs");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "flightRs");

            migrationBuilder.DropColumn(
                name: "PassengerLimit",
                table: "flightRs");
        }
    }
}
