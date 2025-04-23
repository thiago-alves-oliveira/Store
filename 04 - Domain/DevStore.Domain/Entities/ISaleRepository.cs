namespace DevStore.Domain.Entities;
public interface ISaleRepository
{
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IEnumerable<Sale>> ListAsync(CancellationToken ct = default);
    Task AddAsync(Sale sale, CancellationToken ct = default);
    Task UpdateAsync(Sale sale, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
