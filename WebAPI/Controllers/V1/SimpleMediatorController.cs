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
    public SimpleMediatorController(IMediator mediator, INotificationMessageService notificationMessageService)
    : base(mediator, notificationMessageService)
    {
    }

    #region QUERIES

    [HttpPost("getAllPaginate")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomProduceResponseTypeModel<IEnumerable<SimpleRegionQueryFilterResponse>>))]
    public async Task<IActionResult> GetAllPaginate([FromBody, Required] SimpleRegionQueryFilterRequest simpleRegionQueryFilterRequest) =>
    ModelStateIsInvalid() ?
    CustomResponseModel(ModelState) :
    CustomResponse(await _iMediator.Send(simpleRegionQueryFilterRequest));

    [HttpPost("getById")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomProduceResponseTypeModel<SimpleRegionQueryByIdResponse>))]
    public async Task<IActionResult> GetById([FromBody, Required] SimpleRegionQueryByIdRequest simpleRegionQueryByIdRequest) =>
    ModelStateIsInvalid() ?
    CustomResponseModel(ModelState) :
    CustomResponse(await _iMediator.Send(simpleRegionQueryByIdRequest));

    #endregion

    #region COMMANDS

    [HttpPost("insert")]
    [ProducesResponseType(ConstantHttpStatusCode.CREATE_CODE, Type = typeof(CustomProduceResponseTypeModel<object>))]
    public async Task<IActionResult> Insert([FromBody, Required] SimpleCreateRegionCommandRequest simpleCreateRegionCommandRequest) =>
    ModelStateIsInvalid() ?
    CustomResponseModel(ModelState) :
    CustomResponse(await _iMediator.Send(simpleCreateRegionCommandRequest));

    [HttpPut("update")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomProduceResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomProduceResponseTypeModel<object>))]
    public async Task<IActionResult> Update([FromBody, Required] SimpleUpdateRegionCommandRequest simpleUpdateRegionCommandRequest) =>
    ModelStateIsInvalid() ?
    CustomResponseModel(ModelState) :
    CustomResponse(await _iMediator.Send(simpleUpdateRegionCommandRequest));

    #endregion
}