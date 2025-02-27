﻿using WebAPI.Domain.Filters.Others;
using FixConstants = WebAPI.Domain.Constants.FixConstants;

namespace WebAPI.V1.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public sealed class AuditController : GenericController
{
    private readonly IAuditService _iAuditService;

    public AuditController(
        IAuditService iAuditService,
        IMapper iMapperService, 
        IHttpContextAccessor iHttpContextAccessor, 
        INotificationMessageService noticationMessageService, 
        IGenericNotifyLogsService iGenericNotifyLogsService) 
        : base(iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iAuditService = iAuditService;
    }

    [HttpGet("getById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        if (await _iAuditService.ExistAuditByIdAsync(id))
        {
            var model = await _iAuditService.GetAuditByIdAsync(id);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("getAllPaginate")]
    public async Task<IActionResult> GetAllPaginate(AuditFilter filter)
    {
        if (ModelStateIsInvalid())
            return CustomResponse(ModelState);

        var model = await _iAuditService.GetAllAuditPaginateAsync(filter);

        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }
}
