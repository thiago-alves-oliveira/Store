using DevStore.Domain.Entities;
using DevStore.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Infra.Repositories;
public class SaleRepository : ISaleRepository
{
    private readonly DevStoreDbContext _ctx;
    public SaleRepository(DevStoreDbContext ctx) => _ctx = ctx;
    public Task AddAsync(Sale sale, CancellationToken ct = default) { _ctx.Sales.Add(sale); return _ctx.SaveChangesAsync(ct); }
    public async Task DeleteAsync(Guid id, CancellationToken ct = default) { var s = await _ctx.Sales.FindAsync(new object[] { id }, ct); if (s != null) { _ctx.Remove(s); await _ctx.SaveChangesAsync(ct); } }
    public Task<Sale?> GetByIdAsync(Guid id, CancellationToken ct = default) => _ctx.Sales.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == id, ct);
    public async Task<IEnumerable<Sale>> ListAsync(CancellationToken ct = default) => await _ctx.Sales.Include(x => x.Items).ToListAsync(ct);
    public Task UpdateAsync(Sale sale, CancellationToken ct = default) { _ctx.Update(sale); return _ctx.SaveChangesAsync(ct); }
}
