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
public sealed class LayoutSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly GeneralMethod _generalMethod;
    private readonly IFileService<LayoutSettingsExcelDTO> _iFileService;

    public LayoutSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileService<LayoutSettingsExcelDTO> iFileService,
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
        var model = await _iGenericConfigurationService.LayoutSettingsService.GetAllLayoutSettingsAsync();
        return CustomResponse(FixConstants.BADREQUEST_CODE, model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetByEnvironment")]
    public async Task<IActionResult> GetByEnvironment()
    {
        var existLayoutSettings = await _iGenericConfigurationService.LayoutSettingsService.ExistLayoutSettingsByEnvironmentAsync();
        if (existLayoutSettings)
        {
            var model = await _iGenericConfigurationService.LayoutSettingsService.GetLayoutSettingsByEnvironmentAsync();
            return CustomResponse(FixConstants.BADREQUEST_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpGet("GetById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var existLayoutSettings = await _iGenericConfigurationService.LayoutSettingsService.ExistLayoutSettingsByIdAsync(id);
        if (existLayoutSettings)
        {
            var model = await _iGenericConfigurationService.LayoutSettingsService.GetLayoutSettingsByIdAsync(id);
            return CustomResponse(FixConstants.BADREQUEST_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] LayoutSettingsCreateRequestDTO layoutSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var layoutSettingsCreateRequest = ApplyMapToEntity<LayoutSettingsCreateRequestDTO, LayoutSettings>(layoutSettingsCreateRequestDTO);
        var result = await _iGenericConfigurationService.LayoutSettingsService.CreateLayoutSettingsAsync(layoutSettingsCreateRequest);

        if (result)
            return CreatedAtAction(nameof(Create), layoutSettingsCreateRequest);

        return CustomResponse();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(long id, [FromBody] LayoutSettingsUpdateRequestDTO layoutSettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var layoutSettingsUpdateRequest = ApplyMapToEntity<LayoutSettingsUpdateRequestDTO, LayoutSettings>(layoutSettingsUpdateRequestDTO);

        if (id != layoutSettingsUpdateRequest.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse();
        }

        if (await _iGenericConfigurationService.LayoutSettingsService.ExistLayoutSettingsByIdAsync(layoutSettingsUpdateRequest.Id.GetValueOrDefault()))
        {
            var result = await _iGenericConfigurationService.LayoutSettingsService.UpdateLayoutSettingsAsync(layoutSettingsUpdateRequest);
            if (result)
                return NoContent();
            else
                return CustomResponse();
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpDelete("LogicDelete/{id:long}")]
    public async Task<IActionResult> LogicDelete(int id)
    {
        if (await _iGenericConfigurationService.LayoutSettingsService.ExistLayoutSettingsByIdAsync(id))
        {
            bool result = await _iGenericConfigurationService.LayoutSettingsService.LogicDeleteLayoutSettingsByIdAsync(id);
            if (result)
                return CustomResponse(default, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse();
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpPost("Reactive")]
    public async Task<IActionResult> Reactive(LayoutSettingsReactiveRequestDTO layoutSettingsReactiveRequestDTO)
    {
        if (await _iGenericConfigurationService.LayoutSettingsService.ExistLayoutSettingsByIdAsync(layoutSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
        {
            bool result = await _iGenericConfigurationService.LayoutSettingsService.ReactiveLayoutSettingsByIdAsync(layoutSettingsReactiveRequestDTO.Id.Value);
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

        var excelData = await _iGenericConfigurationService.LayoutSettingsService.GetAllLayoutSettingsExcelAsync();
        if (excelData?.Count() > 0)
        {
            var memoryStreamResult = _generalMethod.GetMemoryStreamType(EnumMemoryStreamFile.XLSX);
            var excelName = $"LayoutSettings_{GuidExtensionMethod.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }
}
