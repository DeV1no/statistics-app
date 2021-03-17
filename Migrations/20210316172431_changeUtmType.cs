using Microsoft.EntityFrameworkCore.Migrations;

namespace StatisticsApp.Migrations
{
    public partial class changeUtmType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "latitude",
                table: "Utms",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Lngitude",
                table: "Utms",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "latitude",
                table: "Utms",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<string>(
                name: "Lngitude",
                table: "Utms",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
