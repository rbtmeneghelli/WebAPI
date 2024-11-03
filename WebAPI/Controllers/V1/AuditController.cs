using WebAPI.Domain.EntitiesDTO.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Tools;
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
        : base(iMapperService, iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iAuditService = iAuditService;
    }

    [HttpGet("getById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        if (await _iAuditService.ExistAuditByIdAsync(id))
        {
            var model = _iMapperService.Map<AuditResponseDTO>(await _iAuditService.GetAuditByIdAsync(id));
            return CustomResponse(FixConstants.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpPost("GetAllPaginate")]
    public async Task<IActionResult> GetAllPaginate(AuditFilter filter)
    {
        if (ModelStateIsInvalid())
            return CustomResponse(ModelState);

        var model = await _iAuditService.GetAllAuditPaginateAsync(filter);

        return CustomResponse(FixConstants.OK_CODE, model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }
}
