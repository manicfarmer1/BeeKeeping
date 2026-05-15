using BeeKeeping.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeKeeping.Data;

public class BeeKeepingDbContext(DbContextOptions<BeeKeepingDbContext> options) : DbContext(options)
{
    public DbSet<Hive> Hives => Set<Hive>();
    public DbSet<Equipment> Equipment => Set<Equipment>();
    public DbSet<EquipmentPurchase> EquipmentPurchases => Set<EquipmentPurchase>();
    public DbSet<EquipmentPurchaseItem> EquipmentPurchaseItems => Set<EquipmentPurchaseItem>();
    public DbSet<Inspection> Inspections => Set<Inspection>();
    public DbSet<PurchaseAttachment> PurchaseAttachments => Set<PurchaseAttachment>();
    public DbSet<AppConfiguration> AppConfigurations => Set<AppConfiguration>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EquipmentPurchaseItem>()
            .Property(i => i.UnitPrice)
            .HasColumnType("TEXT");

        modelBuilder.Entity<EquipmentPurchaseItem>()
            .Ignore(i => i.LineTotal);

        modelBuilder.Entity<EquipmentPurchase>()
            .Property(p => p.SalesTax)
            .HasColumnType("TEXT");

        modelBuilder.Entity<EquipmentPurchase>()
            .Property(p => p.Shipping)
            .HasColumnType("TEXT");

        modelBuilder.Entity<EquipmentPurchase>()
            .Property(p => p.Discount)
            .HasColumnType("TEXT");

        modelBuilder.Entity<EquipmentPurchase>()
            .Ignore(p => p.Subtotal);

        modelBuilder.Entity<EquipmentPurchase>()
            .Ignore(p => p.TotalCost);

        modelBuilder.Entity<AppConfiguration>()
            .HasIndex(c => c.Key)
            .IsUnique();

        modelBuilder.Entity<Inspection>()
            .Property(i => i.VarroaMiteCount)
            .HasColumnType("TEXT");

        modelBuilder.Entity<Hive>()
            .HasMany(h => h.Inspections)
            .WithOne(i => i.Hive)
            .HasForeignKey(i => i.HiveId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EquipmentPurchase>()
            .HasMany(p => p.Items)
            .WithOne(i => i.EquipmentPurchase)
            .HasForeignKey(i => i.EquipmentPurchaseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EquipmentPurchase>()
            .HasMany(p => p.Attachments)
            .WithOne(a => a.EquipmentPurchase)
            .HasForeignKey(a => a.EquipmentPurchaseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
