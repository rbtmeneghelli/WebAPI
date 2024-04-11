using KissLog;
using Constants = WebAPI.Domain.Constants;

namespace WebAPI.V1.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public sealed class AuditController : GenericController
{
    private readonly IAuditService _auditService;

    public AuditController(IMapper mapper, IHttpContextAccessor accessor, INotificationMessageService noticationMessageService, IAuditService auditService, IKLogger iKLogger) : base(mapper, accessor, noticationMessageService, iKLogger)
    {
        _auditService = auditService;
    }

    [HttpGet("getById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        if (await _auditService.ExistByIdAsync(id) is false)
            return CustomResponse();

        var model = _mapperService.Map<AuditResponseDTO>(await _auditService.GetByIdAsync(id));

        return CustomResponse(model, Constants.SUCCESS_IN_GETID);
    }

    [HttpPost("GetAllPaginate")]
    public async Task<IActionResult> GetAllPaginate(AuditFilter filter)
    {
        if(ModelStateIsInvalid())
            return CustomResponse(ModelState);

        var model = await _auditService.GetAllPaginateAsync(filter);

        return CustomResponse(model, Constants.SUCCESS_IN_GETALLPAGINATE);
    }
}
