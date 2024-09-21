using KissLog;
using WebAPI.Domain.EntitiesDTO.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Services.Tools;
using FixConstants = WebAPI.Domain.Constants.FixConstants;

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
        if (await _auditService.ExistByIdAsync(id))
        {
            var model = _mapperService.Map<AuditResponseDTO>(await _auditService.GetByIdAsync(id));
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse();
    }

    [HttpPost("GetAllPaginate")]
    public async Task<IActionResult> GetAllPaginate(AuditFilter filter)
    {
        if (ModelStateIsInvalid())
            return CustomResponse(ModelState);

        var model = await _auditService.GetAllPaginateAsync(filter);

        return CustomResponse(model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }
}
