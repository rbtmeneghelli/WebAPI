using Dapper;

namespace WebAPI.Application.Generic;

public interface IGenericWriteDapperRepository : IDisposable
{
    Task ExecuteQuery(string sqlQuery);
    Task ExecuteQueryParams(string sqlQuery, DynamicParameters parameters);
}
