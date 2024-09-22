using KissLog;
using Microsoft.AspNetCore.Http;
using WebAPI.Domain.EntitiesDTO.ControlPanel;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
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
        if (await _iLogService.ExistByIdAsync(id))
        {
            var model = _iMapperService.Map<UserResponseDTO>(await _iLogService.GetByIdAsync(id));
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse();
    }

    [HttpPost("GetAllPaginate")]
    public async Task<IActionResult> GetAllPaginate(LogFilter filter)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var model = await _iLogService.GetAllPaginateAsync(filter);

        return CustomResponse(model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }
}
