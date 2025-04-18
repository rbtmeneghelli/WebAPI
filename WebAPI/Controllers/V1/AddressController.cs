using FastPackForShare.Constants;
using FastPackForShare.Controllers.Generics;
using FastPackForShare.Extensions;
using FastPackForShare.Interfaces;
using FastPackForShare.Models;

namespace WebAPI.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class AddressController : GenericController
{
    private readonly IAddressService _iAddressService;
    private readonly IStatesService _iStatesService;
    private readonly IDataFromApiService<RequestDataModel> _iDataFromApiService;
    private readonly IRegionService _iRegionService;
    private readonly ICityService _iCityService;

    public AddressController(
        IAddressService iAddressService,
        IStatesService iStatesService,
        IDataFromApiService<RequestDataModel> iDataFromApiService,
        IRegionService iRegionService,
        ICityService iCityService,
        INotificationMessageService notificationMessageService)
        : base(notificationMessageService)
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
        Domain.ValueObject.AddressData modelAddress = new Domain.ValueObject.AddressData();

        if (refreshAddress && GuardClauseExtension.IsNullOrWhiteSpace(address) == false)
        {
            modelAddress = await _iAddressService.GetAddressByCepAsync(address);
            RequestDataModel requestData = await _iDataFromApiService.GetDataFromExternalAPI(string.Format($"{FixConstantsUrl.URL_TO_GET_ZIPPOSTALCODE}{0}", address));
            if (requestData.IsSuccess)
            {
                Domain.ValueObject.AddressData modelAddressAPI = requestData.Data.DeserializeObject<Domain.ValueObject.AddressData>();
                if (GuardClauseExtension.IsNotNull(modelAddressAPI))
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

    [HttpGet("getStates/{refreshStates:bool}")]
    public async Task<IActionResult> GetStates(bool refreshStates)
    {
        IEnumerable<Region> listRegion = await _iRegionService.GetAllRegionAsync();
        IEnumerable<States> listStates = await _iStatesService.GetAllStateAsync();

        if (refreshStates)
        {
            if (GuardClauseExtension.IsNotNull(listStates) && GuardClauseExtension.HaveDataOnList(listStates))
            {
                RequestDataModel requestData = await _iDataFromApiService.GetDataFromExternalAPI(FixConstantsUrl.URL_TO_GET_STATES);
                if (requestData.IsSuccess)
                {
                    IEnumerable<States> listStatesAPI = requestData.Data.DeserializeObject<IEnumerable<States>>();
                    if (GuardClauseExtension.IsNotNull(listStatesAPI) && GuardClauseExtension.HaveDataOnList(listStatesAPI))
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

    [HttpGet("insertCities")]
    public async Task<IActionResult> InsertCities()
    {
        IEnumerable<MesoRegion> mesoRegions = Enumerable.Empty<MesoRegion>();
        List<City> cities = new List<City>();
        RequestDataModel requestData = new RequestDataModel();

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

            requestData = await _iDataFromApiService.GetDataFromExternalAPI(string.Format(FixConstantsUrl.URL_TO_GET_CITIES, state.Initials));

            if (requestData.IsSuccess)
            {
                mesoRegions = requestData.Data.DeserializeObject<IEnumerable<MesoRegion>>();

                if (GuardClauseExtension.IsNotNull(mesoRegions) && mesoRegions.Count() > 0)
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

        return CustomResponse(ConstantHttpStatusCode.OK_CODE, null, "Cidades foram adicionadas com sucesso");
    }

    [HttpGet("insertRegions")]
    public async Task<IActionResult> InsertRegions()
    {
        List<Region> list = new List<Region>();
        RequestDataModel requestData = await _iDataFromApiService.GetDataFromExternalAPI(FixConstantsUrl.URL_TO_GET_STATES);

        if (requestData.IsSuccess)
        {
            IEnumerable<States> listStatesAPI = requestData.Data.DeserializeObject<IEnumerable<States>>();

            if (_iRegionService.ExistRegion() == false && GuardClauseExtension.IsNotNull(listStatesAPI) && GuardClauseExtension.HaveDataOnList(listStatesAPI))
            {
                list = listStatesAPI.Select(x => new
                {
                    Nome = x.Region.Name,
                    Sigla = x.Region.Initials,
                }).Distinct().Select(z => new Region()
                {
                    Name = z.Nome,
                    IsActive = true,
                    Initials = z.Sigla
                }).ToList();

                await _iRegionService.CreateRegionsAsync(list);
            }
        }

        return CustomResponse(ConstantHttpStatusCode.OK_CODE, list);
    }

    [HttpGet("insertStates")]
    public async Task<IActionResult> InsertStates()
    {
        IEnumerable<Region> listRegion = await _iRegionService.GetAllRegionAsync();
        List<States> listStates = new List<States>();
        RequestDataModel requestData = await _iDataFromApiService.GetDataFromExternalAPI(FixConstantsUrl.URL_TO_GET_STATES);

        if (requestData.IsSuccess)
        {
            IEnumerable<States> listStatesAPI = requestData.Data.DeserializeObject<IEnumerable<States>>();

            if (GuardClauseExtension.IsNotNull(listStatesAPI) && GuardClauseExtension.HaveDataOnList(listStatesAPI) &&
                GuardClauseExtension.IsNotNull(listRegion) && GuardClauseExtension.HaveDataOnList(listRegion))
            {
                listStates = listStatesAPI.Select(x => new States()
                {
                    IsActive = true,
                    Name = x.Name,
                    Initials = x.Initials,
                    RegionId = listRegion.FirstOrDefault(z => z.Initials == x.Region.Initials).Id.GetValueOrDefault(0)
                }).ToList();

                await _iStatesService.CreateStatesAsync(listStates);
            }
        }

        return CustomResponse(ConstantHttpStatusCode.OK_CODE, listStates);
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
