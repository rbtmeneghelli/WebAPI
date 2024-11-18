using WebAPI.Domain.Constants;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Controllers.V1.Configuration;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public sealed class UploadSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly GeneralMethod _generalMethod;
    private readonly IMemoryCacheService _iMemoryCacheService;
    public UploadSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IMemoryCacheService iMemoryCacheService,
        IMapper iMapperService,
        IHttpContextAccessor iHttpContextAccessor,
        IGenericNotifyLogsService iGenericNotifyLogsService)
    : base(iMapperService, iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iGenericConfigurationService = iGenericConfigurationService;
        _iMemoryCacheService = iMemoryCacheService;
        _generalMethod = GeneralMethod.GetLoadExtensionMethods();
    }

    [HttpGet("GetByEnvironment")]
    public async Task<IActionResult> GetByEnvironment()
    {
        var existUploadSettings = await _iGenericConfigurationService.UploadSettingsService.ExistUploadSettingsByEnvironmentAsync();
        if (existUploadSettings)
        {
            var model = await _iGenericConfigurationService.UploadSettingsService.GetUploadSettingsByEnvironmentAsync();
            return CustomResponse(FixConstants.BADREQUEST_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpGet("GetById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var existUploadSettings = await _iGenericConfigurationService.UploadSettingsService.ExistUploadSettingsByIdAsync(id);
        if (existUploadSettings)
        {
            var model = await _iGenericConfigurationService.UploadSettingsService.GetUploadSettingsByIdAsync(id);
            return CustomResponse(FixConstants.BADREQUEST_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromForm] UploadSettingsCreateRequestDTO uploadSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _iGenericConfigurationService.UploadSettingsService.CreateUploadSettingsAsync(uploadSettingsCreateRequestDTO);

        if (result)
            return CreatedAtAction(nameof(Create), uploadSettingsCreateRequestDTO);

        return CustomResponse();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(long id, [FromForm] UploadSettingsUpdateRequestDTO uploadSettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        if (id != uploadSettingsUpdateRequestDTO.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse();
        }

        if (await _iGenericConfigurationService.UploadSettingsService.ExistUploadSettingsByIdAsync(uploadSettingsUpdateRequestDTO.Id.GetValueOrDefault()))
        {
            var result = await _iGenericConfigurationService.UploadSettingsService.UpdateUploadSettingsAsync(uploadSettingsUpdateRequestDTO);
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
        if (await _iGenericConfigurationService.UploadSettingsService.ExistUploadSettingsByIdAsync(id))
        {
            bool result = await _iGenericConfigurationService.UploadSettingsService.LogicDeleteUploadSettingsByIdAsync(id);
            if (result)
                return CustomResponse(default, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse();
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }

    [HttpPost("Reactive")]
    public async Task<IActionResult> Reactive(RequiredPasswordSettingsReactiveRequestDTO requiredPasswordSettingsReactiveRequestDTO)
    {
        if (await _iGenericConfigurationService.UploadSettingsService.ExistUploadSettingsByIdAsync(requiredPasswordSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
        {
            bool result = await _iGenericConfigurationService.UploadSettingsService.ReactiveUploadSettingsByIdAsync(requiredPasswordSettingsReactiveRequestDTO.Id.Value);
            if (result)
                return CustomResponse(default, FixConstants.SUCCESS_IN_ACTIVERECORD);
            else
                return CustomResponse();
        }

        return CustomResponse(FixConstants.NOTFOUND_CODE);
    }


    [HttpGet("load")]
    public async Task<IActionResult> Load()
    {
        if (!_iMemoryCacheService.TryGet<UploadSettingsResponseDTO>("FilesData", out var cached))
        {
            var files = await _iGenericConfigurationService.UploadSettingsService.GetUploadSettingsByEnvironmentAsync();
            _iMemoryCacheService.Set("FilesData", files);
            return CustomResponse(FixConstants.OK_CODE, files);
        }
        else
        {
            var files = _iMemoryCacheService.Get<UploadSettingsResponseDTO>("FilesData");
            return CustomResponse(FixConstants.OK_CODE, files);
        }
    }
}
