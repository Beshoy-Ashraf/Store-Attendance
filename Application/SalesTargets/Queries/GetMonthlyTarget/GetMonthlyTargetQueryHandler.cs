using Application.SalesTargets.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.SalesTargets.Queries.GetMonthlyTarget;

public class GetMonthlyTargetQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetMonthlyTargetQuery, StoreMonthlyTargetDto?>
{
    public async Task<StoreMonthlyTargetDto?> Handle(GetMonthlyTargetQuery request, CancellationToken cancellationToken)
    {
        var target = await unitOfWork.StoreMonthlyTargetRepository
            .GetByStoreAndMonthAsync(request.StoreId, request.Year, request.Month, cancellationToken);

        return target is null ? null : ToDto(target);
    }

    private static StoreMonthlyTargetDto ToDto(StoreMonthlyTarget t) => new(
        t.Id, t.StoreId, t.Year, t.Month,
        t.AcqLow, t.AcqHigh, t.CashNew, t.Terminal,
        t.Dsl, t.Connectivity, t.EnterpriseNewAccount, t.EnterpriseGa,
        t.CreatedDate, t.UpdateDate);
}
