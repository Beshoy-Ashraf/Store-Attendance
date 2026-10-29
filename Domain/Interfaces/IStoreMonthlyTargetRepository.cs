using Domain.Entities;

namespace Domain.Interfaces;

public interface IStoreMonthlyTargetRepository : IBaseRepository<StoreMonthlyTarget>
{
    Task<StoreMonthlyTarget?> GetByStoreAndMonthAsync(Guid storeId, int year, int month, CancellationToken cancellationToken);

    Task<IReadOnlyList<StoreMonthlyTarget>> GetByMonthAsync(int year, int month, CancellationToken cancellationToken);
}
