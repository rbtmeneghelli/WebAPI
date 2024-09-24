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
public sealed class EnvironmentTypeSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly GeneralMethod _generalMethod;
    private readonly IFileService<EnvironmentTypeSettingsExcelDTO> _iFileService;

    public EnvironmentTypeSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileService<EnvironmentTypeSettingsExcelDTO> iFileService,
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
        var model = await _iGenericConfigurationService.EnvironmentTypeSettingsService.GetAllEnvironmentTypeSettingsAsync();
        return CustomResponse(model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var existRequiredPasswordSettings = await _iGenericConfigurationService.EnvironmentTypeSettingsService.ExistEnvironmentTypeSettingsByIdAsync(id);
        if (existRequiredPasswordSettings)
        {
            var model = await _iGenericConfigurationService.EnvironmentTypeSettingsService.GetEnvironmentTypeSettingsByIdAsync(id);
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomNotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] EnvironmentTypeSettingsCreateRequestDTO environmentTypeSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var environmentTypeSettingsCreateRequest = ApplyMapToEntity<EnvironmentTypeSettingsCreateRequestDTO, EnvironmentTypeSettings>(environmentTypeSettingsCreateRequestDTO);
        var result = await _iGenericConfigurationService.EnvironmentTypeSettingsService.CreateEnvironmentTypeSettingsAsync(environmentTypeSettingsCreateRequest);

        if (result)
            return CreatedAtAction(nameof(Create), environmentTypeSettingsCreateRequest);

        return CustomResponse();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(int id, [FromBody] EnvironmentTypeSettingsUpdateRequestDTO environmentTypeSettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var environmentTypeSettingsUpdateRequest = ApplyMapToEntity<EnvironmentTypeSettingsUpdateRequestDTO, EnvironmentTypeSettings>(environmentTypeSettingsUpdateRequestDTO);

        if (id != environmentTypeSettingsUpdateRequest.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse();
        }

        if (await _iGenericConfigurationService.EnvironmentTypeSettingsService.ExistEnvironmentTypeSettingsByIdAsync(id))
        {
            var result = await _iGenericConfigurationService.EnvironmentTypeSettingsService.UpdateEnvironmentTypeSettingsAsync(id, environmentTypeSettingsUpdateRequest);
            if (result)
                return NoContent();
            else
                return CustomResponse();
        }

        return CustomNotFound();
    }

    [HttpDelete("LogicDelete/{id:long}")]
    public async Task<IActionResult> LogicDelete(int id)
    {
        if (await _iGenericConfigurationService.EnvironmentTypeSettingsService.ExistEnvironmentTypeSettingsByIdAsync(id))
        {
            bool result = await _iGenericConfigurationService.EnvironmentTypeSettingsService.LogicDeleteEnvironmentTypeSettingsByIdAsync(id);
            if (result)
                return CustomResponse(default, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse();
        }

        return CustomNotFound();
    }

    [HttpPost("Reactive")]
    public async Task<IActionResult> Reactive(EnvironmentTypeSettingsReactiveRequestDTO environmentTypeSettingsReactiveRequestDTO)
    {
        if (await _iGenericConfigurationService.EnvironmentTypeSettingsService.ExistEnvironmentTypeSettingsByIdAsync(environmentTypeSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
        {
            bool result = await _iGenericConfigurationService.EnvironmentTypeSettingsService.ReactiveEnvironmentTypeSettingsByIdAsync(environmentTypeSettingsReactiveRequestDTO.Id.Value);
            if (result)
                return CustomResponse(default, FixConstants.SUCCESS_IN_ACTIVERECORD);
            else
                return CustomResponse();
        }

        return CustomNotFound();
    }

    [HttpPost("ExportData")]
    public async Task<IActionResult> ExportData()
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var excelData = await _iGenericConfigurationService.EnvironmentTypeSettingsService.GetAllEnvironmentTypeSettingsExcelAsync();
        if (excelData?.Count() > 0)
        {
            var memoryStreamResult = _generalMethod.GetMemoryStreamType(EnumMemoryStreamFile.XLSX);
            var excelName = $"EnvironmentTypeSettings_{GuidExtensionMethod.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomNotFound();
    }
}

