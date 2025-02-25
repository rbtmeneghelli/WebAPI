using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.InfraStructure.Data.Context;

namespace WebAPI.InfraStructure.Data.Repositories;

public sealed class ReadRepository<TEntity> : GenericRepository<TEntity>, IReadRepository<TEntity> where TEntity : class
{
    public ReadRepository(WebAPIContext context) : base(context) { }

    public IQueryable<TEntity> GetAll(bool hasTracking = false)
    {
        if (hasTracking)
            return DbSet;

        return DbSet.AsNoTracking();
    }

    public IQueryable<TEntity> GetAllIgnoreQueryFilter(bool hasTracking = false)
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
    public IQueryable<TEntity> GetAllInclude(string includeData, bool hasTracking = false)
    {
        if (hasTracking)
            return DbSet.AsSplitQuery().Include(includeData);

        return DbSet.AsNoTracking().AsSplitQuery().Include(includeData);
    }

    public IQueryable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate, bool hasTracking = false)
    {
        if (hasTracking)
            return DbSet.Where(predicate);

        return DbSet.AsNoTracking().Where(predicate);
    }

    public IQueryable<TEntity> GetByPredicateIgnoreQueryFilter(Expression<Func<TEntity, bool>> predicate, bool hasTracking = false)
    {
        if (hasTracking)
            return DbSet.IgnoreQueryFilters().Where(predicate);

        return DbSet.AsNoTracking().IgnoreQueryFilters().Where(predicate);
    }

    public TEntity GetById(long id)
    {
        var result = DbSet.Find(id);
        _context.Entry(result).State = EntityState.Detached;
        return result;
    }

    public long GetCount(Expression<Func<TEntity, bool>> predicate)
    {
        return DbSet.AsNoTracking().LongCount(predicate);
    }

    public bool Exist(Expression<Func<TEntity, bool>> predicate) => DbSet.AsNoTracking().Any(predicate);
}
