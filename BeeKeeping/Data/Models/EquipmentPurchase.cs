namespace BeeKeeping.Data.Models;

public class EquipmentPurchase
{
    public int Id { get; set; }
    public DateOnly PurchaseDate { get; set; }
    public string Vendor { get; set; } = string.Empty;
    public string ReceiptReference { get; set; } = string.Empty;
    public int TaxYear { get; set; }
    public bool IsDeductible { get; set; } = true;
    public string Notes { get; set; } = string.Empty;
    public decimal SalesTax { get; set; } = 0m;
    public decimal Shipping { get; set; } = 0m;
    public decimal Discount { get; set; } = 0m;
    public ICollection<EquipmentPurchaseItem> Items { get; set; } = [];
    public ICollection<PurchaseAttachment> Attachments { get; set; } = [];
    public decimal Subtotal => Items.Sum(i => i.LineTotal);
    public decimal TotalCost => Subtotal + SalesTax + Shipping - Discount;
}
