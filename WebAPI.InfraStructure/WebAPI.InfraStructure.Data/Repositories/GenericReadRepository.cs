using FastPackForShare.Bases.Generics;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.InfraStructure.Data.Context;

namespace WebAPI.InfraStructure.Data.Repositories;

public sealed class GenericReadRepository<TEntity> : IGenericReadRepository<TEntity> where TEntity : GenericEntityModel
{
    private readonly WebAPIContext _context;
    private readonly DbSet<TEntity> DbSet;

    public GenericReadRepository(WebAPIContext context)
    {
        _context = context;
        DbSet = _context.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll(bool hasTracking = false)
    {
        if (hasTracking)
            return DbSet;

        return DbSet.AsNoTracking();
    }

    public TEntity GetById(long id)
    {
        var result = DbSet.Find(id);
        _context.Entry(result).State = EntityState.Detached;
        return result;
    }

    public IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate, bool isTracking = false)
    {
        if (isTracking)
        {
            return DbSet.Where(predicate);
        }

        return DbSet.AsNoTracking().Where(predicate);
    }

    public bool Exist(Expression<Func<TEntity, bool>> predicate) => DbSet.AsNoTracking().Any(predicate);

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
            return DbSet.Include(includeData).AsSplitQuery();

        return DbSet.AsNoTrackingWithIdentityResolution().Include(includeData).AsSplitQuery();
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

    public long GetCount(Expression<Func<TEntity, bool>> predicate)
    {
        return DbSet.AsNoTracking().LongCount(predicate);
    }

    /// <summary>
    /// Utilizar esse metodo quando fazemos uma busca Por um Id especifico por exemplo, 
    /// e precisamos pegar uma propriedade da entidade relacionada a entidade principal
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="referenceName"></param>
    public void GetExplicitLoadingReference(ref TEntity entity, string referenceName)
    {
        DbSet.Entry(entity).Reference(referenceName).LoadAsync();
    }

    /// <summary>
    /// Utilizar esse metodo quando fazemos uma busca Por um Id especifico por exemplo, 
    /// e precisamos pegar uma entidade de coleção relacionada a entidade principal
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="collectionName"></param>
    public void GetExplicitLoadingCollection(ref TEntity entity, string collectionName)
    {
        DbSet.Entry(entity).Collection(collectionName).LoadAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
