﻿using Dapper;
using WebAPI.Domain.Models;

namespace WebAPI.Application.Generic;

public interface IGenericRepositoryDapper<TEntity> : IDisposable where TEntity : class
{
    Task<IEnumerable<TEntity>> QueryToGetAll(string sqlQuery);
    Task<TEntity> QueryToGetFirstOrDefault(string sqlQuery);
    Task<QueryResult<TEntity>> QueryMultiple(string sqlQuery);
    Task ExecuteQuery(string sqlQuery);
    Task ExecuteQueryParams(string sqlQuery, DynamicParameters parameters);
}
