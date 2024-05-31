using WebAPI.Application;
using WebAPI.Domain;
using WebAPI.Domain.Entities;
using WebAPI.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SkiaSharp;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace WebAPI.Infra.Data.Repositories;

public partial class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly WebAPIContext _context;
    private readonly DbSet<TEntity> DbSet;

    public GenericRepository(WebAPIContext context)
    {
        _context = context;
        DbSet = _context.Set<TEntity>();
    }

    public virtual IQueryable<TEntity> GetAll(bool hasTracking = false)
    {
        if (hasTracking)
            return DbSet;

        return DbSet.AsNoTracking();
    }

    public virtual IQueryable<TEntity> GetAllIgnoreQueryFilter(bool hasTracking = false)
    {
        if (hasTracking)
            return DbSet.IgnoreQueryFilters();

        return DbSet.AsNoTracking().IgnoreQueryFilters();
    }

    /// <summary>
    /// O comando AsSplitQuery é util para queries 1..N, fazendo otimizar a query para melhor desempenho quando não possui filtro ou muitos registros...
    /// Sendo assim, com esse comando evitamos a explosão cartesiana
    /// </summary>
    /// <param name="includeData"></param>
    /// <param name="hasTracking"></param>
    /// <returns></returns>
    public virtual IQueryable<TEntity> GetAllInclude(string includeData, bool hasTracking = false)
    {
        if (hasTracking)
            return DbSet.AsSplitQuery().Include(includeData);

        return DbSet.AsNoTracking().AsSplitQuery().Include(includeData);
    }

    public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, bool hasTracking = false)
    {
        if (hasTracking)
            return DbSet.Where(predicate);

        return DbSet.AsNoTracking().Where(predicate);
    }

    public virtual IQueryable<TEntity> FindByIgnoreQueryFilter(Expression<Func<TEntity, bool>> predicate, bool hasTracking = false)
    {
        if (hasTracking)
            return DbSet.IgnoreQueryFilters().Where(predicate);

        return DbSet.AsNoTracking().IgnoreQueryFilters().Where(predicate);
    }

    public virtual TEntity GetById(long id)
    {
        var result = DbSet.Find(id);
        _context.Entry(result).State = EntityState.Detached;
        return result;
    }

    public virtual long GetCount(Expression<Func<TEntity, bool>> predicate)
    {
        return DbSet.AsNoTracking().LongCount(predicate);
    }

    public virtual void Add(TEntity entity)
    {
        try
        {
            DbSet.Add(entity);
            SaveChanges();
        }
        catch (Exception ex)
        {
            SaveLogError(GetValuesFromEntity(entity), entity.GetType().Name, "Add", ex.Message);
        }
    }

    public virtual void AddRange(IEnumerable<TEntity> entities)
    {
        try
        {
            DbSet.AddRange(entities);
            SaveChanges();
        }
        catch (Exception ex)
        {
            SaveLogError(GetValuesFromEntity(entities), entities.GetType().Name, "AddRange", ex.Message);
        }
    }

    public virtual void Update(TEntity entity)
    {
        try
        {
            DbSet.Update(entity);
            SaveChanges();
        }
        catch (Exception ex)
        {
            SaveLogError(GetValuesFromEntity(entity), entity.GetType().Name, "Update", ex.Message);
        }
    }

    public virtual void UpdateRange(IEnumerable<TEntity> entities)
    {
        try
        {
            DbSet.UpdateRange(entities);
            SaveChanges();
        }
        catch (Exception ex)
        {
            SaveLogError(GetValuesFromEntity(entities), entities.GetType().Name, "UpdateRange", ex.Message);
        }
    }

    public virtual void Remove(TEntity entity)
    {
        try
        {
            DbSet.Remove(entity);
            SaveChanges();
        }
        catch (Exception ex)
        {
            SaveLogError(GetValuesFromEntity(entity), entity.GetType().Name, "Remove", ex.Message);
        }
    }

    public virtual void RemoveRange(IEnumerable<TEntity> entities)
    {
        try
        {
            DbSet.RemoveRange(entities);
            SaveChanges();
        }
        catch (Exception ex)
        {
            SaveLogError(GetValuesFromEntity(entities), entities.GetType().Name, "RemoveRange", ex.Message);
        }

    }

    public virtual long SaveChanges()
    {
        try
        {
            return _context.SaveChanges();
        }
        catch (Exception ex)
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                string[] values = entry.Entity.GetType().GetProperties().Select(x => x.Name + ": " + x.GetValue(entry.Entity, null)).ToArray();
                SaveLogError(values, entry.Metadata.GetTableName(), "SaveChanges", ex.Message);
            }
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public virtual IEnumerable<dynamic> ExecuteDynamicSQL(string sql, Dictionary<string, object> parameters = null)
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
            SaveLogErrorSql(sql, "Script", "ExecuteDynamicSQL", ex.Message);
        }

        return list;
    }

    public virtual void SetCommandTimeout(int timeout)
    {
        _context.Database.SetCommandTimeout(timeout);
    }

    public virtual bool Exist(Expression<Func<TEntity, bool>> predicate) => DbSet.AsNoTracking().Any(predicate);

    public virtual T RunStoredProcedureWithReturn<T>(string procedureName = "[dbo].[FelizAnoNovo]") where T : class
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
            SaveLogErrorSql(procedureName, "Script", "RunStoredProcedureWithReturn", ex.Message);
        }

        return null;
    }

    public void BulkInsert(IEnumerable<TEntity> entities)
    {
        _context.BulkInsert(entities);
    }

    public void ExecuteDelete(Expression<Func<TEntity, bool>> predicate)
    {
        DbSet.Where(predicate).ExecuteDelete();
    }

    /// <summary>
    /// EF Core -  Múltiplos Requests p/ um DataBase em uma Transação
    /// Referencia >> https://macoratti.net/22/11/efcore_multireqdb1.htm
    /// </summary>
    /// <param name="entity"></param>
    public void AddTransaction(TEntity entity)
    {
        using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
        {
            try
            {
                DbSet<TEntity> dbSet = _context.Set<TEntity>();
                dbSet.Add(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                SaveLogError(GetValuesFromEntity(entity), entity.GetType().Name, "AddTransaction", ex.Message);
            }
        }
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

    public virtual bool ExecuteSql(string sql, params object[] parameters)
    {
        int countRowsAffected = 0;

        try
        {
            countRowsAffected = _context.Database.ExecuteSqlRaw(sql, parameters);
        }
        catch (Exception ex)
        {
            SaveLogErrorSql(sql, "Script", "ExecuteSql", ex.Message);
        }

        return countRowsAffected > 0 ? true : false;
    }

    public virtual bool ExecuteProcedureSql(string sql)
    {
        int count = 0;
        try
        {
            count = _context.Database.ExecuteSqlRaw(sql);
        }
        catch (Exception ex)
        {
            SaveLogErrorSql(sql, "Script", "ExecuteProcedureSql", ex.Message);
        }
        return count > 0 ? true : false;
    }

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
