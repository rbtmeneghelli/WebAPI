namespace TestsWebAPI.Interface;

public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
{
    IQueryable<TEntity> GetAll(bool hasTracking = false);
    IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, bool hasTracking = false);
    TEntity GetById(long id);
    bool ExistAnyRecord();
    void Insert(TEntity entity);
    void Update(TEntity entity);
}
