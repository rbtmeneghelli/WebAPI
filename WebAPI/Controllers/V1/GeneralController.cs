using WebAPI.Configuration.ActionFilter;
using WebAPI.Domain.ExtensionMethods;
using KissLog;
using Microsoft.AspNetCore.Cors;
using FixConstants = WebAPI.Domain.FixConstants;
using Region = WebAPI.Domain.Entities.Region;
using WebAPI.Domain.Enums;
using System.Reflection;
using SkiaSharp;
using WebAPI.Domain.Validations;
using ZXing;

namespace WebAPI.V1.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[AllowAnonymous]
public sealed class GeneralController : GenericController
{
    private readonly ICepService _cepsService;
    private readonly IStatesService _statesService;
    private readonly IRegionService _regionService;
    private readonly ICityService _cityService;
    private readonly IGeneralService _generalService;
    private readonly IMemoryCacheService _memoryCacheService;
    private readonly IQRCodeService _qRCodeService;
    private readonly IFirebaseService _fireBaseService;
    private readonly IEmailService _emailService;
    private readonly GeneralMethod _generalMethod;

    private EnvironmentVariables _environmentVariables { get; }

    public GeneralController(IMapper mapper, IHttpContextAccessor accessor, ICepService cepsService, IStatesService statesService,
                             IRegionService regionService, ICityService cityService, INotificationMessageService notificationMessageService,
                             IGeneralService generalService, IMemoryCacheService memoryCacheService, IKLogger iKLogger,
                             IQRCodeService qRCodeService, EnvironmentVariables environmentVariables,
                             IFirebaseService fireBaseService, IEmailService emailService) : base(mapper, accessor, notificationMessageService, iKLogger)
    {
        _cepsService = cepsService;
        _statesService = statesService;
        _regionService = regionService;
        _cityService = cityService;
        _generalService = generalService;
        _memoryCacheService = memoryCacheService;
        _qRCodeService = qRCodeService;
        _environmentVariables = environmentVariables;
        _fireBaseService = fireBaseService;
        _generalMethod = GeneralMethod.GetLoadExtensionMethods();
        _emailService = emailService;
    }

    [HttpGet("export2Zip/{directory}/{typeFile:int?}")]
    public async Task<IActionResult> Export2Zip(string directory, int? typeFile)
    {
        EnumMemoryStreamFile enumtypeFile = typeFile.HasValue ? (EnumMemoryStreamFile)typeFile : EnumMemoryStreamFile.PDF;
        MemoryStream memoryStream = await _generalService.Export2ZipAsync(directory, enumtypeFile);
        var memoryStreamResult = _generalMethod.GetMemoryStream(enumtypeFile);
        return File(await Task.FromResult(memoryStream.ToArray()), memoryStreamResult.Type, $"Archive.{memoryStreamResult.Extension}");
    }

    [HttpGet("backup/{directory}")]
    public async Task<IActionResult> Backup(string directory)
    {
        var result = await _generalService.RunSqlBackupAsync(directory);

        if (result)
            return CustomResponse(null, "Backup executado com sucesso");

        return CustomResponse();
    }

