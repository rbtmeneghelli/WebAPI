using KissLog;
using Microsoft.AspNetCore.Cors;
using WebAPI.Application.Services;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.EntitiesDTO.Configuration;
using WebAPI.Domain.EntitiesDTO.ControlPanel;
using WebAPI.Domain.Enums;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Filters.ControlPanel;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
//[Authorize("Bearer")]
[EnableCors("EnableCORS")]
[AllowAnonymous]
public sealed class ConfigurationController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;

    public ConfigurationController(
        IGenericConfigurationService iGenericConfigurationService,
        IMapper iMapperService, 
        IHttpContextAccessor iHttpContextAccessor, 
        IGenericNotifyLogsService iGenericNotifyLogsService)
    : base(iMapperService, iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iGenericConfigurationService = iGenericConfigurationService;
    }

    //private readonly IMemoryCacheService _memoryCacheService;

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var model = await _iGenericConfigurationService.AuthenticationSettingsService.GetAllAuthenticationSettingsAsync();
        return CustomResponse(model, FixConstants.SUCCESS_IN_GETALL);
    }

    //[ProducesResponseType(StatusCodes.Status201Created)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[HttpPost("Add")]
    //public async Task<IActionResult> Add([FromBody] UserRequestDTO userRequestDTO)
    //{
    //    if (ModelStateIsInvalid()) return CustomResponse(ModelState);

    //    User user = _iMapperService.Map<User>(userRequestDTO);

    //    var result = await _userService.AddAsync(user);

    //    if (result)
    //        return CreatedAtAction(nameof(Add), user);

    //    return CustomResponse();
    //}

    //[HttpPut("authenticationSettings/update")]
    //public async Task<IActionResult> AuthenticationSettingsUpdate(int id, [FromBody] AuthenticationSettingsCreateRequestDTO authenticationSettingsDTO)
    //{
    //    if (ModelStateIsInvalid()) return CustomResponse(ModelState);

    //    //User user = _iMapperService.Map<User>(userRequestDTO);

    //    //if (id != userRequestDTO.Id)
    //    //{
    //    //    NotificationError(FixConstants.ERROR_IN_GETID);
    //    //    return CustomResponse();
    //    //}

    //    //var result = await _userService.UpdateAsync(id, user);

    //    //if (result)
    //    //    return NoContent();

    //    return CustomResponse();
    //}


    //[HttpPut("environmentTypeSettings/update")]
    //public async Task<IActionResult> environmentTypeSettings(int id, [FromBody] environmentTypeSettingsDTO authenticationSettingsDTO)
    //{
    //    return CustomResponse();
    //}

    [HttpPut("expirationPasswordSettings/update")]
    public async Task<IActionResult> ExpirationPasswordSettings(int id, [FromBody] ExpirationPasswordSettingsDTO expirationPasswordSettingsDTO)
    {
        return CustomResponse();
    }

    [HttpPut("layoutSettings/update")]
    public async Task<IActionResult> LayoutSettings(int id, [FromBody] LayoutSettingsDTO layoutSettingsDTO)
    {
        return CustomResponse();
    }

    [HttpPut("logSettings/update")]
    public async Task<IActionResult> LogSettings(int id, [FromBody] LogSettingsDTO logSettingsDTO)
    {
        return CustomResponse();
    }

    [HttpPut("requiredPasswordSettings/update")]
    public async Task<IActionResult> RequiredPasswordSettings(int id, [FromBody] RequiredPasswordSettingsDTO requiredPasswordSettingsDTO)
    {
        return CustomResponse();
    }

    /// <summary>
    /// Esse endpoint ira armazenar arquivos por X tempo, e depois será atualizado após 5 minutos.
    /// </summary>
    /// <returns></returns>
    //[HttpGet("loadBanners")]
    //public async Task<IActionResult> LoadBanners()
    //{
    //    if (!_memoryCacheService.TryGet<IEnumerable<Region>>("FilesCache", out var cached))
    //    {
    //        var files = await _regionService.GetAllRegionAsync();

    //        _memoryCacheService.Set("FilesCache", files);

    //        return CustomResponse(files);
    //    }
    //    else
    //    {
    //        var files = _memoryCacheService.Get<IEnumerable<Region>>("FilesCache");
    //        return CustomResponse(files);
    //    }
    //}

    [EnableCors("EnableCORS")]
    [HttpPost("uploadMultFiles")]
    public IActionResult UploadFiles([FromForm] IEnumerable<MultFiles> multFiles)
    {
        if (multFiles is null)
        {
            NotificationError("Nenhum arquivo foi enviado.");
            return CustomResponse();
        }

        return CustomResponse();
    }

    //[HttpPost("Export2Excel")]
    //public async Task<IActionResult> Export2Excel([FromBody] UserFilter filter)
    //{
    //    if (ModelStateIsInvalid()) return CustomResponse(ModelState);

    //    var list = await _userService.GetAllPaginateAsync(filter);
    //    if (list?.Results?.Count() > 0)
    //    {
    //        var memoryStreamResult = _generalMethod.GetMemoryStreamType(EnumMemoryStreamFile.XLSX);
    //        var excelData = _iMapperService.Map<IEnumerable<UserExcelDTO>>(list.Results);
    //        var excelName = $"Usuarios.{memoryStreamResult.Extension}";
    //        var memoryStreamExcel = await _FileService.CreateExcelFileEPPLUS(excelData, excelName);
    //        return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
    //    }

    //    return NotFound();
    //}
}
