using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class changename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdsCategory",
                table: "AdsCategory");

            migrationBuilder.RenameTable(
                name: "AdsCategory",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "AdsCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdsCategory",
                table: "AdsCategory",
                column: "Id");
        }
    }
}
