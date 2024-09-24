using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.EntitiesDTO.Configuration;
using WebAPI.Domain.EntitiesDTO.ControlPanel;
using WebAPI.Domain.Enums;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
//[Authorize("Bearer")]
[AllowAnonymous]
public sealed class AuthenticationSettingsController : GenericController
{
    private readonly IGenericConfigurationService _iGenericConfigurationService;
    private readonly GeneralMethod _generalMethod;
    private readonly IFileService<AuthenticationSettingsExcelDTO> _iFileService;

    public AuthenticationSettingsController(
        IGenericConfigurationService iGenericConfigurationService,
        IFileService<AuthenticationSettingsExcelDTO> iFileService,
        IMapper iMapperService,
        IHttpContextAccessor iHttpContextAccessor,
        IGenericNotifyLogsService iGenericNotifyLogsService)
    : base(iMapperService, iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iGenericConfigurationService = iGenericConfigurationService;
        _generalMethod = GeneralMethod.GetLoadExtensionMethods();
        _iFileService = iFileService;
    }

    //private readonly IMemoryCacheService _memoryCacheService;

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var model = await _iGenericConfigurationService.AuthenticationSettingsService.GetAllAuthenticationSettingsAsync();
        return CustomResponse(model, FixConstants.SUCCESS_IN_GETALL);
    }

    [HttpGet("GetByEnvironment")]
    public async Task<IActionResult> GetByEnvironment()
    {
        var existAuthenticationSettings = await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByEnvironmentAsync();
        if (existAuthenticationSettings)
        {
            var model = await _iGenericConfigurationService.AuthenticationSettingsService.GetAuthenticationSettingsByEnvironmentAsync();
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomNotFound();
    }

    [HttpGet("GetById/{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var existAuthenticationSettings = await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByIdAsync(id);
        if (existAuthenticationSettings)
        {
            var model = await _iGenericConfigurationService.AuthenticationSettingsService.GetAuthenticationSettingsByIdAsync(id);
            return CustomResponse(model, FixConstants.SUCCESS_IN_GETID);
        }

        return CustomNotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] AuthenticationSettingsCreateRequestDTO authenticationSettingsCreateRequestDTO)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var authenticationSettingsRequest = ApplyMapToEntity<AuthenticationSettingsCreateRequestDTO, AuthenticationSettings>(authenticationSettingsCreateRequestDTO);
        var result = await _iGenericConfigurationService.AuthenticationSettingsService.CreateAuthenticationSettingsAsync(authenticationSettingsRequest);

        if (result)
            return CreatedAtAction(nameof(Create), authenticationSettingsRequest);

        return CustomResponse();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(int id, [FromBody] AuthenticationSettingsUpdateRequestDTO authenticationSettingsUpdateRequestDTO )
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var authenticationSettingsRequest = ApplyMapToEntity<AuthenticationSettingsUpdateRequestDTO, AuthenticationSettings>(authenticationSettingsUpdateRequestDTO);

        if (id != authenticationSettingsRequest.Id)
        {
            NotificationError(FixConstants.ERROR_IN_GETID);
            return CustomResponse();
        }

        if (await _iGenericConfigurationService.AuthenticationSettingsService.ExistAuthenticationSettingsByIdAsync(id))
        {
            var result = await _iGenericConfigurationService.AuthenticationSettingsService.UpdateAuthenticationSettingsAsync(id, authenticationSettingsRequest);
            if (result)
                return NoContent();
            else
                return CustomResponse();
        }

        return CustomNotFound();
    }

    [HttpPost("Export2Excel")]
    public async Task<IActionResult> Export2Excel()
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var list = await _iGenericConfigurationService.AuthenticationSettingsService.GetAllAuthenticationSettingsAsync();
        if (list?.Count() > 0)
        {
            var memoryStreamResult = _generalMethod.GetMemoryStreamType(EnumMemoryStreamFile.XLSX);
            var excelData = ApplyMapToEntity<IEnumerable<AuthenticationSettingsResponseDTO>, IEnumerable<AuthenticationSettingsExcelDTO>> (list);
            var excelName = $"AuthenticationSettings_{GuidExtensionMethod.GetGuidDigits("N")}.{memoryStreamResult.Extension}";
            var memoryStreamExcel = await _iFileService.CreateExcelFileEPPLUS(excelData, excelName);
            return File(memoryStreamExcel.ToArray(), memoryStreamResult.Type, excelName);
        }

        return CustomNotFound();
    }


    //[HttpPut("environmentTypeSettings/update")]
    //public async Task<IActionResult> environmentTypeSettings(int id, [FromBody] environmentTypeSettingsDTO authenticationSettingsDTO)
    //{
    //    return CustomResponse();
    //}

    //[HttpPut("expirationPasswordSettings/update")]
    //public async Task<IActionResult> ExpirationPasswordSettings(int id, [FromBody] ExpirationPasswordSettingsDTO expirationPasswordSettingsDTO)
    //{
    //    return CustomResponse();
    //}

    //[HttpPut("layoutSettings/update")]
    //public async Task<IActionResult> LayoutSettings(int id, [FromBody] LayoutSettingsDTO layoutSettingsDTO)
    //{
    //    return CustomResponse();
    //}

    //[HttpPut("logSettings/update")]
    //public async Task<IActionResult> LogSettings(int id, [FromBody] LogSettingsDTO logSettingsDTO)
    //{
    //    return CustomResponse();
    //}

    //[HttpPut("requiredPasswordSettings/update")]
    //public async Task<IActionResult> RequiredPasswordSettings(int id, [FromBody] RequiredPasswordSettingsDTO requiredPasswordSettingsDTO)
    //{
    //    return CustomResponse();
    //}

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

    //
    //[HttpPost("uploadMultFiles")]
    //public IActionResult UploadFiles([FromForm] IEnumerable<MultFiles> multFiles)
    //{
    //    if (multFiles is null)
    //    {
    //        NotificationError("Nenhum arquivo foi enviado.");
    //        return CustomResponse();
    //    }

    //    return CustomResponse();
    //}

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
