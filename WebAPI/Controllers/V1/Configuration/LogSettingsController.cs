using WebAPI.Domain.DTO.Configuration;
using FastPackForShare.Controllers.Generics;
using FastPackForShare.Enums;
using FastPackForShare.Helpers;

namespace WebAPI.Controllers.V1.Configuration;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public sealed class LogSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly IFileWriteService<LogSettingsExcelDTO> _iFileWriteService;

    public LogSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileWriteService<LogSettingsExcelDTO> iFileWriteService,
        INotificationMessageService iNotificationMessageService)
    : base(iNotificationMessageService)
    {
        _iGenericConfigurationService = iGenericConfigurationService;
        _iFileWriteService = iFileWriteService;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<IEnumerable<LogSettingsResponseDTO>>))]
    public async Task<IActionResult> GetAll()
    {
        var model = await _iGenericConfigurationService.LogSettingsService.GetAllLogSettingsAsync();
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetByEnvironment")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<LogSettingsResponseDTO>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> GetByEnvironment()
    {
        var existLogSettings = await _iGenericConfigurationService.LogSettingsService.ExistLogSettingsByEnvironmentAsync();
        if (existLogSettings)
        {
            var model = await _iGenericConfigurationService.LogSettingsService.GetLogSettingsByEnvironmentAsync();
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpGet("GetById/{id:long}")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<LogSettingsResponseDTO>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> GetById([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id)
    {
        var existLogSettings = await _iGenericConfigurationService.LogSettingsService.ExistLogSettingsByIdAsync(id);
        if (existLogSettings)
        {
            var model = await _iGenericConfigurationService.LogSettingsService.GetLogSettingsByIdAsync(id);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("Create")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Create([FromBody, Required] LogSettingsCreateRequestDTO logSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iGenericConfigurationService.LogSettingsService.CreateLogSettingsAsync(logSettingsCreateRequestDTO);

        if (result)
            return CustomResponse(ConstantHttpStatusCode.CREATE_CODE, logSettingsCreateRequestDTO);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpPut("Update")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Update([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id, [FromBody, Required] LogSettingsUpdateRequestDTO logSettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        if (id != logSettingsUpdateRequestDTO.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        if (await _iGenericConfigurationService.LogSettingsService.ExistLogSettingsByIdAsync(logSettingsUpdateRequestDTO.Id.GetValueOrDefault()))
        {
            var result = await _iGenericConfigurationService.LogSettingsService.UpdateLogSettingsAsync(logSettingsUpdateRequestDTO);
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
        if (await _iGenericConfigurationService.LogSettingsService.ExistLogSettingsByIdAsync(id))
        {
            bool result = await _iGenericConfigurationService.LogSettingsService.LogicDeleteLogSettingsByIdAsync(id);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.OK_CODE, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("Reactive")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Reactive([FromBody, Required] LogSettingsReactiveRequestDTO logSettingsReactiveRequestDTO)
    {
        if (await _iGenericConfigurationService.LogSettingsService.ExistLogSettingsByIdAsync(logSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
        {
            bool result = await _iGenericConfigurationService.LogSettingsService.ReactiveLogSettingsByIdAsync(logSettingsReactiveRequestDTO.Id.Value);
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

        var excelData = await _iGenericConfigurationService.LogSettingsService.GetAllLogSettingsExcelAsync();
        if (excelData?.Count() > 0)
        {
            var memoryStreamResult = HelperFile.GetMemoryStreamType(EnumFile.Excel);
            var excelName = $"LogSettings_{GuidExtension.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileWriteService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }
}