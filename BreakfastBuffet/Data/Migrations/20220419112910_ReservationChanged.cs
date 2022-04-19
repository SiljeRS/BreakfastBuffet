using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakfastBuffet.Data.Migrations
{
    public partial class ReservationChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adult_reservation_ReservationId",
                table: "adult");

            migrationBuilder.DropForeignKey(
                name: "FK_children_reservation_ReservationId",
                table: "children");

            migrationBuilder.DropForeignKey(
                name: "FK_reservation_checkIn_CheckInId",
                table: "reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservation",
                table: "reservation");

            migrationBuilder.RenameTable(
                name: "reservation",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_reservation_CheckInId",
                table: "Reservation",
                newName: "IX_Reservation_CheckInId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Reservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_adult_Reservation_ReservationId",
                table: "adult",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_children_Reservation_ReservationId",
                table: "children",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_checkIn_CheckInId",
                table: "Reservation",
                column: "CheckInId",
                principalTable: "checkIn",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adult_Reservation_ReservationId",
                table: "adult");

            migrationBuilder.DropForeignKey(
                name: "FK_children_Reservation_ReservationId",
                table: "children");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_checkIn_CheckInId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_CheckInId",
                table: "reservation",
                newName: "IX_reservation_CheckInId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservation",
                table: "reservation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_adult_reservation_ReservationId",
                table: "adult",
                column: "ReservationId",
                principalTable: "reservation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_children_reservation_ReservationId",
                table: "children",
                column: "ReservationId",
                principalTable: "reservation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reservation_checkIn_CheckInId",
                table: "reservation",
                column: "CheckInId",
                principalTable: "checkIn",
                principalColumn: "Id");
        }
    }
}
