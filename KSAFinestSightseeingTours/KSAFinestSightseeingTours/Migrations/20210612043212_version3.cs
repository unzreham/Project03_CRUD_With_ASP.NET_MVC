using Microsoft.EntityFrameworkCore.Migrations;

namespace KSAFinestSightseeingTours.Migrations
{
    public partial class version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Includeds_TourId",
                table: "Includeds");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tours",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adult = table.Column<int>(type: "int", nullable: false),
                    child = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: true),
                    TourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.id);
                    table.ForeignKey(
                        name: "FK_Booking_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(50)", nullable: true),
                    password = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tours_UserId",
                table: "Tours",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Includeds_TourId",
                table: "Includeds",
                column: "TourId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TourId",
                table: "Booking",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_User_UserId",
                table: "Tours",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_User_UserId",
                table: "Tours");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Tours_UserId",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Includeds_TourId",
                table: "Includeds");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tours");

            migrationBuilder.CreateIndex(
                name: "IX_Includeds_TourId",
                table: "Includeds",
                column: "TourId");
        }
    }
}
