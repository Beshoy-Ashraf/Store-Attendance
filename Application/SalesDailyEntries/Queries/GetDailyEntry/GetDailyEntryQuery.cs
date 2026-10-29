using Application.SalesDailyEntries.Dtos;
using MediatR;

namespace Application.SalesDailyEntries.Queries.GetDailyEntry;

public record GetDailyEntryQuery(Guid StoreId, DateOnly Date) : IRequest<SalesDailyEntryDto?>;
