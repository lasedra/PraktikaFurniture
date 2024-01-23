using Microsoft.EntityFrameworkCore;

namespace PraktikaFurniture.Models;

public partial class FurnitureContext : DbContext
{
    public static FurnitureContext dbContext = new FurnitureContext();

    public FurnitureContext()
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost;Database=Furniture;UserName=postgres;Password=password");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.ProductCode, "Products_ProductCode_key").IsUnique();

            entity.Property(e => e.Price).HasPrecision(10, 2);
            entity.Property(e => e.ProductCode).HasMaxLength(20);
            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.Unit).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
