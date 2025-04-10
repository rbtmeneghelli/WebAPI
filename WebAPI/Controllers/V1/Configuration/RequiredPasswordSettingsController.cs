﻿using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Enums;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Controllers.V1.Configuration;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public sealed class RequiredPasswordSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly GeneralMethod _generalMethod;
    private readonly IFileService<RequiredPasswordSettingsExcelDTO> _iFileService;

    public RequiredPasswordSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileService<RequiredPasswordSettingsExcelDTO> iFileService,
        IHttpContextAccessor iHttpContextAccessor,
        IGenericNotifyLogsService iGenericNotifyLogsService)
    : base(iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iGenericConfigurationService = iGenericConfigurationService;
        _generalMethod = GeneralMethod.GetLoadExtensionMethods();
        _iFileService = iFileService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var model = await _iGenericConfigurationService.RequiredPasswordSettingsService.GetAllRequiredPasswordSettingsAsync();
        return CustomResponse(ConstantHttpStatusCode.OK_CODE, model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetByEnvironment")]
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
    public async Task<IActionResult> GetById(long id)
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
    public async Task<IActionResult> Create([FromBody] RequiredPasswordSettingsCreateRequestDTO requiredPasswordSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _iGenericConfigurationService.RequiredPasswordSettingsService.CreateRequiredPasswordSettingsAsync(requiredPasswordSettingsCreateRequestDTO);

        if (result)
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, requiredPasswordSettingsCreateRequestDTO);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(long id, [FromBody] RequiredPasswordSettingsUpdateRequestDTO requiredPasswordSettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

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
    public async Task<IActionResult> LogicDelete(int id)
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
    public async Task<IActionResult> Reactive(RequiredPasswordSettingsReactiveRequestDTO requiredPasswordSettingsReactiveRequestDTO)
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
    public async Task<IActionResult> ExportData()
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var excelData = await _iGenericConfigurationService.RequiredPasswordSettingsService.GetAllRequiredPasswordSettingsExcelAsync();
        if (excelData?.Count() > 0)
        {
            var memoryStreamResult = _generalMethod.GetMemoryStreamType(EnumMemoryStreamFile.XLSX);
            var excelName = $"RequiredPasswordSettings_{GuidExtensionMethod.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomResponse(ConstantHttpStatusCode.NOT_FOUND_CODE);
    }
}
