using Dapper;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Generic;

public interface IReadRepositoryDapper<TEntity> : IDisposable where TEntity : class
{
    Task<IEnumerable<TEntity>> QueryToGetAll(string sqlQuery);
    Task<TEntity> QueryToGetFirstOrDefault(string sqlQuery);
    Task<QueryResult<TEntity>> QueryMultiple(string sqlQuery);
}
