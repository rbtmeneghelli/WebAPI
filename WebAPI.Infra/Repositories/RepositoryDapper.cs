﻿using Dapper;
using WebAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebAPI.Application.Generic;


namespace WebAPI.Infra.Data.Repositories
{
    public class GenericRepositoryDapper<TEntity> : IGenericRepositoryDapper<TEntity> where TEntity : class
    {
        protected readonly IDbConnection _idbConnection;

        public GenericRepositoryDapper(IDbConnection idbConnection)
        {
            _idbConnection = idbConnection;
        }

        public async Task<IEnumerable<TEntity>> QueryToGetAll(string sqlQuery)
        {
            var list = await _idbConnection.QueryAsync<TEntity>(sql: sqlQuery);
            return list;
        }

        public async Task<TEntity> QueryToGetFirstOrDefault(string sqlQuery)
        {
            TEntity entity = await _idbConnection.QueryFirstOrDefaultAsync<TEntity>(sql: sqlQuery);
            return entity;
        }

        public async Task<QueryResult<TEntity>> QueryMultiple(string sqlQuery)
        {
            var reader = await _idbConnection.QueryMultipleAsync(sql: sqlQuery);
            return new QueryResult<TEntity>
            {
                Count = reader.Read<int>().FirstOrDefault(),
                Result = reader.Read<TEntity>()
            };
        }

        public async Task ExecuteQuery(string sqlQuery)
        {
            await _idbConnection.ExecuteAsync(sql: sqlQuery);
        }

        public async Task ExecuteQueryParams(string sqlQuery, DynamicParameters parameters)
        {
            await _idbConnection.ExecuteAsync(sql: sqlQuery, param: parameters);
        }

        public void Dispose()
        {
            _idbConnection?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
