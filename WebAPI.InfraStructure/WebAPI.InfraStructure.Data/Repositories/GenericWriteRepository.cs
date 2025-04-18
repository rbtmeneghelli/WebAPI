using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.InfraStructure.Data.Context;
using WebAPI.Domain.Interfaces.Generic;
using FastPackForShare.Bases.Generics;

namespace WebAPI.InfraStructure.Data.Repositories;

public sealed class GenericWriteRepository<TEntity> : GenericRepository<TEntity>, IGenericWriteRepository<TEntity> where TEntity : GenericEntityModel
{
    public GenericWriteRepository(WebAPIContext context): base(context)
    {
    }

    public void Create(TEntity entity)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            DbSet.Add(entity);
            _context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            InsertLogError(GetValuesFromEntity(entity), entity.GetType().Name, "Create", ex.Message);
        }
    }

    public void CreateRange(IEnumerable<TEntity> entities)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            DbSet.AddRange(entities);
            _context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            InsertLogError(GetValuesFromEntity(entities), entities.GetType().Name, "CreateRange", ex.Message);
        }
    }

    /// <summary>
    /// Pacote >> EFCore.BulkExtensions ou Z.EntityFramework.Extensions.EFCore para inserir registros em massa
    /// </summary>
    /// <param name="entities"></param>
    public void BulkCreate(IEnumerable<TEntity> entities)
    {
        using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
        {
            try
            {
                DbSet<TEntity> dbSet = _context.Set<TEntity>();
                _context.BulkInsert(entities);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                InsertLogError(GetValuesFromEntity(entities), entities.GetType().Name, "BulkCreate", ex.Message);
            }
        }
    }

    public void Remove(TEntity entity)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            DbSet.Remove(entity);
            _context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            InsertLogError(GetValuesFromEntity(entity), entity.GetType().Name, "Remove", ex.Message);
        }
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            DbSet.RemoveRange(entities);
            _context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            InsertLogError(GetValuesFromEntity(entities), entities.GetType().Name, "RemoveRange", ex.Message);
        }
    }

    public void ExecuteDelete(Expression<Func<TEntity, bool>> predicate)
    {
        DbSet.Where(predicate).ExecuteDelete();
    }

    public void Update(TEntity entity)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            DbSet.Update(entity);
            _context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            InsertLogError(GetValuesFromEntity(entity), entity.GetType().Name, "Update", ex.Message);
        }
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            DbSet.UpdateRange(entities);
            _context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            InsertLogError(GetValuesFromEntity(entities), entities.GetType().Name, "UpdateRange", ex.Message);
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
