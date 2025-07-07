using FastPackForShare.Controllers.Generics;
using FastPackForShare.Default;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Filters.Others;

namespace WebAPI.V1.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
// [ApiExplorerSettings(IgnoreApi = true)] // Ignora completamente os endpoints da controller
public sealed class LogController : GenericController
{
    private readonly ILogService _iLogService;

    public LogController(
        ILogService iLogService,
        INotificationMessageService iNotificationMessageService)
        : base(iNotificationMessageService)
    {
        _iLogService = iLogService;
    }

    [HttpGet("getById/{id:long}")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<LogResponseDTO>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> GetById([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id)
    {
        if (await _iLogService.ExistLogByIdAsync(id))
        {
            var model = await _iLogService.GetLogByIdAsync(id);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("getAllPaginate")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<BasePagedResultModel<LogResponseDTO>>))]
    public async Task<IActionResult> GetAllPaginate([FromBody, Required] LogFilter filter)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var model = await _iLogService.GetAllLogPaginateAsync(filter);

        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }
}
