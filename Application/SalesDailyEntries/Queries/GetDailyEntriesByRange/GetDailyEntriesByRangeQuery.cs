using Application.SalesDailyEntries.Dtos;
using MediatR;

namespace Application.SalesDailyEntries.Queries.GetDailyEntriesByRange;

public record GetDailyEntriesByRangeQuery(DateOnly From, DateOnly To) : IRequest<IReadOnlyList<SalesDailyEntryDto>>;
