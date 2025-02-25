using Dapper;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Generic;

public interface IReadRepositoryDapper<TEntity> : IDisposable where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll(string sqlQuery);
    Task<TEntity> GetFirstResult(string sqlQuery);
    Task<QueryResult<TEntity>> GetMultipleResult(string sqlQuery);
}
