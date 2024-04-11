namespace WebAPI.Application.Interfaces
{
    public interface ICityRepository : IDisposable
    {
        IQueryable<City> GetAll(bool hasTracking = false);
        IQueryable<City> FindBy(Expression<Func<City, bool>> predicate, bool hasTracking = false);
        void Add(City city);
        void Update(City city);
        City GetById(long id);
        bool Exist(Expression<Func<City, bool>> predicate);
        void Remove(City city);
        void ExecuteUpdate(City city);
    }
}
