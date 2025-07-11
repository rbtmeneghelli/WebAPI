﻿using FastPackForShare.Controllers.Generics;
using FastPackForShare.Enums;
using WebAPI.Domain.DTO.Configuration;

namespace WebAPI.Controllers.V1.Configuration;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public sealed class EnvironmentTypeSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly IFileWriteService<EnvironmentTypeSettingsExcelDTO> _iFileWriteService;

    public EnvironmentTypeSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileWriteService<EnvironmentTypeSettingsExcelDTO> iFileWriteService,
        INotificationMessageService iNotificationMessageService)
    : base(iNotificationMessageService)
    {
        _iGenericConfigurationService = iGenericConfigurationService;
        _iFileWriteService = iFileWriteService;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<IEnumerable<EnvironmentTypeSettingsResponseDTO>>))]
    public async Task<IActionResult> GetAll()
    {
        var model = await _iGenericConfigurationService.EnvironmentTypeSettingsService.GetAllEnvironmentTypeSettingsAsync();
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetById/{id:long}")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<EnvironmentTypeSettingsResponseDTO>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> GetById([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id)
    {
        var existRequiredPasswordSettings = await _iGenericConfigurationService.EnvironmentTypeSettingsService.ExistEnvironmentTypeSettingsByIdAsync(id);
        if (existRequiredPasswordSettings)
        {
            var model = await _iGenericConfigurationService.EnvironmentTypeSettingsService.GetEnvironmentTypeSettingsByIdAsync(id);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("Create")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Create([FromBody, Required] EnvironmentTypeSettingsCreateRequestDTO environmentTypeSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iGenericConfigurationService.EnvironmentTypeSettingsService.CreateEnvironmentTypeSettingsAsync(environmentTypeSettingsCreateRequestDTO);

        if (result)
            return CustomResponse(ConstantHttpStatusCode.CREATE_CODE, environmentTypeSettingsCreateRequestDTO);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpPut("Update")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Update([FromRoute, Required, Range(ConstantValue.MIN_ID, ConstantValue.MAX_ID, ErrorMessage = FixConstants.ID)] long id, [FromBody, Required] EnvironmentTypeSettingsUpdateRequestDTO environmentTypeSettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        if (id != environmentTypeSettingsUpdateRequestDTO.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        if (await _iGenericConfigurationService.EnvironmentTypeSettingsService.ExistEnvironmentTypeSettingsByIdAsync(environmentTypeSettingsUpdateRequestDTO.Id.GetValueOrDefault()))
        {
            var result = await _iGenericConfigurationService.EnvironmentTypeSettingsService.UpdateEnvironmentTypeSettingsAsync(environmentTypeSettingsUpdateRequestDTO);
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
        if (await _iGenericConfigurationService.EnvironmentTypeSettingsService.ExistEnvironmentTypeSettingsByIdAsync(id))
        {
            bool result = await _iGenericConfigurationService.EnvironmentTypeSettingsService.LogicDeleteEnvironmentTypeSettingsByIdAsync(id);
            if (result)
                return CustomResponse(ConstantHttpStatusCode.OK_CODE, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }

    [HttpPost("Reactive")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Reactive([FromBody, Required] EnvironmentTypeSettingsReactiveRequestDTO environmentTypeSettingsReactiveRequestDTO)
    {
        if (await _iGenericConfigurationService.EnvironmentTypeSettingsService.ExistEnvironmentTypeSettingsByIdAsync(environmentTypeSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
        {
            bool result = await _iGenericConfigurationService.EnvironmentTypeSettingsService.ReactiveEnvironmentTypeSettingsByIdAsync(environmentTypeSettingsReactiveRequestDTO.Id.Value);
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

        var excelData = await _iGenericConfigurationService.EnvironmentTypeSettingsService.GetAllEnvironmentTypeSettingsExcelAsync();
        if (excelData?.Count() > 0)
        {
            var memoryStreamResult = SharedExtension.GetMemoryStreamType(EnumFile.Excel);
            var excelName = $"EnvironmentTypeSettings_{GuidExtension.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileWriteService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }
}

