namespace WebAPI.Application.Generic
{
    public interface IGenericRepositoryDapper<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> QueryToGetAll(string sqlQuery);
        Task<TEntity> QueryToGetFirstOrDefault(string sqlQuery);
        Task<QueryResult<TEntity>> QueryMultiple(string sqlQuery);
        Task ExecuteQuery(string sqlQuery);
    }
}
