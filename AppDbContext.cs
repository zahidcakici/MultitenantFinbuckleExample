using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MultitenantExample;

public class AppDbContext : MultiTenantDbContext
{
    public DbSet<Product> Products { get; set; }

    public AppDbContext(ITenantInfo tenantInfo) : base(tenantInfo)
    {
    }

    public AppDbContext(ITenantInfo tenantInfo, DbContextOptions options) : base(tenantInfo, options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().IsMultiTenant();
        base.OnModelCreating(modelBuilder);
    }
}