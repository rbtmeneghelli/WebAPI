namespace WebAPI.Application;

public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
{
    IQueryable<TEntity> GetAll(bool hasTracking = false);
    IQueryable<TEntity> GetAllIgnoreQueryFilter(bool hasTracking = false);
    IQueryable<TEntity> GetAllInclude(string includeData, bool hasTracking = false);
    IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, bool hasTracking = false);
    IQueryable<TEntity> FindByIgnoreQueryFilter(Expression<Func<TEntity, bool>> predicate, bool hasTracking = false);
    TEntity GetById(long id);
    long GetCount(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    long SaveChanges();
    bool ExecuteSql(string sql, params object[] parameters);
    IEnumerable<dynamic> ExecuteDynamicSQL(string sql, Dictionary<string, object> parameters = null);
    void SetCommandTimeout(int timeout);
    bool ExecuteProcedureSql(string sql);
    bool Exist(Expression<Func<TEntity, bool>> predicate);
    void BulkInsert(IEnumerable<TEntity> entities);
    void ExecuteDelete(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// EF Core -  Múltiplos Requests p/ um DataBase em uma Transação
    /// Referencia >> https://macoratti.net/22/11/efcore_multireqdb1.htm
    /// </summary>
    /// <param name="entity"></param>
    void AddTransaction(TEntity entity);
    IEnumerable<TModel> GetAllFromSqlQuery<TModel>(string query);
}
