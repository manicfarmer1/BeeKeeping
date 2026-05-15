namespace BeeKeeping.Data.Models;

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int QuantityOnHand { get; set; }
    public string Notes { get; set; } = string.Empty;
    public string ExpenseCategory { get; set; } = ExpenseCategories.Equipment;
    public ICollection<EquipmentPurchaseItem> PurchaseItems { get; set; } = [];
}

public static class ExpenseCategories
{
    public const string Consumable = "Consumable";
    public const string SmallTool = "Small Tool";
    public const string Equipment = "Equipment";
    public const string CapitalEquipment = "Capital Equipment";
    public const string Structure = "Structure";

    public static readonly string[] All =
    [
        Consumable, SmallTool, Equipment, CapitalEquipment, Structure
    ];

    public static string TaxTreatmentNote(string category) => category switch
    {
        Consumable => "Fully expensed in year purchased",
        SmallTool => "Fully expensed — Section 179",
        Equipment => "Section 179 or 5-yr MACRS",
        CapitalEquipment => "Section 179 or 5–7 yr MACRS",
        Structure => "15–39 yr depreciation",
        _ => string.Empty
    };
}

