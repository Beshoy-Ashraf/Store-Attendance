namespace Application.SalesDailyEntries.Dtos;

public record SalesDailyEntryDto(
    Guid Id,
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
    int NewRed,
    DateTime CreatedDate,
    DateTime? UpdateDate
);
