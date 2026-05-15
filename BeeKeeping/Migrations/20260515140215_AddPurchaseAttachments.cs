using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeKeeping.Migrations
{
    /// <inheritdoc />
    public partial class AddPurchaseAttachments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipmentPurchaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    ContentType = table.Column<string>(type: "TEXT", nullable: false),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: false),
                    FileData = table.Column<byte[]>(type: "BLOB", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseAttachments_EquipmentPurchases_EquipmentPurchaseId",
                        column: x => x.EquipmentPurchaseId,
                        principalTable: "EquipmentPurchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAttachments_EquipmentPurchaseId",
                table: "PurchaseAttachments",
                column: "EquipmentPurchaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseAttachments");
        }
    }
}
