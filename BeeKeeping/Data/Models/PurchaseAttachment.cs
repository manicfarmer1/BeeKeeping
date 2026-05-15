namespace BeeKeeping.Data.Models;

public class PurchaseAttachment
{
    public int Id { get; set; }
    public int EquipmentPurchaseId { get; set; }
    public EquipmentPurchase EquipmentPurchase { get; set; } = null!;
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public byte[] FileData { get; set; } = [];
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}
