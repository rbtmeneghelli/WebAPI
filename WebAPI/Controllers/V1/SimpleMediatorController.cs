using WebAPI.Domain.CQRS.Command;
using WebAPI.Domain.CQRS.Queries;
using FastPackForShare.Controllers;
using FastPackForShare.Interfaces;
using System.ComponentModel.DataAnnotations;
using FastPackForShare.Constants;
using FastPackForShare.Models;
using FastPackForShare.SimpleMediator;

namespace WebAPI.V1.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]

public sealed class SimpleMediatorController : BaseSimpleMediatorController
{
    private readonly IMediator _mediator;

    public SimpleMediatorController(IMediator mediator, INotificationMessageService notificationMessageService)
    : base(mediator, notificationMessageService)
    {
        _mediator = mediator;
    }

    [HttpPost("getAllPaginate")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomProduceResponseTypeModel<IEnumerable<RegionQueryFilterResponse>>))]
    public async Task<IActionResult> GetAllPaginate([FromBody, Required] RegionQueryFilterRequest findRegionQueryFilterHandler) =>
    ModelStateIsInvalid() ?
    CustomResponseModel(ModelState) :
    CustomResponse(await _mediator.Send(findRegionQueryFilterHandler));

    [HttpPost("getById")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomProduceResponseTypeModel<IEnumerable<RegionQueryFilterResponse>>))]
    public async Task<IActionResult> GetById([FromBody, Required] RegionQueryByIdRequest regionQueryByIdRequest) =>
    ModelStateIsInvalid() ?
    CustomResponseModel(ModelState) :
    CustomResponse(await _mediator.Send(regionQueryByIdRequest));

    [HttpPost("insert")]
    [ProducesResponseType(ConstantHttpStatusCode.CREATE_CODE, Type = typeof(CustomProduceResponseTypeModel<object>))]
    public async Task<IActionResult> Insert([FromBody, Required] CreateRegionCommandRequest createRegionCommandRequest) =>
    ModelStateIsInvalid() ?
    CustomResponseModel(ModelState) :
    CustomResponse(await _mediator.Send(createRegionCommandRequest));

    [HttpPut("update")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomProduceResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomProduceResponseTypeModel<object>))]
    public async Task<IActionResult> Update([FromBody, Required] UpdateRegionCommandRequest updateRegionCommandRequest) =>
    ModelStateIsInvalid() ?
    CustomResponseModel(ModelState) :
    CustomResponse(await _mediator.Send(updateRegionCommandRequest));
}