using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeKeeping.Migrations
{
    /// <inheritdoc />
    public partial class SimplifyTaxToHeaderAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigurations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "IsTaxable",
                table: "EquipmentPurchaseItems");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                table: "EquipmentPurchaseItems");

            migrationBuilder.AddColumn<decimal>(
                name: "SalesTax",
                table: "EquipmentPurchases",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesTax",
                table: "EquipmentPurchases");

            migrationBuilder.AddColumn<bool>(
                name: "IsTaxable",
                table: "EquipmentPurchaseItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate",
                table: "EquipmentPurchaseItems",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AppConfigurations",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 1, "DefaultTaxRate", "0.0825" });
        }
    }
}
