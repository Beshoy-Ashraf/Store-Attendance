using Application.SalesTargets.Dtos;
using MediatR;

namespace Application.SalesTargets.Commands.UpsertMonthlyTarget;

public record UpsertMonthlyTargetCommand(
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
    int EnterpriseGa
) : IRequest<StoreMonthlyTargetDto>;
