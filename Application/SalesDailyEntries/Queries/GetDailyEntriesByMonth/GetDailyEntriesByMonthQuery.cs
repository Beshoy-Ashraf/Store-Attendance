using Application.SalesDailyEntries.Dtos;
using MediatR;

namespace Application.SalesDailyEntries.Queries.GetDailyEntriesByMonth;

public record GetDailyEntriesByMonthQuery(int Year, int Month, Guid? StoreId = null) : IRequest<IReadOnlyList<SalesDailyEntryDto>>;
