using Application.SalesDailyEntries.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.SalesDailyEntries.Queries.GetDailyEntriesByRange;

public class GetDailyEntriesByRangeQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetDailyEntriesByRangeQuery, IReadOnlyList<SalesDailyEntryDto>>
{
    public async Task<IReadOnlyList<SalesDailyEntryDto>> Handle(GetDailyEntriesByRangeQuery request, CancellationToken cancellationToken)
    {
        var entries = await unitOfWork.StoreDailyEntryRepository
            .GetByDateRangeAsync(request.From, request.To, cancellationToken);

        return entries.Select(ToDto).ToList();
    }

    private static SalesDailyEntryDto ToDto(StoreDailyEntry e) => new(
        e.Id, e.StoreId, e.Date,
        e.AcqLowAchieved, e.AcqHighAchieved, e.CashNewAchieved,
        e.TerminalAchieved, e.DslAchieved, e.ConnectivityAchieved,
        e.EnterpriseNewAccountAchieved, e.EnterpriseGaAchieved,
        e.AmOneLine, e.AmTwoLines, e.AmThreeLines,
        e.PmOneLine, e.PmTwoLines, e.PmThreeLines,
        e.Mnp, e.NewRed, e.CreatedDate, e.UpdateDate);
}
