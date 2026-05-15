namespace BeeKeeping.Data.Models;

public class EquipmentPurchaseItem
{
    public int Id { get; set; }
    public int EquipmentPurchaseId { get; set; }
    public EquipmentPurchase EquipmentPurchase { get; set; } = null!;
    public int EquipmentId { get; set; }
    public Equipment Equipment { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal => Quantity * UnitPrice;
}

