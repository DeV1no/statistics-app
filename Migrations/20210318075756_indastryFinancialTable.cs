using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StatisticsApp.Migrations
{
    public partial class indastryFinancialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndustryFinancials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MaxSalary = table.Column<double>(type: "double", nullable: false),
                    MinSalary = table.Column<double>(type: "double", nullable: false),
                    isExemptTax = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AverageSalary = table.Column<double>(type: "double", nullable: false),
                    Exempt = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryFinancials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "financialToIndustries",
                columns: table => new
                {
                    UtmId = table.Column<int>(type: "int", nullable: false),
                    IndustryFinancialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financialToIndustries", x => new { x.UtmId, x.IndustryFinancialId });
                    table.ForeignKey(
                        name: "FK_financialToIndustries_IndustryFinancials_IndustryFinancialId",
                        column: x => x.IndustryFinancialId,
                        principalTable: "IndustryFinancials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_financialToIndustries_Utms_UtmId",
                        column: x => x.UtmId,
                        principalTable: "Utms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_financialToIndustries_IndustryFinancialId",
                table: "financialToIndustries",
                column: "IndustryFinancialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "financialToIndustries");

            migrationBuilder.DropTable(
                name: "IndustryFinancials");
        }
    }
}
