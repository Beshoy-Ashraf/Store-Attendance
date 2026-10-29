using Application.SalesTargets.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.SalesTargets.Queries.GetAllTargets;

public class GetAllTargetsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllTargetsQuery, IReadOnlyList<StoreMonthlyTargetDto>>
{
    public async Task<IReadOnlyList<StoreMonthlyTargetDto>> Handle(GetAllTargetsQuery request, CancellationToken cancellationToken)
    {
        var targets = await unitOfWork.StoreMonthlyTargetRepository
            .GetByMonthAsync(request.Year, request.Month, cancellationToken);

        return targets.Select(ToDto).ToList();
    }

    private static StoreMonthlyTargetDto ToDto(StoreMonthlyTarget t) => new(
        t.Id, t.StoreId, t.Year, t.Month,
        t.AcqLow, t.AcqHigh, t.CashNew, t.Terminal,
        t.Dsl, t.Connectivity, t.EnterpriseNewAccount, t.EnterpriseGa,
        t.CreatedDate, t.UpdateDate);
}
