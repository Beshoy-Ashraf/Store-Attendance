using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreDailyEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    AcqLowAchieved = table.Column<int>(type: "integer", nullable: false),
                    AcqHighAchieved = table.Column<int>(type: "integer", nullable: false),
                    CashNewAchieved = table.Column<int>(type: "integer", nullable: false),
                    TerminalAchieved = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    DslAchieved = table.Column<int>(type: "integer", nullable: false),
                    ConnectivityAchieved = table.Column<int>(type: "integer", nullable: false),
                    EnterpriseNewAccountAchieved = table.Column<int>(type: "integer", nullable: false),
                    EnterpriseGaAchieved = table.Column<int>(type: "integer", nullable: false),
                    AmOneLine = table.Column<int>(type: "integer", nullable: false),
                    AmTwoLines = table.Column<int>(type: "integer", nullable: false),
                    AmThreeLines = table.Column<int>(type: "integer", nullable: false),
                    PmOneLine = table.Column<int>(type: "integer", nullable: false),
                    PmTwoLines = table.Column<int>(type: "integer", nullable: false),
                    PmThreeLines = table.Column<int>(type: "integer", nullable: false),
                    Mnp = table.Column<int>(type: "integer", nullable: false),
                    NewRed = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreDailyEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreDailyEntries_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreMonthlyTargets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    AcqLow = table.Column<int>(type: "integer", nullable: false),
                    AcqHigh = table.Column<int>(type: "integer", nullable: false),
                    CashNew = table.Column<int>(type: "integer", nullable: false),
                    Terminal = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Dsl = table.Column<int>(type: "integer", nullable: false),
                    Connectivity = table.Column<int>(type: "integer", nullable: false),
                    EnterpriseNewAccount = table.Column<int>(type: "integer", nullable: false),
                    EnterpriseGa = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreMonthlyTargets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreMonthlyTargets_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreDailyEntries_StoreId_Date",
                table: "StoreDailyEntries",
                columns: new[] { "StoreId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreMonthlyTargets_StoreId_Year_Month",
                table: "StoreMonthlyTargets",
                columns: new[] { "StoreId", "Year", "Month" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreDailyEntries");

            migrationBuilder.DropTable(
                name: "StoreMonthlyTargets");
        }
    }
}
