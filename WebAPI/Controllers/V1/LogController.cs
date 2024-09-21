using KissLog;
using WebAPI.Domain.EntitiesDTO.ControlPanel;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Services.Tools;
using FixConstants = WebAPI.Domain.Constants.FixConstants;

namespace WebAPI.V1.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
// [ApiExplorerSettings(IgnoreApi = true)] // Ignora completamente os endpoints da controller
public sealed class LogController : GenericController
{
    private readonly ILogService _logService;

    public LogController(IMapper mapper, IHttpContextAccessor accessor, INotificationMessageService notificationMessageService, ILogService logService, IKLogger iKLogger) : base(mapper, accessor, notificationMessageService, iKLogger)
    {
        _logService = logService;
    }

    [HttpGet("getById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        if (await _logService.ExistByIdAsync(id))
        {
            var model = _iMapperService.Map<UserResponseDTO>(await _logService.GetByIdAsync(id));
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse();
    }

    [HttpPost("GetAllPaginate")]
    public async Task<IActionResult> GetAllPaginate(LogFilter filter)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var model = await _logService.GetAllPaginateAsync(filter);

        return CustomResponse(model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }
}
