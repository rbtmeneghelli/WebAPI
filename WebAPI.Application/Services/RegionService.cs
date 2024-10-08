using WebAPI.Application.Factory;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Tools;
using Region = WebAPI.Domain.Entities.Others.Region;

namespace WebAPI.Application.Services;

public class RegionService : GenericService, IRegionService
{
    private readonly IRegionRepository _iRegionRepository;

    public RegionService(IRegionRepository iRegionRepository, INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
    {
        _iRegionRepository = iRegionRepository;
    }

    private async Task<IQueryable<Region>> GetAllWithFilterAsync(RegionFilter filter)
    {
        return await Task.FromResult(_iRegionRepository.GetAll().Where(GetPredicate(filter)).AsQueryable());
    }

    private Expression<Func<Region, bool>> GetPredicate(RegionFilter filter)
    {
        return p =>
               (GuardClauses.IsNullOrWhiteSpace(filter.Name) || p.Name.StartsWith(filter.Name.ApplyTrim()));
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
        return _iRegionRepository.Exist(param => param.Status == true);
    }

    public Task CreateRegionsAsync(IEnumerable<Region> list)
    {
        _iRegionRepository.AddRange(list);
        return Task.CompletedTask;
    }

    public async Task RefreshRegionAsync(IEnumerable<States> listStatesAPI)
    {
        try
        {
            IEnumerable<Region> regions = await _iRegionRepository.GetAll().ToListAsync();
            IEnumerable<Region> tmpRegion = listStatesAPI.Select(x => new Region()
            {
                Name = x.Region.Name,
                Initials = x.Region.Initials,
                Status = true
            });

            IEnumerable<Region> listaRegiaoAPI = tmpRegion.GroupBy(x => new { x.Name, x.Initials }).Select(g => g.First());

            foreach (var item in listaRegiaoAPI)
            {

                Region region = regions.FirstOrDefault(x => x.Initials == item.Initials && x.Status == true);
                if (GuardClauses.ObjectIsNotNull(region))
                {
                    region.UpdateDate = region.GetNewUpdateDate();
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
        catch
        {
            Notify(FixConstants.ERROR_IN_REFRESHREGION);
        }
    }

    public async Task<bool> UpdateRegionStatusByIdAsync(long id)
    {
        try
        {
            Region record = await Task.FromResult(_iRegionRepository.GetById(id));
            if (GuardClauses.ObjectIsNotNull(record))
            {
                record.Status = record.Status == true ? false : true;
                _iRegionRepository.Update(record);
                return true;
            }
            return false;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
    }

    public async Task<IEnumerable<Region>> GetAllRegionWithLikeAsync(string parameter) => await _iRegionRepository.FindBy(x => EF.Functions.Like(x.Name, $"%{parameter}%")).ToListAsync();

    public async Task<PagedResult<Region>> GetAllRegionWithPaginateAsync(RegionFilter filter)
    {
        try
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
                                  Status = x.Status
                              };

            return PagedFactory.GetPaged(queryResult, PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return PagedFactory.GetPaged(Enumerable.Empty<Region>().AsQueryable(), PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
        }
    }

    public long GetRegionCount(Expression<Func<Region, bool>> predicate)
    {
        return _iRegionRepository.GetCount(predicate);
    }

    public async Task<Region> CreateRegion(Region region)
    {
        try
        {
            _iRegionRepository.Add(region);
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_ADD);
        }
        finally
        {
            await Task.CompletedTask;
        }

        return region;
    }

    public async Task<Region> UpdateRegion(Region region)
    {
        try
        {
            _iRegionRepository.Update(region);
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_ADD);
        }
        finally
        {
            await Task.CompletedTask;
        }

        return region;
    }

    public async Task DeleteRegion(Region region)
    {
        try
        {
            _iRegionRepository.Remove(region);
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_ADD);
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<IQueryable<Region>> GetQueryAbleRegionAsync()
    {
        var result = _iRegionRepository.GetAll();
        await Task.CompletedTask;
        return result;
    }

    public Region GetRegionById(long id)
    {
        try
        {
            var region = _iRegionRepository.GetById(id);
            return region;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETID);
            return default;
        }
    }
}
