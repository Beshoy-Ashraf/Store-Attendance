using Application.SalesTargets.Dtos;
using MediatR;

namespace Application.SalesTargets.Queries.GetMonthlyTarget;

public record GetMonthlyTargetQuery(Guid StoreId, int Year, int Month) : IRequest<StoreMonthlyTargetDto?>;
