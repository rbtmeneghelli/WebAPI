using WebAPI.Configuration.ActionFilter;
using WebAPI.Domain.ExtensionMethods;
using KissLog;
using Microsoft.AspNetCore.Cors;
using FixConstants = WebAPI.Domain.FixConstants;
using Region = WebAPI.Domain.Entities.Region;

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

    public GeneralController(IMapper mapper, IHttpContextAccessor accessor, ICepService cepsService, IStatesService statesService, IRegionService regionService, ICityService cityService, INotificationMessageService notificationMessageService, IGeneralService generalService, IMemoryCacheService memoryCacheService, IKLogger iKLogger, IQRCodeService qRCodeService) : base(mapper, accessor, notificationMessageService, iKLogger)
    {
        _cepsService = cepsService;
        _statesService = statesService;
        _regionService = regionService;
        _cityService = cityService;
        _generalService = generalService;
        _memoryCacheService = memoryCacheService;
        _qRCodeService = qRCodeService;
    }

    [HttpGet("export2Zip/{directory}/{typeFile:int}")]
    public async Task<IActionResult> Export2Zip(string directory, int typeFile = 2)
    {
        GeneralExtensionMethod extensionMethods = GeneralExtensionMethod.GetLoadExtensionMethods();
        MemoryStream memoryStream = await _generalService.Export2ZipAsync(directory, typeFile);
        return File(await Task.FromResult(memoryStream.ToArray()), extensionMethods.GetMemoryStreamType(typeFile), $"Archive.{extensionMethods.GetMemoryStreamExtension(typeFile)}");
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
                RequestData requestData = await _generalService.RequestDataToExternalAPIAsync($"{FixConstants.URL_TO_GET_CEP}{cep}/json/");
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
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstants.URL_TO_GET_CEP}");
            return CustomResponse();
        }
    }

    [HttpGet("getStates/{refreshStates:bool}")]
    public async Task<IActionResult> RefreshStates(bool refreshEstados)
    {
        try
        {
            List<Region> listRegion = await _regionService.GetAllRegionAsync();
            List<States> listStates = await _statesService.GetAllStatesAsync();
            if (refreshEstados)
            {
                if (GuardClauses.ObjectIsNotNull(listStates) && GuardClauses.HaveDataOnList(listStates))
                {
                    RequestData requestData = await _generalService.RequestDataToExternalAPIAsync(FixConstants.URL_TO_GET_STATES);
                    if (requestData.IsSuccess)
                    {
                        List<States> listStatesAPI = requestData.Data.DeserializeObject<List<States>>();
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
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstants.URL_TO_GET_STATES}");
            return CustomResponse();
        }
    }

    [HttpGet("addCities")]
    public async Task<IActionResult> GetCities()
    {
        List<MesoRegion> mesoRegions = new List<MesoRegion>();
        List<City> cities = new List<City>();
        RequestData requestData = new RequestData();

        try
        {
            List<States> states = await GetListStateWithoutCities();

            if (states.Exists(x => x.Initials.ApplyTrim() is "DF"))
            {
                cities.Add(new City() { IBGE = 5300108, Name = "DISTRITO FEDERAL", StateId = states.FirstOrDefault(x => x.Initials.ApplyTrim() == "DF").Id.Value });
            }

            foreach (States state in states.Where(x => x.Initials is not "DF"))
            {

                requestData = await _generalService.RequestDataToExternalAPIAsync(string.Format(FixConstants.URL_TO_GET_CITIES, state.Initials));

                if (requestData.IsSuccess)
                {
                    mesoRegions = requestData.Data.DeserializeObject<List<MesoRegion>>();

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
                await _cityService.AddOrUpdateCityAsync(cities.OrderBy(x => x.Name).ToList());
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
            RequestData requestData = await _generalService.RequestDataToExternalAPIAsync(FixConstants.URL_TO_GET_STATES);
            if (requestData.IsSuccess)
            {
                List<States> listStatesAPI = requestData.Data.DeserializeObject<List<States>>();

                if (_regionService.GetCount(p => p.IsActive == true) < 4 && GuardClauses.ObjectIsNotNull(listStatesAPI) && GuardClauses.HaveDataOnList(listStatesAPI))
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
                        CreatedTime = FixConstants.GetDateTimeNowFromBrazil()
                    }).ToList();

                    await _regionService.AddRegionsAsync(list);
                }
            }

            return CustomResponse(list);
        }
        catch (Exception)
        {
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstants.URL_TO_GET_STATES}");
            return CustomResponse();
        }
    }

    [HttpGet("addStates")]
    public async Task<IActionResult> AddStates()
    {
        try
        {
            List<Region> listRegion = await _regionService.GetAllRegionAsync();
            List<States> listStates = new List<States>();
            RequestData requestData = await _generalService.RequestDataToExternalAPIAsync(FixConstants.URL_TO_GET_STATES);
            if (requestData.IsSuccess)
            {
                List<States> listStatesAPI = requestData.Data.DeserializeObject<List<States>>();
                if (GuardClauses.ObjectIsNotNull(listStatesAPI) && GuardClauses.HaveDataOnList(listStatesAPI) &&
                    GuardClauses.ObjectIsNotNull(listRegion) && GuardClauses.HaveDataOnList(listRegion))
                {
                    listStates = listStatesAPI.Select(x => new States()
                    {
                        CreatedTime = FixConstants.GetDateTimeNowFromBrazil(),
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
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstants.URL_TO_GET_STATES}");
            return CustomResponse();
        }
    }

    private async Task<List<States>> GetListStateWithoutCities()
    {
        List<States> listState = await _statesService.GetAllStatesAsync();
        if (listState is not null)
        {
            if (listState.Count() > 0)
            {
                IEnumerable<long> listIdState = await _cityService.GetIdStatesAsync();
                foreach (long idState in listIdState)
                {
                    listState.RemoveAll(x => x.Id == idState);
                }
            }
        }
        return listState;
    }

    [HttpPost("createQRCode")]
    public IActionResult CreateQRCode([FromBody] QRCodeFile qRCodeFile)
    {
        var image = _qRCodeService.CreateQRCode(qRCodeFile);
        return File(image, "image/png");
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
        if (!_memoryCacheService.TryGet<List<Region>>("FilesCache", out var cached))
        {
            var files = await _regionService.GetAllRegionAsync();

            _memoryCacheService.Set("FilesCache", files);

            return CustomResponse(files);
        }
        else
        {
            var files = _memoryCacheService.Get<List<Region>>("FilesCache");
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
        return $"Acesso BLOQUEADO para este endpoint : {DateTime.Now}";
    }

    [EnableCors("EnableCORS")]
    [HttpPost("uploadMultFiles")]
    public IActionResult UploadFiles([FromForm] List<MultFiles> multFiles)
    {
        if (multFiles is null)
        {
            NotificationError("Nenhum arquivo foi enviado.");
            return CustomResponse();
        }

        return CustomResponse();
    }
}
