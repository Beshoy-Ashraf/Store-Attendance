using Application.SalesDailyEntries.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.SalesDailyEntries.Queries.GetDailyEntry;

public class GetDailyEntryQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetDailyEntryQuery, SalesDailyEntryDto?>
{
    public async Task<SalesDailyEntryDto?> Handle(GetDailyEntryQuery request, CancellationToken cancellationToken)
    {
        var entry = await unitOfWork.StoreDailyEntryRepository
            .GetByStoreAndDateAsync(request.StoreId, request.Date, cancellationToken);

        return entry is null ? null : ToDto(entry);
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
