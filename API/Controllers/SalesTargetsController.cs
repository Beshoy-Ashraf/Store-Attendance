using API.Contracts.SalesTargets;
using Application.SalesTargets.Commands.UpsertMonthlyTarget;
using Application.SalesTargets.Dtos;
using Application.SalesTargets.Queries.GetAllTargets;
using Application.SalesTargets.Queries.GetMonthlyTarget;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/stores/{storeId:guid}/targets")]
[Authorize]
public class SalesTargetsController(ISender mediator) : ControllerBase
{
    private readonly ISender _mediator = mediator;

    /// <summary>Create or update the monthly sales targets for a store.</summary>
    [HttpPut("{year:int}/{month:int}")]
    [Authorize(Roles = "AreaManager,Admin")]
    public async Task<ActionResult<StoreMonthlyTargetDto>> Upsert(
        Guid storeId,
        int year,
        int month,
        UpsertMonthlyTargetRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpsertMonthlyTargetCommand(
            storeId, year, month,
            request.AcqLow, request.AcqHigh, request.CashNew, request.Terminal,
            request.Dsl, request.Connectivity, request.EnterpriseNewAccount, request.EnterpriseGa);

        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>Get the monthly target for a store. Returns 404 if not set.</summary>
    [HttpGet("{year:int}/{month:int}")]
    public async Task<ActionResult<StoreMonthlyTargetDto>> Get(
        Guid storeId,
        int year,
        int month,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetMonthlyTargetQuery(storeId, year, month), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }
}

[ApiController]
[Route("api/targets")]
[Authorize]
public class SalesTargetsAreaController(ISender mediator) : ControllerBase
{
    private readonly ISender _mediator = mediator;

    /// <summary>Get all stores' targets for a given month (used by dashboard and target setup page).</summary>
    [HttpGet]
    [Authorize(Roles = "AreaManager,Admin")]
    public async Task<ActionResult<IReadOnlyList<StoreMonthlyTargetDto>>> GetAll(
        [FromQuery] int year,
        [FromQuery] int month,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllTargetsQuery(year, month), cancellationToken);
        return Ok(result);
    }
}
