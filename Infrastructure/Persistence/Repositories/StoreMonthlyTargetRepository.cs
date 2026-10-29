using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class StoreMonthlyTargetRepository(AppDbContext context)
    : BaseRepository<StoreMonthlyTarget>(context), IStoreMonthlyTargetRepository
{
    private readonly AppDbContext _context = context;

    public async Task<StoreMonthlyTarget?> GetByStoreAndMonthAsync(Guid storeId, int year, int month, CancellationToken cancellationToken) =>
        await _context.Set<StoreMonthlyTarget>()
            .FirstOrDefaultAsync(t => t.StoreId == storeId && t.Year == year && t.Month == month, cancellationToken);

    public async Task<IReadOnlyList<StoreMonthlyTarget>> GetByMonthAsync(int year, int month, CancellationToken cancellationToken) =>
        await _context.Set<StoreMonthlyTarget>()
            .Where(t => t.Year == year && t.Month == month)
            .ToListAsync(cancellationToken);
}
