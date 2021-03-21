using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StatisticsApp.Migrations
{
    public partial class centrallOficeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CentralOfice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    City = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Lngitude = table.Column<double>(type: "double", nullable: false),
                    Latitude = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentralOfice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OficeToUtms",
                columns: table => new
                {
                    UtmId = table.Column<int>(type: "int", nullable: false),
                    CentralOficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OficeToUtms", x => new { x.UtmId, x.CentralOficeId });
                    table.ForeignKey(
                        name: "FK_OficeToUtms_CentralOfice_CentralOficeId",
                        column: x => x.CentralOficeId,
                        principalTable: "CentralOfice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OficeToUtms_Utms_UtmId",
                        column: x => x.UtmId,
                        principalTable: "Utms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OficeToUtms_CentralOficeId",
                table: "OficeToUtms",
                column: "CentralOficeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OficeToUtms");

            migrationBuilder.DropTable(
                name: "CentralOfice");
        }
    }
}
