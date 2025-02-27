﻿using WebAPI.Domain.Filters.Others;

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
        IHttpContextAccessor iHttpContextAccessor,
        IGenericNotifyLogsService iGenericNotifyLogsService)
        : base(iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iLogService = iLogService;
    }

    [HttpGet("getById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        if (await _iLogService.ExistLogByIdAsync(id))
        {
            var model = await _iLogService.GetLogByIdAsync(id);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("getAllPaginate")]
    public async Task<IActionResult> GetAllPaginate(LogFilter filter)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var model = await _iLogService.GetAllLogPaginateAsync(filter);

        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }
}
