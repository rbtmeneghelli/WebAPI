using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.EntitiesDTO.Configuration;
using WebAPI.Domain.Enums;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Controllers.V1.Configuration;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public sealed class EmailDisplaySettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly GeneralMethod _generalMethod;
    private readonly IFileService<EmailDisplaySettingsExcelDTO> _iFileService;

    public EmailDisplaySettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileService<EmailDisplaySettingsExcelDTO> iFileService,
        IMapper iMapperService,
        IHttpContextAccessor iHttpContextAccessor,
        IGenericNotifyLogsService iGenericNotifyLogsService)
    : base(iMapperService, iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iGenericConfigurationService = iGenericConfigurationService;
        _generalMethod = GeneralMethod.GetLoadExtensionMethods();
        _iFileService = iFileService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var model = await _iGenericConfigurationService.EmailDisplaySettingsService.GetAllEmailDisplaySettingsAsync();
        return CustomResponse(FixConstants.BADREQUEST_CODE, model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var existEmailDisplaySettings = await _iGenericConfigurationService.EmailDisplaySettingsService.ExistEmailDisplaySettingsByIdAsync(id);
        if (existEmailDisplaySettings)
        {
            var model = await _iGenericConfigurationService.EmailDisplaySettingsService.GetEmailDisplaySettingsByIdAsync(id);
            return CustomResponse(FixConstants.BADREQUEST_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] EmailDisplaySettingsCreateRequestDTO emailDisplaySettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var emailDisplaySettingsCreateRequest = ApplyMapToEntity<EmailDisplaySettingsCreateRequestDTO, EmailDisplay>(emailDisplaySettingsCreateRequestDTO);
        var result = await _iGenericConfigurationService.EmailDisplaySettingsService.CreateEmailDisplaySettingsAsync(emailDisplaySettingsCreateRequest);

        if (result)
            return CreatedAtAction(nameof(Create), emailDisplaySettingsCreateRequest);

        return CustomResponse();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(long id, [FromBody] EmailDisplaySettingsUpdateRequestDTO emailDisplaySettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var emailDisplaySettingsUpdateRequest = ApplyMapToEntity<EmailDisplaySettingsUpdateRequestDTO, EmailDisplay>(emailDisplaySettingsUpdateRequestDTO);

        if (id != emailDisplaySettingsUpdateRequest.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse();
        }

        if (await _iGenericConfigurationService.EmailDisplaySettingsService.ExistEmailDisplaySettingsByIdAsync(emailDisplaySettingsUpdateRequest.Id.GetValueOrDefault()))
        {
            var result = await _iGenericConfigurationService.EmailDisplaySettingsService.UpdateEmailDisplaySettingsAsync(emailDisplaySettingsUpdateRequest);
            if (result)
                return NoContent();
            else
                return CustomResponse();
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpDelete("LogicDelete/{id:long}")]
    public async Task<IActionResult> LogicDelete(long id)
    {
        if (await _iGenericConfigurationService.EmailDisplaySettingsService.ExistEmailDisplaySettingsByIdAsync(id))
        {
            bool result = await _iGenericConfigurationService.EmailDisplaySettingsService.LogicDeleteEmailDisplaySettingsByIdAsync(id);
            if (result)
                return CustomResponse(default, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse();
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpPost("Reactive")]
    public async Task<IActionResult> Reactive(EmailSettingsReactiveRequestDTO emailSettingsReactiveRequestDTO)
    {
        if (await _iGenericConfigurationService.EmailDisplaySettingsService.ExistEmailDisplaySettingsByIdAsync(emailSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
        {
            bool result = await _iGenericConfigurationService.EmailDisplaySettingsService.ReactiveEmailDisplaySettingsByIdAsync(emailSettingsReactiveRequestDTO.Id.Value);
            if (result)
                return CustomResponse(default, FixConstants.SUCCESS_IN_ACTIVERECORD);
            else
                return CustomResponse();
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpPost("ExportData")]
    public async Task<IActionResult> ExportData()
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var excelData = await _iGenericConfigurationService.EmailDisplaySettingsService.GetAllEmailDisplaySettingsExcelAsync();
        if (excelData?.Count() > 0)
        {
            var memoryStreamResult = _generalMethod.GetMemoryStreamType(EnumMemoryStreamFile.XLSX);
            var excelName = $"EmailDisplaySettings_{GuidExtensionMethod.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }
}
