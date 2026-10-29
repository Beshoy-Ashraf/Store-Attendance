using API.Contracts.SalesDailyEntries;
using Application.SalesDailyEntries.Commands.UpsertDailyEntry;
using Application.SalesDailyEntries.Dtos;
using Application.SalesDailyEntries.Queries.GetDailyEntriesByMonth;
using Application.SalesDailyEntries.Queries.GetDailyEntriesByRange;
using Application.SalesDailyEntries.Queries.GetDailyEntry;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/stores/{storeId:guid}/daily-entries")]
[Authorize]
public class SalesDailyEntriesController(ISender mediator) : ControllerBase
{
    private readonly ISender _mediator = mediator;

    /// <summary>Create or update the daily sales entry for a store on a specific date.</summary>
    [HttpPut("{date}")]
    [Authorize(Roles = "StoreManager,AreaManager,Admin")]
    public async Task<ActionResult<SalesDailyEntryDto>> Upsert(
        Guid storeId,
        DateOnly date,
        UpsertDailyEntryRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpsertDailyEntryCommand(
            storeId, date,
            request.AcqLowAchieved, request.AcqHighAchieved, request.CashNewAchieved,
            request.TerminalAchieved, request.DslAchieved, request.ConnectivityAchieved,
            request.EnterpriseNewAccountAchieved, request.EnterpriseGaAchieved,
            request.AmOneLine, request.AmTwoLines, request.AmThreeLines,
            request.PmOneLine, request.PmTwoLines, request.PmThreeLines,
            request.Mnp, request.NewRed);

        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>Get the daily entry for a store on a specific date. Returns 404 if not submitted yet.</summary>
    [HttpGet("{date}")]
    public async Task<ActionResult<SalesDailyEntryDto>> GetByDate(
        Guid storeId,
        DateOnly date,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetDailyEntryQuery(storeId, date), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>Get all daily entries for a store in a given month.</summary>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<SalesDailyEntryDto>>> GetByMonth(
        Guid storeId,
        [FromQuery] int year,
        [FromQuery] int month,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetDailyEntriesByMonthQuery(year, month, storeId), cancellationToken);
        return Ok(result);
    }
}

[ApiController]
[Route("api/daily-entries")]
[Authorize]
public class SalesDailyEntriesAreaController(ISender mediator) : ControllerBase
{
    private readonly ISender _mediator = mediator;

    /// <summary>Get all stores' daily entries across a date range (for dashboard).</summary>
    [HttpGet]
    [Authorize(Roles = "AreaManager,Admin")]
    public async Task<ActionResult<IReadOnlyList<SalesDailyEntryDto>>> GetByRange(
        [FromQuery] DateOnly from,
        [FromQuery] DateOnly to,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetDailyEntriesByRangeQuery(from, to), cancellationToken);
        return Ok(result);
    }

    /// <summary>Get all stores' daily entries for a given month (for dashboard MTD).</summary>
    [HttpGet("by-month")]
    [Authorize(Roles = "AreaManager,Admin")]
    public async Task<ActionResult<IReadOnlyList<SalesDailyEntryDto>>> GetByMonth(
        [FromQuery] int year,
        [FromQuery] int month,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetDailyEntriesByMonthQuery(year, month), cancellationToken);
        return Ok(result);
    }
}
