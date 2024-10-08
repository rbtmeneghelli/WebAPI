﻿using WebAPI.Domain.Constants;
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
public sealed class LogSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly GeneralMethod _generalMethod;
    private readonly IFileService<LogSettingsExcelDTO> _iFileService;

    public LogSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileService<LogSettingsExcelDTO> iFileService,
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
        var model = await _iGenericConfigurationService.LogSettingsService.GetAllLogSettingsAsync();
        return CustomResponse(model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetByEnvironment")]
    public async Task<IActionResult> GetByEnvironment()
    {
        var existLogSettings = await _iGenericConfigurationService.LogSettingsService.ExistLogSettingsByEnvironmentAsync();
        if (existLogSettings)
        {
            var model = await _iGenericConfigurationService.LogSettingsService.GetLogSettingsByEnvironmentAsync();
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomNotFound();
    }

    [HttpGet("GetById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var existLogSettings = await _iGenericConfigurationService.LogSettingsService.ExistLogSettingsByIdAsync(id);
        if (existLogSettings)
        {
            var model = await _iGenericConfigurationService.LogSettingsService.GetLogSettingsByIdAsync(id);
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomNotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] LogSettingsCreateRequestDTO logSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var logSettingsCreateRequest = ApplyMapToEntity<LogSettingsCreateRequestDTO, LogSettings>(logSettingsCreateRequestDTO);
        var result = await _iGenericConfigurationService.LogSettingsService.CreateLogSettingsAsync(logSettingsCreateRequest);

        if (result)
            return CreatedAtAction(nameof(Create), logSettingsCreateRequest);

        return CustomResponse();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(long id, [FromBody] LogSettingsUpdateRequestDTO logSettingsUpdateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var logSettingsUpdateRequest = ApplyMapToEntity<LogSettingsUpdateRequestDTO, LogSettings>(logSettingsUpdateRequestDTO);

        if (id != logSettingsUpdateRequest.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse();
        }

        if (await _iGenericConfigurationService.LogSettingsService.ExistLogSettingsByIdAsync(logSettingsUpdateRequest.Id.GetValueOrDefault()))
        {
            var result = await _iGenericConfigurationService.LogSettingsService.UpdateLogSettingsAsync(logSettingsUpdateRequest);
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
        if (await _iGenericConfigurationService.LogSettingsService.ExistLogSettingsByIdAsync(id))
        {
            bool result = await _iGenericConfigurationService.LogSettingsService.LogicDeleteLogSettingsByIdAsync(id);
            if (result)
                return CustomResponse(default, FixConstants.SUCCESS_IN_DELETELOGIC);
            else
                return CustomResponse();
        }

        return CustomNotFound();
    }

    [HttpPost("Reactive")]
    public async Task<IActionResult> Reactive(LogSettingsReactiveRequestDTO logSettingsReactiveRequestDTO)
    {
        if (await _iGenericConfigurationService.LogSettingsService.ExistLogSettingsByIdAsync(logSettingsReactiveRequestDTO.Id.GetValueOrDefault()))
        {
            bool result = await _iGenericConfigurationService.LogSettingsService.ReactiveLogSettingsByIdAsync(logSettingsReactiveRequestDTO.Id.Value);
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

        var excelData = await _iGenericConfigurationService.LogSettingsService.GetAllLogSettingsExcelAsync();
        if (excelData?.Count() > 0)
        {
            var memoryStreamResult = _generalMethod.GetMemoryStreamType(EnumMemoryStreamFile.XLSX);
            var excelName = $"LogSettings_{GuidExtensionMethod.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomNotFound();
    }
}