    [HttpGet("getCep/{cep}/{refreshCep:bool}")]
    public async Task<IActionResult> GetCep(string cep, bool refreshCep)
    {
        try
        {
            Domain.ValueObject.AddressData modelCep = new Domain.ValueObject.AddressData();
            if (refreshCep && GuardClauses.IsNullOrWhiteSpace(cep) == false)
            {
                modelCep = await _cepsService.GetByCepAsync(cep);
                RequestData requestData = await _generalService.RequestDataToExternalAPIAsync(string.Format($"{FixConstantsUrl.URL_TO_GET_CEP}{0}", cep));
                if (requestData.IsSuccess)
                {
                    Domain.ValueObject.AddressData modelCepAPI = requestData.Data.DeserializeObject<Domain.ValueObject.AddressData>();
                    if (GuardClauses.ObjectIsNotNull(modelCepAPI))
                    {
                        modelCepAPI.StateId = await _statesService.GetStateByInitialsAsync(modelCepAPI.Uf);
                        await _cepsService.RefreshCepAsync(new RefreshCep(cep, modelCep, modelCepAPI));
                        modelCep = await _cepsService.GetByCepAsync(cep);
                    }
                }
            }
            else
            {
                modelCep = await _cepsService.GetByCepAsync(cep);
            }
            return CustomResponse(modelCep);
        }
        catch (Exception)
        {
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstantsUrl.URL_TO_GET_CEP}");
            return CustomResponse();
        }
    }

    [HttpGet("getStates/{refreshStates:bool}")]
    public async Task<IActionResult> RefreshStates(bool refreshEstados)
    {
        try
        {
            IEnumerable<Region> listRegion = await _regionService.GetAllRegionAsync();
            IEnumerable<States> listStates = await _statesService.GetAllStatesAsync();

            if (refreshEstados)
            {
                if (GuardClauses.ObjectIsNotNull(listStates) && GuardClauses.HaveDataOnList(listStates))
                {
                    RequestData requestData = await _generalService.RequestDataToExternalAPIAsync(FixConstantsUrl.URL_TO_GET_STATES);
                    if (requestData.IsSuccess)
                    {
                        IEnumerable<States> listStatesAPI = requestData.Data.DeserializeObject<IEnumerable<States>>();
                        if (GuardClauses.ObjectIsNotNull(listStatesAPI) && GuardClauses.HaveDataOnList(listStatesAPI))
                        {
                            await _regionService.RefreshRegionAsync(listStatesAPI);
                            await _statesService.RefreshStatesAsync(new RefreshStates(listStates, listStatesAPI, listRegion));
                            listStates = await _statesService.GetAllStatesAsync();
                        }
                    }
                }
            }
            return CustomResponse(listStates);
        }
        catch (Exception)
        {
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstantsUrl.URL_TO_GET_STATES}");
            return CustomResponse();
        }
    }

    [HttpGet("addCities")]
    public async Task<IActionResult> GetCities()
    {
        IEnumerable<MesoRegion> mesoRegions = Enumerable.Empty<MesoRegion>();
        List<City> cities = new List<City>();
        RequestData requestData = new RequestData();

        try
        {
            List<States> states = await GetListStateWithoutCities();

            if (states.Exists(x => x.Initials.ApplyTrim() == City.GetDFNickNameFromIBGE()))
            {
                cities.Add(new City()
                {
                    IBGE = City.GetDFCodeFromIBGE(),
                    Name = City.GetDFNameFromIBGE(),
                    StateId = states.FirstOrDefault(x => x.Initials.ApplyTrim() == City.GetDFNickNameFromIBGE()).Id.Value
                });
            }

            foreach (States state in states.Where(x => x.Initials != City.GetDFNickNameFromIBGE()))
            {

                requestData = await _generalService.RequestDataToExternalAPIAsync(string.Format(FixConstantsUrl.URL_TO_GET_CITIES, state.Initials));

                if (requestData.IsSuccess)
                {
                    mesoRegions = requestData.Data.DeserializeObject<IEnumerable<MesoRegion>>();

                    if (GuardClauses.ObjectIsNotNull(mesoRegions) && mesoRegions.Count() > 0)
                    {
                        cities.AddRange(mesoRegions.Select(item => new City()
                        {
                            IBGE = (long)item.Id,
                            Name = item.Nome,
                            StateId = state.Id.Value
                        }).ToList());
                    }
                }
            }

            if (cities.Count() > 0)
                await _cityService.AddOrUpdateCityAsync(cities.OrderBy(x => x.Name));
        }
        catch (Exception)
        {
            NotificationError("Ocorreu um erro ao tentar adicionar cidades no sistema");
            return CustomResponse();
        }

        return CustomResponse(null, "Cidades foram adicionadas com sucesso");
    }

    [HttpGet("addRegions")]
    public async Task<IActionResult> AddRegions()
    {
        try
        {
            List<Region> list = new List<Region>();
            RequestData requestData = await _generalService.RequestDataToExternalAPIAsync(FixConstantsUrl.URL_TO_GET_STATES);
            if (requestData.IsSuccess)
            {
                IEnumerable<States> listStatesAPI = requestData.Data.DeserializeObject<IEnumerable<States>>();

                if (_regionService.ExistRegion() == false && GuardClauses.ObjectIsNotNull(listStatesAPI) && GuardClauses.HaveDataOnList(listStatesAPI))
                {
                    list = listStatesAPI.Select(x => new
                    {
                        Nome = x.Region.Name,
                        Sigla = x.Region.Initials,
                    }).Distinct().Select(z => new Region()
                    {
                        Name = z.Nome,
                        IsActive = true,
                        Initials = z.Sigla,
                        CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil()
                    }).ToList();

                    await _regionService.AddRegionsAsync(list);
                }
            }

            return CustomResponse(list);
        }
        catch (Exception)
        {
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstantsUrl.URL_TO_GET_STATES}");
            return CustomResponse();
        }
    }

    [HttpGet("addStates")]
    public async Task<IActionResult> AddStates()
    {
        try
        {
            IEnumerable<Region> listRegion = await _regionService.GetAllRegionAsync();
            List<States> listStates = new List<States>();
            RequestData requestData = await _generalService.RequestDataToExternalAPIAsync(FixConstantsUrl.URL_TO_GET_STATES);
            if (requestData.IsSuccess)
            {
                IEnumerable<States> listStatesAPI = requestData.Data.DeserializeObject<IEnumerable<States>>();
                if (GuardClauses.ObjectIsNotNull(listStatesAPI) && GuardClauses.HaveDataOnList(listStatesAPI) &&
                    GuardClauses.ObjectIsNotNull(listRegion) && GuardClauses.HaveDataOnList(listRegion))
                {
                    listStates = listStatesAPI.Select(x => new States()
                    {
                        CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(),
                        IsActive = true,
                        Name = x.Name,
                        Initials = x.Initials,
                        RegionId = listRegion.FirstOrDefault(z => z.Initials == x.Region.Initials).Id.GetValueOrDefault(0)
                    }).ToList();

                    await _statesService.AddStatesAsync(listStates);
                }
            }

            return CustomResponse(listStates);
        }
        catch (Exception)
        {
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstantsUrl.URL_TO_GET_STATES}");
            return CustomResponse();
        }
    }

    private async Task<List<States>> GetListStateWithoutCities()
    {
        List<States> listState = await _statesService.GetAllStatesAsync();

        if (listState is not null)
        {
            IEnumerable<long> listIdState = await _cityService.GetIdStatesAsync();
            foreach (long idState in listIdState)
            {
                listState.RemoveAll(x => x.Id == idState);
            }
        }
        return listState;
    }

    [HttpPost("createQRCode")]
    public IActionResult CreateQRCode([FromBody] QRCodeFile qRCodeFile)
    {
        var memoryStreamResult = _generalMethod.GetMemoryStream(EnumMemoryStreamFile.PNG);
        var image = _qRCodeService.CreateQRCode(qRCodeFile);
        return File(image, memoryStreamResult.Type);
    }

    [HttpPost("readQRCode")]
    public IActionResult ReadQRCode(IFormFile qrCodeFile)
    {
        if (GuardClauses.ObjectIsNull(qrCodeFile) || qrCodeFile.Length == 0)
        {
            NotificationError("Nenhum arquivo foi enviado.");
            return CustomResponse();
        }

        return CustomResponse(_qRCodeService.ReadQrCode(qrCodeFile));
    }

    /// <summary>
    /// Esse endpoint ira armazenar arquivos por X tempo, e depois será atualizado após 5 minutos.
    /// </summary>
    /// <returns></returns>
    [HttpGet("loadBanners")]
    public async Task<IActionResult> LoadBanners()
    {
        if (!_memoryCacheService.TryGet<IEnumerable<Region>>("FilesCache", out var cached))
        {
            var files = await _regionService.GetAllRegionAsync();

            _memoryCacheService.Set("FilesCache", files);

            return CustomResponse(files);
        }
        else
        {
            var files = _memoryCacheService.Get<IEnumerable<Region>>("FilesCache");
            return CustomResponse(files);
        }
    }

    /// <summary>
    /// Esse endpoint irá funcionar apenas se o IP listado não estiver bloqueado para seu uso
    /// </summary>
    /// <returns></returns>
    [ServiceFilter(typeof(IPBlockActionFilter))]
    [HttpGet("bloqueado")]
    public string Bloqueado()
    {
        var teste = _environmentVariables;
        return $"Acesso BLOQUEADO para este endpoint : {DateOnlyExtensionMethods.GetDateTimeNowFromBrazil()}";
    }

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

    [HttpGet("loadEnvironmentVariables")]
    public IActionResult LoadEnvironmentVariables()
    {
        try
        {
            return CustomResponse(_environmentVariables.ConnectionStringSettings.SerializeObject(), "Variaveis de ambiente");
        }
        catch (Exception ex)
        {
            NotificationError("Ocorreu um erro durante a leitura das var de ambiente");
            return CustomResponse();
        }
    }

    [HttpGet("SendPushNotification")]
    public async Task<IActionResult> SendPushNotification()
    {
        await _fireBaseService.SendPushNotification_V2("Xpto", "isso e um teste");
        return CustomResponse();
    }

    [EnableCors("EnableCORS")]
    [HttpPost("refreshEnvironmentVariables")]
    public IActionResult RefreshEnvironmentVariables([FromBody] EnvironmentVarSettings environmentVarSettings)
    {
        try
        {
            if (_environmentVariables is null)
            {
                NotificationError("Ocorreu um erro durante o processo de atualização das var de ambiente");
                return CustomResponse();
            }

#if DEBUG
            _generalService.RefreshEnvironmentVarLocal(environmentVarSettings);
#else
                _generalService.RefreshEnvironmentVarAzure(environmentVarSettings);
#endif
        }
        catch (Exception ex)
        {
            NotificationError("Ocorreu um erro durante o processo de atualização das var de ambiente");
        }

        return CustomResponse();
    }

    [EnableCors("EnableCORS")]
    [HttpPost("validateRegionData")]
    public async Task<IActionResult> ValidateRegionData(Region region)
    {
        var regionValidator = new RegionValidation();
        var validationResult = regionValidator.Validate(region);

        if (!validationResult.IsValid)
        {
            NotificationError(string.Join("", validationResult.Errors.Select(x => x.ErrorMessage)));
        }

        await Task.CompletedTask;
        return CustomResponse();
    }

    [HttpGet("testSendEmail")]
    public async Task<IActionResult> TestSendEmail()
    {
        await _emailService.CustomSendEmailAsync(EnumEmail.Welcome, "teste@gmail.com", "XPTO");
        return CustomResponse();
    }
}
