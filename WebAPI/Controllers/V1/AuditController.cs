using FastPackForShare.Controllers.Generics;
using FastPackForShare.Default;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Filters.Others;
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
        INotificationMessageService iNoticationMessageService) 
        : base(iNoticationMessageService)
    {
        _iAuditService = iAuditService;
    }

    [HttpGet("getById/{id:long}")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<AuditResponseDTO>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> GetById([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id)
    {
        if (await _iAuditService.ExistAuditByIdAsync(id))
        {
            var model = await _iAuditService.GetAuditByIdAsync(id);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("getAllPaginate")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<BasePagedResultModel<AuditResponseDTO>>))]
    public async Task<IActionResult> GetAllPaginate([FromBody, Required] AuditFilter filter)
    {
        if (ModelStateIsInvalid())
            return CustomResponseModel(ModelState);

        var model = await _iAuditService.GetAllAuditPaginateAsync(filter);

        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALLPAGINATE);
    }
}
