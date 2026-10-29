using Application.SalesDailyEntries.Dtos;
using MediatR;

namespace Application.SalesDailyEntries.Commands.UpsertDailyEntry;

public record UpsertDailyEntryCommand(
    Guid StoreId,
    DateOnly Date,
    int AcqLowAchieved,
    int AcqHighAchieved,
    int CashNewAchieved,
    decimal TerminalAchieved,
    int DslAchieved,
    int ConnectivityAchieved,
    int EnterpriseNewAccountAchieved,
    int EnterpriseGaAchieved,
    int AmOneLine,
    int AmTwoLines,
    int AmThreeLines,
    int PmOneLine,
    int PmTwoLines,
    int PmThreeLines,
    int Mnp,
    int NewRed
) : IRequest<SalesDailyEntryDto>;
