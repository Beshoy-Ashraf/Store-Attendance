using Application.SalesTargets.Dtos;
using MediatR;

namespace Application.SalesTargets.Queries.GetAllTargets;

public record GetAllTargetsQuery(int Year, int Month) : IRequest<IReadOnlyList<StoreMonthlyTargetDto>>;
