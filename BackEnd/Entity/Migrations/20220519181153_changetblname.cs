using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class changetblname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StationFuelType");

            migrationBuilder.CreateTable(
                name: "StationFuelDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Availability = table.Column<bool>(nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationFuelDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StationFuelDetail");

            migrationBuilder.CreateTable(
                name: "StationFuelType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    FuelTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationFuelType", x => x.Id);
                });
        }
    }
}
