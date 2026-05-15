using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeKeeping.Migrations
{
    /// <inheritdoc />
    public partial class AddPurchaseLineItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentPurchases_Equipment_EquipmentId",
                table: "EquipmentPurchases");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentPurchases_EquipmentId",
                table: "EquipmentPurchases");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "EquipmentPurchases");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "EquipmentPurchases");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "EquipmentPurchases");

            migrationBuilder.CreateTable(
                name: "EquipmentPurchaseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipmentPurchaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentPurchaseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentPurchaseItems_EquipmentPurchases_EquipmentPurchaseId",
                        column: x => x.EquipmentPurchaseId,
                        principalTable: "EquipmentPurchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentPurchaseItems_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPurchaseItems_EquipmentId",
                table: "EquipmentPurchaseItems",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPurchaseItems_EquipmentPurchaseId",
                table: "EquipmentPurchaseItems",
                column: "EquipmentPurchaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentPurchaseItems");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "EquipmentPurchases",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "EquipmentPurchases",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "EquipmentPurchases",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPurchases_EquipmentId",
                table: "EquipmentPurchases",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentPurchases_Equipment_EquipmentId",
                table: "EquipmentPurchases",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
