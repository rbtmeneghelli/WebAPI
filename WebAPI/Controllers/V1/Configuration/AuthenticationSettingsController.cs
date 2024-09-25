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
public sealed class AuthenticationSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly GeneralMethod _generalMethod;
    private readonly IFileService<AuthenticationSettingsExcelDTO> _iFileService;

    public AuthenticationSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileService<AuthenticationSettingsExcelDTO> iFileService,
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
        var model = await _iGenericConfigurationService.AuthenticationSettingsService.GetAllAuthenticationSettingsAsync();
        return CustomResponse(model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetByEnvironment")]
    public async Task<IActionResult> GetByEnvironment()
    {
        var existAuthenticationSettings = await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByEnvironmentAsync();
        if (existAuthenticationSettings)
        {
            var model = await _iGenericConfigurationService.AuthenticationSettingsService.GetAuthenticationSettingsByEnvironmentAsync();
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomNotFound();
    }

    [HttpGet("GetById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var existAuthenticationSettings = await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByIdAsync(id);
        if (existAuthenticationSettings)
        {
            var model = await _iGenericConfigurationService.AuthenticationSettingsService.GetAuthenticationSettingsByIdAsync(id);
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomNotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] AuthenticationSettingsCreateRequestDTO authenticationSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var authenticationSettingsRequest = ApplyMapToEntity<AuthenticationSettingsCreateRequestDTO, AuthenticationSettings>(authenticationSettingsCreateRequestDTO);
        var result = await _iGenericConfigurationService.AuthenticationSettingsService.CreateAuthenticationSettingsAsync(authenticationSettingsRequest);

        if (result)
            return CreatedAtAction(nameof(Create), authenticationSettingsRequest);

        return CustomResponse();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(long id, [FromBody] AuthenticationSettingsUpdateRequestDTO authenticationSettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var authenticationSettingsRequest = ApplyMapToEntity<AuthenticationSettingsUpdateRequestDTO, AuthenticationSettings>(authenticationSettingsUpdateRequestDTO);

        if (id != authenticationSettingsRequest.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse();
        }

        if (await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByIdAsync(authenticationSettingsRequest.Id.GetValueOrDefault()))
        {
            var result = await _iGenericConfigurationService.AuthenticationSettingsService.UpdateAuthenticationSettingsAsync(authenticationSettingsRequest);
            if (result)
                return NoContent();
            else
                return CustomResponse();
        }

        return CustomNotFound();
    }

    [HttpDelete("LogicDelete/{id:long}")]
    public async Task<IActionResult> LogicDelete(long id)
    {
        if (await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByIdAsync(id))
        {
            bool result = await _iGenericConfigurationService.AuthenticationSettingsService.LogicDeleteAuthenticationSettingsByIdAsync(id);
            if (result)
                return CustomResponse(default, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse();
        }

        return CustomNotFound();
    }

    [HttpPost("Reactive")]
    public async Task<IActionResult> Reactive(AuthenticationSettingsReactiveRequestDTO authenticationSettingsReactiveRequestDTO)
    {
        if (await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByIdAsync(authenticationSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
        {
            bool result = await _iGenericConfigurationService.AuthenticationSettingsService.ReactiveAuthenticationSettingsByIdAsync(authenticationSettingsReactiveRequestDTO.Id.Value);
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

        var excelData = await _iGenericConfigurationService.AuthenticationSettingsService.GetAllAuthenticationSettingsExcelAsync();
        if (excelData?.Count() > 0)
        {
            var memoryStreamResult = _generalMethod.GetMemoryStreamType(EnumMemoryStreamFile.XLSX);
            var excelName = $"AuthenticationSettings_{GuidExtensionMethod.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomNotFound();
    }
}
