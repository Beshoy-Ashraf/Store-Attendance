using Application.SalesTargets.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.SalesTargets.Commands.UpsertMonthlyTarget;

public class UpsertMonthlyTargetCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpsertMonthlyTargetCommand, StoreMonthlyTargetDto>
{
    public async Task<StoreMonthlyTargetDto> Handle(UpsertMonthlyTargetCommand request, CancellationToken cancellationToken)
    {
        var target = await unitOfWork.StoreMonthlyTargetRepository
            .GetByStoreAndMonthAsync(request.StoreId, request.Year, request.Month, cancellationToken);

        if (target is null)
        {
            target = new StoreMonthlyTarget
            {
                Id = Guid.NewGuid(),
                StoreId = request.StoreId,
                Year = request.Year,
                Month = request.Month,
                CreatedDate = DateTime.UtcNow
            };
            Apply(target, request);
            await unitOfWork.StoreMonthlyTargetRepository.AddAsync(target, cancellationToken);
        }
        else
        {
            Apply(target, request);
            target.UpdateDate = DateTime.UtcNow;
        }

        await unitOfWork.Complete(cancellationToken);
        return ToDto(target);
    }

    private static void Apply(StoreMonthlyTarget t, UpsertMonthlyTargetCommand r)
    {
        t.AcqLow = r.AcqLow;
        t.AcqHigh = r.AcqHigh;
        t.CashNew = r.CashNew;
        t.Terminal = r.Terminal;
        t.Dsl = r.Dsl;
        t.Connectivity = r.Connectivity;
        t.EnterpriseNewAccount = r.EnterpriseNewAccount;
        t.EnterpriseGa = r.EnterpriseGa;
    }

    private static StoreMonthlyTargetDto ToDto(StoreMonthlyTarget t) => new(
        t.Id, t.StoreId, t.Year, t.Month,
        t.AcqLow, t.AcqHigh, t.CashNew, t.Terminal,
        t.Dsl, t.Connectivity, t.EnterpriseNewAccount, t.EnterpriseGa,
        t.CreatedDate, t.UpdateDate);
}
