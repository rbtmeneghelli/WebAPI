using WebAPI.Domain.CQRS.Command;
using MediatR;
using FixConstants = WebAPI.Domain.Constants.FixConstants;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.CQRS.Queries;
using WebAPI.Domain.Constants;

namespace WebAPI.V1.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
[AllowAnonymous]

public sealed class MediatorController : GenericController
{
    private readonly IMediator _mediator;

    public MediatorController(
        IMediator mediator,
        IHttpContextAccessor iHttpContextAccessor,
        IGenericNotifyLogsService iGenericNotifyLogsService) 
        : base(iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _mediator = mediator;
    }

    [HttpPost("GetAllPaginate")]
    public async Task<IActionResult> GetAllPaginate([FromBody] RegionQueryFilterRequest findRegionQueryFilterHandler)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var model = await _mediator.Send(findRegionQueryFilterHandler);
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }

    [HttpPost("GetById")]
    public async Task<IActionResult> GetById([FromBody] RegionQueryByIdRequest regionQueryByIdRequest)
    {
        var model = await _mediator.Send(regionQueryByIdRequest);
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateRegionCommandRequest createRegionCommandRequest)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _mediator.Send(createRegionCommandRequest);

        if (result)
            return CustomResponse(ConstantHttpStatusCode.OK_CODE);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateRegionCommandRequest updateRegionCommandRequest)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _mediator.Send(updateRegionCommandRequest);

        if (result)
            return NoContent();

        return CustomResponse(ConstantHttpStatusCode.OK_CODE);
    }
}