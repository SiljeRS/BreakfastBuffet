using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakfastBuffet.Data.Migrations
{
    public partial class IdBreakfast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_checkIn_CheckInId",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "checkIn");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_CheckInId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CheckInId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Reservation");

            migrationBuilder.CreateTable(
                name: "Breakfast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NAdults = table.Column<int>(type: "int", nullable: false),
                    NChildren = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakfast", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breakfast");

            migrationBuilder.AddColumn<int>(
                name: "CheckInId",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Reservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "checkIn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkIn", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CheckInId",
                table: "Reservation",
                column: "CheckInId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_checkIn_CheckInId",
                table: "Reservation",
                column: "CheckInId",
                principalTable: "checkIn",
                principalColumn: "Id");
        }
    }
}
