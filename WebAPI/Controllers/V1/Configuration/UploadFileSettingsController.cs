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
//[Authorize("Bearer")]
[AllowAnonymous]
public sealed class UploadFileSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly GeneralMethod _generalMethod;
    private readonly IFileService<RequiredPasswordSettingsExcelDTO> _iFileService;

    public UploadFileSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileService<RequiredPasswordSettingsExcelDTO> iFileService,
        IMapper iMapperService,
        IHttpContextAccessor iHttpContextAccessor,
        IGenericNotifyLogsService iGenericNotifyLogsService)
    : base(iMapperService, iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iGenericConfigurationService = iGenericConfigurationService;
        _generalMethod = GeneralMethod.GetLoadExtensionMethods();
        _iFileService = iFileService;
    }

    //[HttpGet("GetByEnvironment")]
    //public async Task<IActionResult> GetByEnvironment()
    //{
    //    var existRequiredPasswordSettings = await _iGenericConfigurationService.RequiredPasswordSettingsService.ExistRequiredPasswordSettingsByEnvironmentAsync();
    //    if (existRequiredPasswordSettings)
    //    {
    //        var model = await _iGenericConfigurationService.RequiredPasswordSettingsService.GetRequiredPasswordSettingsByEnvironmentAsync();
    //        return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
    //    }

    //    return CustomNotFound();
    //}

    //[HttpGet("GetById/{id:long}")]
    //public async Task<IActionResult> GetById(long id)
    //{
    //    var existRequiredPasswordSettings = await _iGenericConfigurationService.RequiredPasswordSettingsService.ExistRequiredPasswordSettingsByIdAsync(id);
    //    if (existRequiredPasswordSettings)
    //    {
    //        var model = await _iGenericConfigurationService.RequiredPasswordSettingsService.GetRequiredPasswordSettingsByIdAsync(id);
    //        return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
    //    }

    //    return CustomNotFound();
    //}

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromForm] LayoutSettingsCreateRequestDTO layoutSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _iGenericConfigurationService.LayoutSettingsService.CreateLayoutSettingsRequestDTO(layoutSettingsCreateRequestDTO);

        if (result)
            return CreatedAtAction(nameof(Create), layoutSettingsCreateRequestDTO);

        return CustomResponse();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(int id, [FromForm] LayoutSettingsUpdateRequestDTO layoutSettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        if (id != layoutSettingsUpdateRequestDTO.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse();
        }

        //if (await _iGenericConfigurationService.LayoutSettingsService.ExistRequiredPasswordSettingsByIdAsync(id))
        //{
            var result = await _iGenericConfigurationService.LayoutSettingsService.UpdateLayoutSettingsRequestDTO(layoutSettingsUpdateRequestDTO);
            if (result)
                return NoContent();
            else
                return CustomResponse();
        //}

        //return CustomNotFound();
    }

    //[HttpDelete("LogicDelete/{id:long}")]
    //public async Task<IActionResult> LogicDelete(int id)
    //{
    //    if (await _iGenericConfigurationService.RequiredPasswordSettingsService.ExistRequiredPasswordSettingsByIdAsync(id))
    //    {
    //        bool result = await _iGenericConfigurationService.RequiredPasswordSettingsService.LogicDeleteRequiredPasswordSettingsByIdAsync(id);
    //        if (result)
    //            return CustomResponse(default, FixConstants.SUCCESS_IN_DELETELOGIC);
    //        else
    //            return CustomResponse();
    //    }

    //    return CustomNotFound();
    //}

    //[HttpPost("Reactive")]
    //public async Task<IActionResult> Reactive(RequiredPasswordSettingsReactiveRequestDTO requiredPasswordSettingsReactiveRequestDTO)
    //{
    //    if (await _iGenericConfigurationService.RequiredPasswordSettingsService.ExistRequiredPasswordSettingsByIdAsync(requiredPasswordSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
    //    {
    //        bool result = await _iGenericConfigurationService.RequiredPasswordSettingsService.ReactiveRequiredPasswordSettingsByIdAsync(requiredPasswordSettingsReactiveRequestDTO.Id.Value);
    //        if (result)
    //            return CustomResponse(default, FixConstants.SUCCESS_IN_ACTIVERECORD);
    //        else
    //            return CustomResponse();
    //    }

    //    return CustomNotFound();
    //}
}
