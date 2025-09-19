using Microsoft.EntityFrameworkCore;

namespace LAB3_MDK01._04.NAZAROV.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options): base(options){}
    public DbSet<PriceList> PriceLists => Set<PriceList>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<MyUser>  MyUsers => Set<MyUser>();
}