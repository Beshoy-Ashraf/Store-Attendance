namespace Application.SalesTargets.Dtos;

public record StoreMonthlyTargetDto(
    Guid Id,
    Guid StoreId,
    int Year,
    int Month,
    int AcqLow,
    int AcqHigh,
    int CashNew,
    decimal Terminal,
    int Dsl,
    int Connectivity,
    int EnterpriseNewAccount,
    int EnterpriseGa,
    DateTime CreatedDate,
    DateTime? UpdateDate
);
