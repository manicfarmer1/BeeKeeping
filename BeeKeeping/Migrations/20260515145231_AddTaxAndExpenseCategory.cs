using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeKeeping.Migrations
{
    /// <inheritdoc />
    public partial class AddTaxAndExpenseCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ExpenseCategory",
                table: "Equipment",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AppConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigurations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppConfigurations",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 1, "DefaultTaxRate", "0.0825" });

            migrationBuilder.CreateIndex(
                name: "IX_AppConfigurations_Key",
                table: "AppConfigurations",
                column: "Key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfigurations");

            migrationBuilder.DropColumn(
                name: "IsTaxable",
                table: "EquipmentPurchaseItems");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                table: "EquipmentPurchaseItems");

            migrationBuilder.DropColumn(
                name: "ExpenseCategory",
                table: "Equipment");
        }
    }
}
