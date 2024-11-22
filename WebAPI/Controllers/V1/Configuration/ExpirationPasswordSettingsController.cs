using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Enums;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Controllers.V1.Configuration;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public sealed class ExpirationPasswordSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly GeneralMethod _generalMethod;
    private readonly IFileService<ExpirationPasswordSettingsExcelDTO> _iFileService;

    public ExpirationPasswordSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileService<ExpirationPasswordSettingsExcelDTO> iFileService,
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
        var model = await _iGenericConfigurationService.ExpirationPasswordSettingsService.GetAllExpirationPasswordSettingsAsync();
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetByEnvironment")]
    public async Task<IActionResult> GetByEnvironment()
    {
        var existExpirationPasswordSettings = await _iGenericConfigurationService.ExpirationPasswordSettingsService.ExistExpirationPasswordSettingsByEnvironmentAsync();
        if (existExpirationPasswordSettings)
        {
            var model = await _iGenericConfigurationService.ExpirationPasswordSettingsService.GetExpirationPasswordSettingsByEnvironmentAsync();
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpGet("GetById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var existExpirationPasswordSettings = await _iGenericConfigurationService.ExpirationPasswordSettingsService.ExistExpirationPasswordSettingsByIdAsync(id);
        if (existExpirationPasswordSettings)
        {
            var model = await _iGenericConfigurationService.ExpirationPasswordSettingsService.GetExpirationPasswordSettingsByIdAsync(id);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] ExpirationPasswordSettingsCreateRequestDTO expirationPasswordSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var expirationPasswordSettingsRequest = ApplyMapToEntity<ExpirationPasswordSettingsCreateRequestDTO, ExpirationPasswordSettings>(expirationPasswordSettingsCreateRequestDTO);
        var result = await _iGenericConfigurationService.ExpirationPasswordSettingsService.CreateExpirationPasswordSettingsAsync(expirationPasswordSettingsRequest);

        if (result)
            return CustomResponse(ConstantHttpStatusCode.CREATE_CODE, expirationPasswordSettingsRequest);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(long id, [FromBody] ExpirationPasswordSettingsUpdateRequestDTO expirationPasswordSettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var expirationPasswordSettingsRequest = ApplyMapToEntity<ExpirationPasswordSettingsUpdateRequestDTO, ExpirationPasswordSettings>(expirationPasswordSettingsUpdateRequestDTO);

        if (id != expirationPasswordSettingsRequest.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        if (await _iGenericConfigurationService.ExpirationPasswordSettingsService.ExistExpirationPasswordSettingsByIdAsync(expirationPasswordSettingsRequest.Id.GetValueOrDefault()))
        {
            var result = await _iGenericConfigurationService.ExpirationPasswordSettingsService.UpdateExpirationPasswordSettingsAsync(expirationPasswordSettingsRequest);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.NO_CONTENT_CODE);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpDelete("LogicDelete/{id:long}")]
    public async Task<IActionResult> LogicDelete(long id)
    {
        if (await _iGenericConfigurationService.ExpirationPasswordSettingsService.ExistExpirationPasswordSettingsByIdAsync(id))
        {
            bool result = await _iGenericConfigurationService.ExpirationPasswordSettingsService.LogicDeleteExpirationPasswordSettingsByIdAsync(id);
            if (result)
                return CustomResponse(default, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("Reactive")]
    public async Task<IActionResult> Reactive(ExpirationPasswordSettingsReactiveRequestDTO expirationPasswordSettingsReactiveRequestDTO)
    {
        if (await _iGenericConfigurationService.ExpirationPasswordSettingsService.ExistExpirationPasswordSettingsByIdAsync(expirationPasswordSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
        {
            bool result = await _iGenericConfigurationService.ExpirationPasswordSettingsService.ReactiveExpirationPasswordSettingsByIdAsync(expirationPasswordSettingsReactiveRequestDTO.Id.Value);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.OK_CODE, FixConstants.SUCCESS_IN_ACTIVERECORD);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("ExportData")]
    public async Task<IActionResult> ExportData()
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var excelData = await _iGenericConfigurationService.ExpirationPasswordSettingsService.GetAllExpirationPasswordSettingsExcelAsync();
        if (excelData?.Count() > 0)
        {
            var memoryStreamResult = _generalMethod.GetMemoryStreamType(EnumMemoryStreamFile.XLSX);
            var excelName = $"ExpirationPasswordSettings_{GuidExtensionMethod.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }
}
