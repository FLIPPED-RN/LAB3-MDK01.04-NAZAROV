using Microsoft.EntityFrameworkCore;

namespace LAB3_MDK01._04.NAZAROV.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options): base(options){}
    public DbSet<PriceList> PriceLists { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<MyUser>  MyUsers => Set<MyUser>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PriceList>()
            .Property(p => p.UnitPrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Sale>()
            .Property(s => s.TotalPrice)
            .HasColumnType("decimal(18,2)");
    }
}