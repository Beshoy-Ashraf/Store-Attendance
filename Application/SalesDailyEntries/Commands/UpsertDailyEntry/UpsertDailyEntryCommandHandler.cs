using Application.SalesDailyEntries.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.SalesDailyEntries.Commands.UpsertDailyEntry;

public class UpsertDailyEntryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpsertDailyEntryCommand, SalesDailyEntryDto>
{
    public async Task<SalesDailyEntryDto> Handle(UpsertDailyEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await unitOfWork.StoreDailyEntryRepository
            .GetByStoreAndDateAsync(request.StoreId, request.Date, cancellationToken);

        if (entry is null)
        {
            entry = new StoreDailyEntry
            {
                Id = Guid.NewGuid(),
                StoreId = request.StoreId,
                Date = request.Date,
                CreatedDate = DateTime.UtcNow
            };
            Apply(entry, request);
            await unitOfWork.StoreDailyEntryRepository.AddAsync(entry, cancellationToken);
        }
        else
        {
            Apply(entry, request);
            entry.UpdateDate = DateTime.UtcNow;
        }

        await unitOfWork.Complete(cancellationToken);
        return ToDto(entry);
    }

    private static void Apply(StoreDailyEntry e, UpsertDailyEntryCommand r)
    {
        e.AcqLowAchieved = r.AcqLowAchieved;
        e.AcqHighAchieved = r.AcqHighAchieved;
        e.CashNewAchieved = r.CashNewAchieved;
        e.TerminalAchieved = r.TerminalAchieved;
        e.DslAchieved = r.DslAchieved;
        e.ConnectivityAchieved = r.ConnectivityAchieved;
        e.EnterpriseNewAccountAchieved = r.EnterpriseNewAccountAchieved;
        e.EnterpriseGaAchieved = r.EnterpriseGaAchieved;
        e.AmOneLine = r.AmOneLine;
        e.AmTwoLines = r.AmTwoLines;
        e.AmThreeLines = r.AmThreeLines;
        e.PmOneLine = r.PmOneLine;
        e.PmTwoLines = r.PmTwoLines;
        e.PmThreeLines = r.PmThreeLines;
        e.Mnp = r.Mnp;
        e.NewRed = r.NewRed;
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
