namespace BeeKeeping.Data.Models;

public class Inspection
{
    public int Id { get; set; }
    public int HiveId { get; set; }
    public Hive Hive { get; set; } = null!;
    public DateTime InspectionDate { get; set; }
    public string Inspector { get; set; } = string.Empty;
    public string QueenSeen { get; set; } = "Unknown";
    public bool EggsSeen { get; set; }
    public bool LarvaeSeen { get; set; }
    public string BroodPattern { get; set; } = string.Empty;
    public int HoneyStoresRating { get; set; }
    public int PopulationRating { get; set; }
    public string TemperamentRating { get; set; } = "Calm";
    public bool VarroaMiteCheck { get; set; }
    public decimal? VarroaMiteCount { get; set; }
    public string Treatments { get; set; } = string.Empty;
    public string ActionsTaken { get; set; } = string.Empty;
    public string NextSteps { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public string WeatherConditions { get; set; } = string.Empty;
}
