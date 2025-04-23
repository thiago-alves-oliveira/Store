using DevStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace DevStore.Infra.Persistence;
public class DevStoreDbContext : DbContext
{
    public DevStoreDbContext(DbContextOptions<DevStoreDbContext> opt) : base(opt) { }
    public DbSet<Sale> Sales => Set<Sale>();
    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Sale>(e =>
        {
            e.HasKey(s => s.Id);
            e.OwnsMany(s => s.Items, i =>
            {
                i.WithOwner().HasForeignKey("SaleId");
                i.Property<Guid>("Id");
                i.HasKey("Id");
            });
        });
    }
}
