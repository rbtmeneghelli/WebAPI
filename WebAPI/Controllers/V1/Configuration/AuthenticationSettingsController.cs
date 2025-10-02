using FastPackForShare.Controllers.Generics;
using FastPackForShare.Enums;
using FastPackForShare.Helpers;
using WebAPI.Domain.DTO.Configuration;

namespace WebAPI.Controllers.V1.Configuration;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public sealed class AuthenticationSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly IFileWriteService<AuthenticationSettingsExcelDTO> _iFileWriteService;

    public AuthenticationSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileWriteService<AuthenticationSettingsExcelDTO> iFileWriteService,
        INotificationMessageService iNotificationMessageService)
    : base(iNotificationMessageService)
    {
        _iGenericConfigurationService = iGenericConfigurationService;
        _iFileWriteService = iFileWriteService;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<IEnumerable<AuthenticationSettingsResponseDTO>>))]
    public async Task<IActionResult> GetAll()
    {
        var model = await _iGenericConfigurationService.AuthenticationSettingsService.GetAllAuthenticationSettingsAsync();
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetByEnvironment")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<AuthenticationSettingsResponseDTO>))]
    public async Task<IActionResult> GetByEnvironment()
    {
        var existAuthenticationSettings = await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByEnvironmentAsync();
        if (existAuthenticationSettings)
        {
            var model = await _iGenericConfigurationService.AuthenticationSettingsService.GetAuthenticationSettingsByEnvironmentAsync();
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpGet("GetById/{id:long}")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<AuthenticationSettingsResponseDTO>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> GetById([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id)
    {
        var existAuthenticationSettings = await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByIdAsync(id);
        if (existAuthenticationSettings)
        {
            var model = await _iGenericConfigurationService.AuthenticationSettingsService.GetAuthenticationSettingsByIdAsync(id);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("Create")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Create([FromBody, Required] AuthenticationSettingsCreateRequestDTO authenticationSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iGenericConfigurationService.AuthenticationSettingsService.CreateAuthenticationSettingsAsync(authenticationSettingsCreateRequestDTO);

        if (result)
            return CustomResponse(ConstantHttpStatusCode.CREATE_CODE, authenticationSettingsCreateRequestDTO);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpPut("Update")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Update([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id, [FromBody, Required] AuthenticationSettingsUpdateRequestDTO authenticationSettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        if (id != authenticationSettingsUpdateRequestDTO.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        if (await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByIdAsync(authenticationSettingsUpdateRequestDTO.Id.GetValueOrDefault()))
        {
            var result = await _iGenericConfigurationService.AuthenticationSettingsService.UpdateAuthenticationSettingsAsync(authenticationSettingsUpdateRequestDTO);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.NO_CONTENT_CODE);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpDelete("LogicDelete/{id:long}")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> LogicDelete([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id)
    {
        if (await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByIdAsync(id))
        {
            bool result = await _iGenericConfigurationService.AuthenticationSettingsService.LogicDeleteAuthenticationSettingsByIdAsync(id);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE, default, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("Reactive")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Reactive([FromBody, Required] AuthenticationSettingsReactiveRequestDTO authenticationSettingsReactiveRequestDTO)
    {
        if (await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByIdAsync(authenticationSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
        {
            bool result = await _iGenericConfigurationService.AuthenticationSettingsService.ReactiveAuthenticationSettingsByIdAsync(authenticationSettingsReactiveRequestDTO.Id.Value);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.OK_CODE, default, FixConstants.SUCCESS_IN_ACTIVERECORD);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("ExportData")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> ExportData()
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var excelData = await _iGenericConfigurationService.AuthenticationSettingsService.GetAllAuthenticationSettingsExcelAsync();
        if (excelData?.Count() > 0)
        {
            var memoryStreamResult = HelperFile.GetMemoryStreamType(EnumFile.Excel);
            var excelName = $"AuthenticationSettings_{GuidExtension.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileWriteService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }
}
