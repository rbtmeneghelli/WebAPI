using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Domain.Entities.Others;
using WebAPI.InfraStructure.Data.Context;
using WebAPI.Domain.Interfaces.Generic;

namespace WebAPI.InfraStructure.Data.Repositories;

public sealed class WriteRepository<TEntity> : GenericRepository<TEntity>, IWriteRepository<TEntity> where TEntity : class
{
    public WriteRepository(WebAPIContext context) : base(context) { }

    public void Create(TEntity entity)
    {
        try
        {
            DbSet.Add(entity);
            SaveChanges();
        }
        catch (Exception ex)
        {
            InsertLogError(GetValuesFromEntity(entity), entity.GetType().Name, "Create", ex.Message);
        }
    }

    /// <summary>
    /// Pacote >> EFCore.BulkExtensions ou Z.EntityFramework.Extensions.EFCore para inserir registros em massa
    /// </summary>
    /// <param name="entities"></param>
    public void BulkCreate(IEnumerable<TEntity> entities)
    {
        try
        {
            _context.BulkInsert(entities);
        }
        catch (Exception ex)
        {
            InsertLogError(GetValuesFromEntity(entities), entities.GetType().Name, "BulkCreate", ex.Message);
        }
    }

    public void Update(TEntity entity)
    {
        try
        {
            DbSet.Update(entity);
            SaveChanges();
        }
        catch (Exception ex)
        {
            InsertLogError(GetValuesFromEntity(entity), entity.GetType().Name, "Update", ex.Message);
        }
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        try
        {
            DbSet.UpdateRange(entities);
            SaveChanges();
        }
        catch (Exception ex)
        {
            InsertLogError(GetValuesFromEntity(entities), entities.GetType().Name, "UpdateRange", ex.Message);
        }
    }

    public void Remove(TEntity entity)
    {
        try
        {
            DbSet.Remove(entity);
            SaveChanges();
        }
        catch (Exception ex)
        {
            InsertLogError(GetValuesFromEntity(entity), entity.GetType().Name, "Remove", ex.Message);
        }
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        try
        {
            DbSet.RemoveRange(entities);
            SaveChanges();
        }
        catch (Exception ex)
        {
            InsertLogError(GetValuesFromEntity(entities), entities.GetType().Name, "RemoveRange", ex.Message);
        }
    }

    public void ExecuteDelete(Expression<Func<TEntity, bool>> predicate)
    {
        DbSet.Where(predicate).ExecuteDelete();
    }

    public long SaveChanges()
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
                InsertLogError(values, entry.Metadata.GetTableName(), "SaveChanges", ex.Message);
            }
            throw new Exception(ex.Message, ex.InnerException);
        }
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
                InsertLogError(GetValuesFromEntity(entity), entity.GetType().Name, "AddTransaction", ex.Message);
            }
        }
    }
}
