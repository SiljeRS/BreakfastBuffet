using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakfastBuffet.Data.Migrations
{
    public partial class dateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adult_Reservation_ReservationId",
                table: "adult");

            migrationBuilder.DropForeignKey(
                name: "FK_children_Reservation_ReservationId",
                table: "children");

            migrationBuilder.DropIndex(
                name: "IX_children_ReservationId",
                table: "children");

            migrationBuilder.DropIndex(
                name: "IX_adult_ReservationId",
                table: "adult");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "children");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "adult");

            migrationBuilder.AddColumn<int>(
                name: "CheckInOverviewId",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NrAdults",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NrChildren",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CheckInOverview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckInOverview", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CheckInOverviewId",
                table: "Reservation",
                column: "CheckInOverviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_CheckInOverview_CheckInOverviewId",
                table: "Reservation",
                column: "CheckInOverviewId",
                principalTable: "CheckInOverview",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_CheckInOverview_CheckInOverviewId",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "CheckInOverview");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_CheckInOverviewId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CheckInOverviewId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "NrAdults",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "NrChildren",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "children",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "adult",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_children_ReservationId",
                table: "children",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_adult_ReservationId",
                table: "adult",
                column: "ReservationId");

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
        }
    }
}
