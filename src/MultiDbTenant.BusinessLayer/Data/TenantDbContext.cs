using MultiDbTenant.BusinessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace MultiDbTenant.BusinessLayer.Data;

public class TenantDbContext(DbContextOptions<TenantDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().ToTable("Product");
        // Additional configurations can be added here
    }
    
}