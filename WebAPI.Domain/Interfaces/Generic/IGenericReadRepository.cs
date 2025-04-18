using System.Linq.Expressions;

namespace WebAPI.Domain.Interfaces.Generic;

public interface IGenericReadRepository<TEntity> : IDisposable where TEntity : class
{
    IQueryable<TEntity> GetAll(bool hasTracking = false);
    IQueryable<TEntity> GetAllIgnoreQueryFilter(bool hasTracking = false);
    IQueryable<TEntity> GetAllInclude(string includeData, bool hasTracking = false);
    IQueryable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate, bool hasTracking = false);
    IQueryable<TEntity> GetByPredicateIgnoreQueryFilter(Expression<Func<TEntity, bool>> predicate, bool hasTracking = false);
    TEntity GetById(long id);
    long GetCount(Expression<Func<TEntity, bool>> predicate);
    bool Exist(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate, bool isTracking = false);
}
