namespace BeeKeeping.Data.Models;

public class AppConfiguration
{
    public int Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;

    public static class Keys
    {
        public const string DefaultTaxRate = "DefaultTaxRate";
    }
}
