using WebAPI.Domain.DTO.Configuration;
using FastPackForShare.Controllers.Generics;
using FastPackForShare.Enums;

namespace WebAPI.Controllers.V1.Configuration;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public sealed class RequiredPasswordSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly IFileWriteService<RequiredPasswordSettingsExcelDTO> _iFileWriteService;

    public RequiredPasswordSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileWriteService<RequiredPasswordSettingsExcelDTO> iFileWriteService,
        INotificationMessageService notificationMessageService)
    : base(notificationMessageService)
    {
        _iGenericConfigurationService = iGenericConfigurationService;
        _iFileWriteService = iFileWriteService;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<IEnumerable<RequiredPasswordSettingsResponseDTO>>))]
    public async Task<IActionResult> GetAll()
    {
        var model = await _iGenericConfigurationService.RequiredPasswordSettingsService.GetAllRequiredPasswordSettingsAsync();
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetByEnvironment")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<RequiredPasswordSettingsResponseDTO>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> GetByEnvironment()
    {
        var existRequiredPasswordSettings = await _iGenericConfigurationService.RequiredPasswordSettingsService.ExistRequiredPasswordSettingsByEnvironmentAsync();
        if (existRequiredPasswordSettings)
        {
            var model = await _iGenericConfigurationService.RequiredPasswordSettingsService.GetRequiredPasswordSettingsByEnvironmentAsync();
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpGet("GetById/{id:long}")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<RequiredPasswordSettingsResponseDTO>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> GetById([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id)
    {
        var existRequiredPasswordSettings = await _iGenericConfigurationService.RequiredPasswordSettingsService.ExistRequiredPasswordSettingsByIdAsync(id);
        if (existRequiredPasswordSettings)
        {
            var model = await _iGenericConfigurationService.RequiredPasswordSettingsService.GetRequiredPasswordSettingsByIdAsync(id);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("Create")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Create([FromBody, Required] RequiredPasswordSettingsCreateRequestDTO requiredPasswordSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iGenericConfigurationService.RequiredPasswordSettingsService.CreateRequiredPasswordSettingsAsync(requiredPasswordSettingsCreateRequestDTO);

        if (result)
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, requiredPasswordSettingsCreateRequestDTO);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpPut("Update")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Update([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id, [FromBody, Required] RequiredPasswordSettingsUpdateRequestDTO requiredPasswordSettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        if (id != requiredPasswordSettingsUpdateRequestDTO.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        if (await _iGenericConfigurationService.RequiredPasswordSettingsService.ExistRequiredPasswordSettingsByIdAsync(requiredPasswordSettingsUpdateRequestDTO.Id.GetValueOrDefault()))
        {
            var result = await _iGenericConfigurationService.RequiredPasswordSettingsService.UpdateRequiredPasswordSettingsAsync(requiredPasswordSettingsUpdateRequestDTO);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.NO_CONTENT_CODE);
            else
                return CustomResponse();
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpDelete("LogicDelete/{id:long}")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> LogicDelete([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id)
    {
        if (await _iGenericConfigurationService.RequiredPasswordSettingsService.ExistRequiredPasswordSettingsByIdAsync(id))
        {
            bool result = await _iGenericConfigurationService.RequiredPasswordSettingsService.LogicDeleteRequiredPasswordSettingsByIdAsync(id);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.OK_CODE, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("Reactive")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Reactive([FromBody, Required] RequiredPasswordSettingsReactiveRequestDTO requiredPasswordSettingsReactiveRequestDTO)
    {
        if (await _iGenericConfigurationService.RequiredPasswordSettingsService.ExistRequiredPasswordSettingsByIdAsync(requiredPasswordSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
        {
            bool result = await _iGenericConfigurationService.RequiredPasswordSettingsService.ReactiveRequiredPasswordSettingsByIdAsync(requiredPasswordSettingsReactiveRequestDTO.Id.Value);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.OK_CODE, FixConstants.SUCCESS_IN_ACTIVERECORD);
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

        var excelData = await _iGenericConfigurationService.RequiredPasswordSettingsService.GetAllRequiredPasswordSettingsExcelAsync();
        if (excelData?.Count() > 0)
        {
            var memoryStreamResult = SharedExtension.GetMemoryStreamType(EnumFile.Excel);
            var excelName = $"RequiredPasswordSettings_{GuidExtension.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileWriteService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }
}
