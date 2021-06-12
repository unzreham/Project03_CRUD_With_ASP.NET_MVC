using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KSAFinestSightseeingTours.Migrations
{
    public partial class version1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(type: "varchar(500)", nullable: true),
                    Description = table.Column<string>(type: "varchar(600)", nullable: true),
                    AdultPrice = table.Column<string>(type: "varchar(50)", nullable: true),
                    ChildPrice = table.Column<string>(type: "varchar(50)", nullable: true),
                    PickupLocation = table.Column<string>(type: "varchar(100)", nullable: true),
                    ReturnsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
