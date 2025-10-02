using WebAPI.Domain.DTO.Configuration;
using FastPackForShare.Controllers.Generics;
using FastPackForShare.Enums;
using FastPackForShare.Helpers;

namespace WebAPI.Controllers.V1.Configuration;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public sealed class EmailDisplaySettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly IFileWriteService<EmailDisplaySettingsExcelDTO> _iFileWriteService;

    public EmailDisplaySettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileWriteService<EmailDisplaySettingsExcelDTO> iFileWriteService,
        IHttpContextAccessor iHttpContextAccessor,
        INotificationMessageService iNotificationMessageService)
    : base(iNotificationMessageService)
    {
        _iGenericConfigurationService = iGenericConfigurationService;
        _iFileWriteService = iFileWriteService;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<IEnumerable<EmailDisplaySettingsResponseDTO>>))]
    public async Task<IActionResult> GetAll()
    {
        var model = await _iGenericConfigurationService.EmailDisplaySettingsService.GetAllEmailDisplaySettingsAsync();
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetById/{id:long}")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<EmailDisplaySettingsResponseDTO>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> GetById([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id)
    {
        var existEmailDisplaySettings = await _iGenericConfigurationService.EmailDisplaySettingsService.ExistEmailDisplaySettingsByIdAsync(id);
        if (existEmailDisplaySettings)
        {
            var model = await _iGenericConfigurationService.EmailDisplaySettingsService.GetEmailDisplaySettingsByIdAsync(id);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("Create")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Create([FromBody, Required] EmailDisplaySettingsCreateRequestDTO emailDisplaySettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iGenericConfigurationService.EmailDisplaySettingsService.CreateEmailDisplaySettingsAsync(emailDisplaySettingsCreateRequestDTO);

        if (result)
            return CustomResponse(ConstantHttpStatusCode.CREATE_CODE, emailDisplaySettingsCreateRequestDTO);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpPut("Update")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Update([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id, [FromBody, Required] EmailDisplaySettingsUpdateRequestDTO emailDisplaySettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        if (id != emailDisplaySettingsUpdateRequestDTO.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse();
        }

        if (await _iGenericConfigurationService.EmailDisplaySettingsService.ExistEmailDisplaySettingsByIdAsync(emailDisplaySettingsUpdateRequestDTO.Id.GetValueOrDefault()))
        {
            var result = await _iGenericConfigurationService.EmailDisplaySettingsService.UpdateEmailDisplaySettingsAsync(emailDisplaySettingsUpdateRequestDTO);
            if (result)
                return NoContent();
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
        if (await _iGenericConfigurationService.EmailDisplaySettingsService.ExistEmailDisplaySettingsByIdAsync(id))
        {
            bool result = await _iGenericConfigurationService.EmailDisplaySettingsService.LogicDeleteEmailDisplaySettingsByIdAsync(id);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.OK_CODE, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("Reactive")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Reactive([FromBody, Required] EmailSettingsReactiveRequestDTO emailSettingsReactiveRequestDTO)
    {
        if (await _iGenericConfigurationService.EmailDisplaySettingsService.ExistEmailDisplaySettingsByIdAsync(emailSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
        {
            bool result = await _iGenericConfigurationService.EmailDisplaySettingsService.ReactiveEmailDisplaySettingsByIdAsync(emailSettingsReactiveRequestDTO.Id.Value);
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

        var excelData = await _iGenericConfigurationService.EmailDisplaySettingsService.GetAllEmailDisplaySettingsExcelAsync();
        if (excelData?.Count() > 0)
        {
            var memoryStreamResult = HelperFile.GetMemoryStreamType(EnumFile.Excel);
            var excelName = $"EmailDisplaySettings_{GuidExtension.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileWriteService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }
}
