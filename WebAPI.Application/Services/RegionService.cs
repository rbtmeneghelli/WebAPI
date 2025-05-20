using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using Region = WebAPI.Domain.Entities.Others.Region;

namespace WebAPI.Application.Services;

public sealed class RegionService : BaseHandlerService, IRegionService
{
    private readonly IRegionRepository _iRegionRepository;
    private readonly IMapperService _iMapperService;

    public RegionService(IRegionRepository iRegionRepository, IMapperService iMapperService, INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
    {
        _iRegionRepository = iRegionRepository;
        _iMapperService = iMapperService;
    }

    private async Task<IQueryable<Region>> GetAllWithFilterAsync(RegionFilter filter)
    {
        return await Task.FromResult(_iRegionRepository.GetAll().Where(GetPredicate(filter)).AsQueryable());
    }

    private Expression<Func<Region, bool>> GetPredicate(RegionFilter filter)
    {
        return p =>
               (GuardClauseExtension.IsNullOrWhiteSpace(filter.Name) || p.Name.StartsWith(filter.Name.ApplyTrim()));
    }

    public async Task<IEnumerable<Region>> GetAllRegionAsync()
    {
        var result = await _iRegionRepository.GetAll().ToListAsync();
        return result;
    }

    public bool ExistRegionById(long regionId)
    {
        bool result = _iRegionRepository.Exist(param => param.Id.Value == regionId);
        return result;
    }

    public bool ExistRegion()
    {
        return _iRegionRepository.Exist(param => param.IsActive == true);
    }

    public Task CreateRegionsAsync(IEnumerable<Region> list)
    {
        _iRegionRepository.AddRange(list);
        return Task.CompletedTask;
    }

    public async Task RefreshRegionAsync(IEnumerable<States> listStatesAPI)
    {
        IEnumerable<Region> regions = await _iRegionRepository.GetAll().ToListAsync();
        IEnumerable<Region> tmpRegion = listStatesAPI.Select(x => new Region()
        {
            Name = x.Region.Name,
            Initials = x.Region.Initials,
            IsActive = true
        });

        IEnumerable<Region> listaRegiaoAPI = tmpRegion.GroupBy(x => new { x.Name, x.Initials }).Select(g => g.First());

        foreach (var item in listaRegiaoAPI)
        {

            Region region = regions.FirstOrDefault(x => x.Initials == item.Initials && x.IsActive == true);
            if (GuardClauseExtension.IsNotNull(region))
            {
                region.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
                region.Name = item.Name;
                region.Initials = item.Initials;
                _iRegionRepository.Update(region);
            }
            else
            {
                _iRegionRepository.Add(item);
            }
        }
    }

    public async Task<bool> UpdateRegionStatusByIdAsync(long id)
    {

        Region record = await Task.FromResult(_iRegionRepository.GetById(id));

        if (GuardClauseExtension.IsNotNull(record))
        {
            record.IsActive = record.IsActive == true ? false : true;
            _iRegionRepository.Update(record);
            return true;
        }

        return false;
    }

    public async Task<IEnumerable<Region>> GetAllRegionWithLikeAsync(string parameter) => await _iRegionRepository.FindBy(x => EF.Functions.Like(x.Name, $"%{parameter}%")).ToListAsync();

    public async Task<BasePagedResultModel<RegionResponseDTO>> GetAllRegionWithPaginateAsync(RegionFilter filter)
    {
        var query = await GetAllWithFilterAsync(filter);
        var queryCount = GetRegionCount(GetPredicate(filter));

        var queryResult = from x in query.AsQueryable()
                          orderby x.Name ascending
                          select new Region
                          {
                              Id = x.Id,
                              Name = x.Name,
                              Initials = x.Initials,
                              IsActive = x.IsActive
                          };

        var data = _iMapperService.MapEntityToDTOList<IEnumerable<Region>, IEnumerable<RegionResponseDTO>>(queryResult);

        return BasePagedResultService.GetPaged(data.AsQueryable(), BasePagedResultService.GetDefaultPageIndex(filter.PageIndex), BasePagedResultService.GetDefaultPageSize(filter.PageSize));
    }

    public long GetRegionCount(Expression<Func<Region, bool>> predicate)
    {
        return _iRegionRepository.GetCount(predicate);
    }

    public async Task<Region> CreateRegion(Region region)
    {
        _iRegionRepository.Add(region);
        return region;
    }

    public async Task<Region> UpdateRegion(Region region)
    {
        _iRegionRepository.Update(region);
        return region;
    }

    public async Task DeleteRegion(Region region)
    {
        _iRegionRepository.Remove(region);
    }

    public async Task<IQueryable<Region>> GetQueryAbleRegionAsync()
    {
        var result = _iRegionRepository.GetAll();
        await Task.CompletedTask;
        return result;
    }

    public Region GetRegionById(long id)
    {
        var region = _iRegionRepository.GetById(id);
        return region;
    }
}
