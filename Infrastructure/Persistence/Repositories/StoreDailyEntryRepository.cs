using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class StoreDailyEntryRepository(AppDbContext context)
    : BaseRepository<StoreDailyEntry>(context), IStoreDailyEntryRepository
{
    private readonly AppDbContext _context = context;

    public async Task<StoreDailyEntry?> GetByStoreAndDateAsync(Guid storeId, DateOnly date, CancellationToken cancellationToken) =>
        await _context.Set<StoreDailyEntry>()
            .FirstOrDefaultAsync(e => e.StoreId == storeId && e.Date == date, cancellationToken);

    public async Task<IReadOnlyList<StoreDailyEntry>> GetByStoreAndMonthAsync(Guid storeId, int year, int month, CancellationToken cancellationToken) =>
        await _context.Set<StoreDailyEntry>()
            .Where(e => e.StoreId == storeId && e.Date.Year == year && e.Date.Month == month)
            .OrderBy(e => e.Date)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<StoreDailyEntry>> GetByMonthAsync(int year, int month, CancellationToken cancellationToken) =>
        await _context.Set<StoreDailyEntry>()
            .Where(e => e.Date.Year == year && e.Date.Month == month)
            .OrderBy(e => e.StoreId).ThenBy(e => e.Date)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<StoreDailyEntry>> GetByDateRangeAsync(DateOnly from, DateOnly to, CancellationToken cancellationToken) =>
        await _context.Set<StoreDailyEntry>()
            .Where(e => e.Date >= from && e.Date <= to)
            .OrderBy(e => e.StoreId).ThenBy(e => e.Date)
            .ToListAsync(cancellationToken);
}
