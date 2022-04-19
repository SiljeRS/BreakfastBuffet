using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakfastBuffet.Data.Migrations
{
    public partial class AddMigrationCreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNr = table.Column<int>(type: "int", nullable: false),
                    CheckInId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservation_checkIn_CheckInId",
                        column: x => x.CheckInId,
                        principalTable: "checkIn",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckedIn = table.Column<bool>(type: "bit", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adult_reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckedIn = table.Column<bool>(type: "bit", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_children_reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_adult_ReservationId",
                table: "adult",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_children_ReservationId",
                table: "children",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_CheckInId",
                table: "reservation",
                column: "CheckInId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adult");

            migrationBuilder.DropTable(
                name: "children");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "checkIn");
        }
    }
}
