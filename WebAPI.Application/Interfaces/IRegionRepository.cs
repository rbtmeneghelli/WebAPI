namespace WebAPI.Application.Interfaces;

public interface IRegionRepository
{
    IQueryable<Region> GetAll(bool hasTracking = false);
    Region GetById(long id);
    IQueryable<Region> FindBy(Expression<Func<Region, bool>> predicate, bool hasTracking = false);
    bool Exist(Expression<Func<Region, bool>> predicate);
    void Add(Region region);
    void Remove(Region region);
    void Update(Region region);
    void AddRange(IEnumerable<Region> regions);
    long GetCount(Expression<Func<Region, bool>> predicate);
}
