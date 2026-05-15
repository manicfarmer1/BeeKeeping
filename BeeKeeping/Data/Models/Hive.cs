namespace BeeKeeping.Data.Models;

public class Hive
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateOnly EstablishedDate { get; set; }
    public string QueenStatus { get; set; } = "Unknown";
    public string BeeBreed { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public string Notes { get; set; } = string.Empty;
    public ICollection<Inspection> Inspections { get; set; } = [];
}
