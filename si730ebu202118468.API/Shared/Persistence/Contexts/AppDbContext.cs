using Microsoft.EntityFrameworkCore;
using si730ebu202118468.API.Inventory.Domain.Models;
using si730ebu202118468.API.Maintenance.Domain.Models;
using si730ebu202118468.API.Shared.Extensions;

namespace si730ebu202118468.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<MantainanceActivity> MantainanceActivities { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Brand).IsRequired();
        builder.Entity<Product>().Property(p => p.Model).IsRequired();
        builder.Entity<Product>().Property(p => p.SerialNumber).IsRequired();
        builder.Entity<Product>().Property(p => p.Status).IsRequired();
        builder.Entity<Product>().Ignore(p => p.StatusDescription);

        builder.Entity<MantainanceActivity>().ToTable("MantainanceActivities");
        builder.Entity<MantainanceActivity>().HasKey(m => m.Id);
        builder.Entity<MantainanceActivity>().Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MantainanceActivity>().Property(m => m.ProductSerialNumber).IsRequired();
        builder.Entity<MantainanceActivity>().Property(m => m.Summary).IsRequired();
        builder.Entity<MantainanceActivity>().Property(m => m.Description);
        builder.Entity<MantainanceActivity>().Property(m => m.ActivityResult).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}