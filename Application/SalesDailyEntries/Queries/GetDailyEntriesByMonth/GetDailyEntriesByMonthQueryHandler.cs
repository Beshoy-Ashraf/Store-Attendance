using Application.SalesDailyEntries.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.SalesDailyEntries.Queries.GetDailyEntriesByMonth;

public class GetDailyEntriesByMonthQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetDailyEntriesByMonthQuery, IReadOnlyList<SalesDailyEntryDto>>
{
    public async Task<IReadOnlyList<SalesDailyEntryDto>> Handle(GetDailyEntriesByMonthQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<StoreDailyEntry> entries;

        if (request.StoreId.HasValue)
            entries = await unitOfWork.StoreDailyEntryRepository
                .GetByStoreAndMonthAsync(request.StoreId.Value, request.Year, request.Month, cancellationToken);
        else
            entries = await unitOfWork.StoreDailyEntryRepository
                .GetByMonthAsync(request.Year, request.Month, cancellationToken);

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
