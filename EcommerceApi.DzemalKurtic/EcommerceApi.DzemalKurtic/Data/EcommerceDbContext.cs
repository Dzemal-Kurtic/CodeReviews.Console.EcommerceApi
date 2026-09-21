using EcommerceApi.DzemalKurtic.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.DzemalKurtic.Data;

public class EcommerceDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Product>()
            .HasQueryFilter(p => !p.IsDeleted && !p.Category.IsDeleted);

        modelBuilder.Entity<SaleItem>()
            .HasOne(i => i.Product)
            .WithMany(p => p.SaleItems)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);
        modelBuilder.Entity<SaleItem>().Property(i => i.SalePrice).HasPrecision(18, 2);
    }
}
