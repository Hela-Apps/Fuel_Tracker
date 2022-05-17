using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class changeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
