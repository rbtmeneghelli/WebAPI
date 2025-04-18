using FastPackForShare.Interfaces;
using FastPackForShare.Models;
using FastPackForShare.Services.Bases;

namespace WebAPI.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public class AddressController : BaseHandlerService
{
    private readonly IAddressService _iAddressService;
    private readonly IStatesService _iStatesService;
    private readonly IDataFromApiService<RequestDataModel> _iDataFromApiService;
    private readonly IRegionService _iRegionService;
    private readonly ICityService _iCityService;

    public AddressController(
        IAddressService iAddressService,
        IStatesService iStatesService,
        IDataFromApiService<RequestData> iDataFromApiService,
        IRegionService iRegionService,
        ICityService iCityService,
        IHttpContextAccessor iHttpContextAccessor, 
        IGenericNotifyLogsService iGenericNotifyLogsService) 
        : base(iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iAddressService = iAddressService;
        _iStatesService = iStatesService;
        _iDataFromApiService = iDataFromApiService;
        _iRegionService = iRegionService;
        _iCityService = iCityService;
    }

    [HttpGet("getAddress/{address:string}/{refreshAddress:bool}")]
    public async Task<IActionResult> GetAddress(string address, bool refreshAddress)
    {
        try
        {
            Domain.ValueObject.AddressData modelAddress = new Domain.ValueObject.AddressData();
            if (refreshAddress && GuardClauses.IsNullOrWhiteSpace(address) == false)
            {
                modelAddress = await _iAddressService.GetAddressByCepAsync(address);
                RequestData requestData = await _iDataFromApiService.RequestDataToExternalAPIAsync(string.Format($"{FixConstantsUrl.URL_TO_GET_CEP}{0}", address));
                if (requestData.IsSuccess)
                {
                    Domain.ValueObject.AddressData modelAddressAPI = requestData.Data.DeserializeObject<Domain.ValueObject.AddressData>();
                    if (GuardClauses.ObjectIsNotNull(modelAddressAPI))
                    {
                        modelAddressAPI.StateId = await _iStatesService.GetStateByInitialsAsync(modelAddressAPI.Uf);
                        await _iAddressService.RefreshAddressAsync(new RefreshCep(address, modelAddress, modelAddressAPI));
                        modelAddress = await _iAddressService.GetAddressByCepAsync(address);
                    }
                }
            }
            else
            {
                modelAddress = await _iAddressService.GetAddressByCepAsync(address);
            }
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, modelAddress);
        }
        catch (Exception)
        {
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstantsUrl.URL_TO_GET_CEP}");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }
    }

    [HttpGet("getStates/{refreshStates:bool}")]
    public async Task<IActionResult> GetStates(bool refreshStates)
    {
        try
        {
            IEnumerable<Region> listRegion = await _iRegionService.GetAllRegionAsync();
            IEnumerable<States> listStates = await _iStatesService.GetAllStateAsync();

            if (refreshStates)
            {
                if (GuardClauses.ObjectIsNotNull(listStates) && GuardClauses.HaveDataOnList(listStates))
                {
                    RequestData requestData = await _iDataFromApiService.RequestDataToExternalAPIAsync(FixConstantsUrl.URL_TO_GET_STATES);
                    if (requestData.IsSuccess)
                    {
                        IEnumerable<States> listStatesAPI = requestData.Data.DeserializeObject<IEnumerable<States>>();
                        if (GuardClauses.ObjectIsNotNull(listStatesAPI) && GuardClauses.HaveDataOnList(listStatesAPI))
                        {
                            await _iRegionService.RefreshRegionAsync(listStatesAPI);
                            await _iStatesService.RefreshStatesAsync(new RefreshStates(listStates, listStatesAPI, listRegion));
                            listStates = await _iStatesService.GetAllStateAsync();
                        }
                    }
                }
            }
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, listStates);
        }
        catch (Exception)
        {
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstantsUrl.URL_TO_GET_STATES}");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }
    }

    [HttpGet("insertCities")]
    public async Task<IActionResult> InsertCities()
    {
        IEnumerable<MesoRegion> mesoRegions = Enumerable.Empty<MesoRegion>();
        List<City> cities = new List<City>();
        RequestData requestData = new RequestData();

        try
        {
            List<States> states = await _iStatesService.GetListStateWithoutCities();

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

                requestData = await _iDataFromApiService.RequestDataToExternalAPIAsync(string.Format(FixConstantsUrl.URL_TO_GET_CITIES, state.Initials));

                if (requestData.IsSuccess)
                {
                    mesoRegions = requestData.Data.DeserializeObject<IEnumerable<MesoRegion>>();

                    if (GuardClauses.ObjectIsNotNull(mesoRegions) && mesoRegions.Count() > 0)
                    {
                        cities.AddRange(mesoRegions.Select(item => new City()
                        {
                            IBGE = (long)item.Id,
                            Name = item.Name,
                            StateId = state.Id.Value
                        }).ToList());
                    }
                }
            }

            if (cities.Count() > 0)
                await _iCityService.AddOrUpdateCityAsync(cities.OrderBy(x => x.Name));
        }
        catch (Exception)
        {
            NotificationError("Ocorreu um erro ao tentar adicionar cidades no sistema");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.OK_CODE, null, "Cidades foram adicionadas com sucesso");
    }

    [HttpGet("insertRegions")]
    public async Task<IActionResult> InsertRegions()
    {
        try
        {
            List<Region> list = new List<Region>();
            RequestData requestData = await _iDataFromApiService.RequestDataToExternalAPIAsync(FixConstantsUrl.URL_TO_GET_STATES);
            if (requestData.IsSuccess)
            {
                IEnumerable<States> listStatesAPI = requestData.Data.DeserializeObject<IEnumerable<States>>();

                if (_iRegionService.ExistRegion() == false && GuardClauses.ObjectIsNotNull(listStatesAPI) && GuardClauses.HaveDataOnList(listStatesAPI))
                {
                    list = listStatesAPI.Select(x => new
                    {
                        Nome = x.Region.Name,
                        Sigla = x.Region.Initials,
                    }).Distinct().Select(z => new Region()
                    {
                        Name = z.Nome,
                        Status = true,
                        Initials = z.Sigla
                    }).ToList();

                    await _iRegionService.CreateRegionsAsync(list);
                }
            }

            return CustomResponse(ConstantHttpStatusCode.OK_CODE, list);
        }
        catch (Exception)
        {
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstantsUrl.URL_TO_GET_STATES}");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }
    }

    [HttpGet("insertStates")]
    public async Task<IActionResult> InsertStates()
    {
        try
        {
            IEnumerable<Region> listRegion = await _iRegionService.GetAllRegionAsync();
            List<States> listStates = new List<States>();
            RequestData requestData = await _iDataFromApiService.RequestDataToExternalAPIAsync(FixConstantsUrl.URL_TO_GET_STATES);
            if (requestData.IsSuccess)
            {
                IEnumerable<States> listStatesAPI = requestData.Data.DeserializeObject<IEnumerable<States>>();
                if (GuardClauses.ObjectIsNotNull(listStatesAPI) && GuardClauses.HaveDataOnList(listStatesAPI) &&
                    GuardClauses.ObjectIsNotNull(listRegion) && GuardClauses.HaveDataOnList(listRegion))
                {
                    listStates = listStatesAPI.Select(x => new States()
                    {
                        Status = true,
                        Name = x.Name,
                        Initials = x.Initials,
                        RegionId = listRegion.FirstOrDefault(z => z.Initials == x.Region.Initials).Id.GetValueOrDefault(0)
                    }).ToList();

                    await _iStatesService.CreateStatesAsync(listStates);
                }
            }

            return CustomResponse(ConstantHttpStatusCode.OK_CODE, listStates);
        }
        catch (Exception)
        {
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstantsUrl.URL_TO_GET_STATES}");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }
    }

    [EnableCors("APICORS")]
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
        return CustomResponse(ConstantHttpStatusCode.OK_CODE);
    }
}
