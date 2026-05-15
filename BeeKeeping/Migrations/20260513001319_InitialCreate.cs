using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeKeeping.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    QuantityOnHand = table.Column<int>(type: "INTEGER", nullable: false),
                    Condition = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    EstablishedDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    QueenStatus = table.Column<string>(type: "TEXT", nullable: false),
                    BeeBreed = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentPurchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    PurchaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Vendor = table.Column<string>(type: "TEXT", nullable: false),
                    ReceiptReference = table.Column<string>(type: "TEXT", nullable: false),
                    TaxYear = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeductible = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentPurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentPurchases_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HiveId = table.Column<int>(type: "INTEGER", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Inspector = table.Column<string>(type: "TEXT", nullable: false),
                    QueenSeen = table.Column<string>(type: "TEXT", nullable: false),
                    EggsSeen = table.Column<bool>(type: "INTEGER", nullable: false),
                    LarvaeSeen = table.Column<bool>(type: "INTEGER", nullable: false),
                    BroodPattern = table.Column<string>(type: "TEXT", nullable: false),
                    HoneyStoresRating = table.Column<int>(type: "INTEGER", nullable: false),
                    PopulationRating = table.Column<int>(type: "INTEGER", nullable: false),
                    TemperamentRating = table.Column<string>(type: "TEXT", nullable: false),
                    VarroaMiteCheck = table.Column<bool>(type: "INTEGER", nullable: false),
                    VarroaMiteCount = table.Column<decimal>(type: "TEXT", nullable: true),
                    Treatments = table.Column<string>(type: "TEXT", nullable: false),
                    ActionsTaken = table.Column<string>(type: "TEXT", nullable: false),
                    NextSteps = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    WeatherConditions = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspections_Hives_HiveId",
                        column: x => x.HiveId,
                        principalTable: "Hives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPurchases_EquipmentId",
                table: "EquipmentPurchases",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_HiveId",
                table: "Inspections",
                column: "HiveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentPurchases");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Hives");
        }
    }
}
