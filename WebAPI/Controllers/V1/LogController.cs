using WebAPI.Domain.Constants;
using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;


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
        IMapper iMapperService,
        IHttpContextAccessor iHttpContextAccessor,
        IGenericNotifyLogsService iGenericNotifyLogsService)
        : base(iMapperService, iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iLogService = iLogService;
    }

    [HttpGet("getById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        if (await _iLogService.ExistLogByIdAsync(id))
        {
            var model = _iMapperService.Map<UserResponseDTO>(await _iLogService.GetLogByIdAsync(id));
            return CustomResponse(FixConstants.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpPost("GetAllPaginate")]
    public async Task<IActionResult> GetAllPaginate(LogFilter filter)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var model = await _iLogService.GetAllLogPaginateAsync(filter);

        return CustomResponse(FixConstants.OK_CODE, model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }
}
