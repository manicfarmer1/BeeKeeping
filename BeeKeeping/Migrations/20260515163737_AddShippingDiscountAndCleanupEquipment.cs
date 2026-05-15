using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeKeeping.Migrations
{
    /// <inheritdoc />
    public partial class AddShippingDiscountAndCleanupEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Equipment");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "EquipmentPurchases",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Shipping",
                table: "EquipmentPurchases",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "EquipmentPurchases");

            migrationBuilder.DropColumn(
                name: "Shipping",
                table: "EquipmentPurchases");

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Equipment",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
