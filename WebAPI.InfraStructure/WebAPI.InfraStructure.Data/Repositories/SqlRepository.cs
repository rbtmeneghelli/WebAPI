﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebAPI.Domain;
using WebAPI.Domain.Constants;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.InfraStructure.Data.Context;

namespace WebAPI.InfraStructure.Data.Repositories;

public sealed class SqlRepository : ISqlRepository
{
    private readonly WebAPIContext _context;

    public SqlRepository(WebAPIContext context)
    {
        _context = context;
    }

    public IEnumerable<dynamic> ExecuteDynamicSQL(string sql, Dictionary<string, object> parameters = null)
    {
        IEnumerable<dynamic> list = Enumerable.Empty<dynamic>();

        try
        {
            if (GuardClauses.ObjectIsNull(parameters))
                parameters = new Dictionary<string, object>();

            list = _context.CollectionFromSql(sql, parameters);
        }
        catch (Exception ex)
        {
            InsertLogError(sql, "Script", "ExecuteDynamicSQL", ex.Message);
        }

        return list;
    }

    public void SetCommandTimeout(int timeout)
    {
        _context.Database.SetCommandTimeout(timeout);
    }

    public T ExecuteStoredProcedure<T>(string procedureName = "[dbo].[FelizAnoNovo]") where T : class
    {
        var parameterReturn = new SqlParameter
        {
            ParameterName = "ReturnValue",
            SqlDbType = GetSqlDbType(typeof(T)),
            Direction = System.Data.ParameterDirection.Output,
        };

        try
        {
            var result = _context.Database.ExecuteSqlRaw($"EXEC @returnValue = {procedureName}", parameterReturn);
            var returnValue = (T)parameterReturn.Value;
            return returnValue;
        }

        catch (Exception ex)
        {
            InsertLogError(procedureName, "Script", "RunStoredProcedureWithReturn", ex.Message);
        }

        return null;
    }

    /// <summary>
    /// Comando valido a partir do NET 8
    /// A forma antiga de uso era assim >> _context.{Tabela}.FromSql({query});
    /// </summary>
    /// <typeparam name="TModel">Não utilizar entidades mapeadas no DBSET</typeparam>
    /// <param name="query"></param>
    /// <returns></returns>
    public IEnumerable<TModel> GetAllFromSqlQuery<TModel>(string query)
    {
        var queryResult = _context.Database.SqlQuery<TModel>($@"{query}");
        return queryResult.AsEnumerable();
    }

    public bool ExecuteSql(string sql, params object[] parameters)
    {
        int countRowsAffected = 0;

        try
        {
            countRowsAffected = _context.Database.ExecuteSqlRaw(sql, parameters);
        }
        catch (Exception ex)
        {
            InsertLogError(sql, "Script", "ExecuteSql", ex.Message);
        }

        return countRowsAffected > 0 ? true : false;
    }

    public bool ExecuteProcedureSql(string sql)
    {
        int count = 0;
        try
        {
            count = _context.Database.ExecuteSqlRaw(sql);
        }
        catch (Exception ex)
        {
            InsertLogError(sql, "Script", "ExecuteProcedureSql", ex.Message);
        }
        return count > 0 ? true : false;
    }

    public string GetConnectionStringFromDatabase()
    {
        return _context.Database.GetConnectionString();
    }

    public async Task<bool> ExceuteStoredProcedureAsync(string procName, string paramName, string paramValue)
    {
        SqlConnection sqlConnObj = new SqlConnection(GetConnectionStringFromDatabase());

        try
        {
            SqlCommand sqlCmd = new SqlCommand(procName, sqlConnObj);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue(paramName, paramValue);
            sqlConnObj.Open();
            await sqlCmd.ExecuteNonQueryAsync();
        }
        catch(Exception ex)
        {
            InsertLogError(procName, "Script", "ExecuteProcedureSql", ex.Message);
            return false;
        }
        finally
        {
            sqlConnObj.Close();
        }

        return true;
    }

    public async Task<bool> ExecuteSqlBackupAsync(string directory)
    {
        string dir = GuardClauses.IsNullOrWhiteSpace(directory) ? Directory.GetCurrentDirectory() : directory;
        SqlConnection sqlConnObj = new SqlConnection(GetConnectionStringFromDatabase());

        try
        {
            string nomeArquivo = $"DefaultAPI_{GuidExtensionMethod.GetGuidDigits("N")}.bak";
            if (File.Exists(Path.Combine(dir, nomeArquivo)))
            {
                File.Delete(Path.Combine(dir, nomeArquivo));
            }
            string query = $"Backup database {sqlConnObj.Database} to disk='{dir}\\{nomeArquivo}'";
            SqlCommand sqlCmd = new SqlCommand(query, sqlConnObj);
            sqlConnObj.Open();
            await sqlCmd.ExecuteNonQueryAsync();
        }
        catch
        {
            InsertLogError("Backup", "Script", "ExecuteBackup", FixConstants.ERROR_IN_BACKUP);
            return false;
        }
        finally
        {
            sqlConnObj.Close();
        }

        return true;
    }

    private SqlDbType GetSqlDbType(Type type)
    {
        Dictionary<Type, SqlDbType> dictionary = new Dictionary<Type, SqlDbType>
        {
            { typeof(int), SqlDbType.Int },
            { typeof(string), SqlDbType.VarChar },
            { typeof(DateTime), SqlDbType.DateTime }
        };
        return dictionary[type];
    }

    public void InsertLogError(string sql, string entity, string method, string messageError)
    {
        _context.Database.ExecuteSqlRaw(string.Format(FixConstants.SAVE_LOG, entity, method, messageError, DateOnlyExtensionMethods.GetDateTimeNowFromBrazil().ToString("yyyy-MM-dd"), sql));
    }

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
