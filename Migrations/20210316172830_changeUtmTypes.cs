using Microsoft.EntityFrameworkCore.Migrations;

namespace StatisticsApp.Migrations
{
    public partial class changeUtmTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Utms",
                newName: "Latitude");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Utms",
                newName: "latitude");
        }
    }
}
