using BeeKeeping.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeKeeping.Data;

public class AppConfigurationService(IDbContextFactory<BeeKeepingDbContext> dbFactory)
{
    public async Task<decimal> GetDefaultTaxRateAsync()
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        var row = await db.AppConfigurations
            .FirstOrDefaultAsync(c => c.Key == AppConfiguration.Keys.DefaultTaxRate);
        return row != null && decimal.TryParse(row.Value, out var rate) ? rate : 0.0825m;
    }

    public async Task SetDefaultTaxRateAsync(decimal rate)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        var row = await db.AppConfigurations
            .FirstOrDefaultAsync(c => c.Key == AppConfiguration.Keys.DefaultTaxRate);
        if (row == null)
        {
            db.AppConfigurations.Add(new AppConfiguration
            {
                Key = AppConfiguration.Keys.DefaultTaxRate,
                Value = rate.ToString("G")
            });
        }
        else
        {
            row.Value = rate.ToString("G");
        }
        await db.SaveChangesAsync();
    }
}
