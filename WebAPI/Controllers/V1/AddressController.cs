using Microsoft.AspNetCore.Cors;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Validations;

namespace WebAPI.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize("Bearer")]
public class AddressController : GenericController
{
    private readonly IAddressService _iAddressService;
    private readonly IStatesService _iStatesService;
    private readonly IGeneralService _iGeneralService;
    private readonly IRegionService _iRegionService;
    private readonly ICityService _iCityService;

    public AddressController(
        IAddressService iAddressService,
        IStatesService iStatesService,
        IGeneralService iGeneralService,
        IRegionService iRegionService,
        ICityService iCityService,
        IMapper iMapperService, 
        IHttpContextAccessor iHttpContextAccessor, 
        IGenericNotifyLogsService iGenericNotifyLogsService) 
        : base(iMapperService, iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iAddressService = iAddressService;
        _iStatesService = iStatesService;
        _iGeneralService = iGeneralService;
        _iRegionService = iRegionService;
        _iCityService = iCityService;
    }

    [HttpGet("getCep/{cep}/{refreshCep:bool}")]
    public async Task<IActionResult> GetCep(string cep, bool refreshCep)
    {
        try
        {
            Domain.ValueObject.AddressData modelCep = new Domain.ValueObject.AddressData();
            if (refreshCep && GuardClauses.IsNullOrWhiteSpace(cep) == false)
            {
                modelCep = await _iAddressService.GetAddressByCepAsync(cep);
                RequestData requestData = await _iGeneralService.RequestDataToExternalAPIAsync(string.Format($"{FixConstantsUrl.URL_TO_GET_CEP}{0}", cep));
                if (requestData.IsSuccess)
                {
                    Domain.ValueObject.AddressData modelCepAPI = requestData.Data.DeserializeObject<Domain.ValueObject.AddressData>();
                    if (GuardClauses.ObjectIsNotNull(modelCepAPI))
                    {
                        modelCepAPI.StateId = await _iStatesService.GetStateByInitialsAsync(modelCepAPI.Uf);
                        await _iAddressService.RefreshAddressAsync(new RefreshCep(cep, modelCep, modelCepAPI));
                        modelCep = await _iAddressService.GetAddressByCepAsync(cep);
                    }
                }
            }
            else
            {
                modelCep = await _iAddressService.GetAddressByCepAsync(cep);
            }
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, modelCep);
        }
        catch (Exception)
        {
            NotificationError($"{FixConstants.EXCEPTION_REQUEST_API} {FixConstantsUrl.URL_TO_GET_CEP}");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }
    }

    [HttpGet("getStates/{refreshStates:bool}")]
    public async Task<IActionResult> RefreshStates(bool refreshEstados)
    {
        try
        {
            IEnumerable<Region> listRegion = await _iRegionService.GetAllRegionAsync();
            IEnumerable<States> listStates = await _iStatesService.GetAllStateAsync();

            if (refreshEstados)
            {
                if (GuardClauses.ObjectIsNotNull(listStates) && GuardClauses.HaveDataOnList(listStates))
                {
                    RequestData requestData = await _iGeneralService.RequestDataToExternalAPIAsync(FixConstantsUrl.URL_TO_GET_STATES);
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

    [HttpGet("addCities")]
    public async Task<IActionResult> GetCities()
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

                requestData = await _iGeneralService.RequestDataToExternalAPIAsync(string.Format(FixConstantsUrl.URL_TO_GET_CITIES, state.Initials));

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
                await _iCityService.AddOrUpdateCityAsync(cities.OrderBy(x => x.Name));
        }
        catch (Exception)
        {
            NotificationError("Ocorreu um erro ao tentar adicionar cidades no sistema");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse(ConstantHttpStatusCode.OK_CODE, null, "Cidades foram adicionadas com sucesso");
    }

    [HttpGet("addRegions")]
    public async Task<IActionResult> AddRegions()
    {
        try
        {
            List<Region> list = new List<Region>();
            RequestData requestData = await _iGeneralService.RequestDataToExternalAPIAsync(FixConstantsUrl.URL_TO_GET_STATES);
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

    [HttpGet("addStates")]
    public async Task<IActionResult> AddStates()
    {
        try
        {
            IEnumerable<Region> listRegion = await _iRegionService.GetAllRegionAsync();
            List<States> listStates = new List<States>();
            RequestData requestData = await _iGeneralService.RequestDataToExternalAPIAsync(FixConstantsUrl.URL_TO_GET_STATES);
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
        return CustomResponse(ConstantHttpStatusCode.OK_CODE);
    }
}
