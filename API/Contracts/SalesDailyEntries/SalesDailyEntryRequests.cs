namespace API.Contracts.SalesDailyEntries;

public record UpsertDailyEntryRequest(
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
);
