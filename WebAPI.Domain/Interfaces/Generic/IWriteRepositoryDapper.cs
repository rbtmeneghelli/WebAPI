using Dapper;

namespace WebAPI.Application.Generic;

public interface IWriteRepositoryDapper : IDisposable
{
    Task ExecuteQuery(string sqlQuery);
    Task ExecuteQueryParams(string sqlQuery, DynamicParameters parameters);
}
