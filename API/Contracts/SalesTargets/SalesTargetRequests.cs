namespace API.Contracts.SalesTargets;

public record UpsertMonthlyTargetRequest(
    int AcqLow,
    int AcqHigh,
    int CashNew,
    decimal Terminal,
    int Dsl,
    int Connectivity,
    int EnterpriseNewAccount,
    int EnterpriseGa
);
