using Domain.Entities;

namespace Domain.Interfaces;

public interface IStoreDailyEntryRepository : IBaseRepository<StoreDailyEntry>
{
    Task<StoreDailyEntry?> GetByStoreAndDateAsync(Guid storeId, DateOnly date, CancellationToken cancellationToken);

    Task<IReadOnlyList<StoreDailyEntry>> GetByStoreAndMonthAsync(Guid storeId, int year, int month, CancellationToken cancellationToken);

    Task<IReadOnlyList<StoreDailyEntry>> GetByMonthAsync(int year, int month, CancellationToken cancellationToken);

    Task<IReadOnlyList<StoreDailyEntry>> GetByDateRangeAsync(DateOnly from, DateOnly to, CancellationToken cancellationToken);
}
