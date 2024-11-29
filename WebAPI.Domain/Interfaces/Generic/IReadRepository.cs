using System.Linq.Expressions;

namespace WebAPI.Application.Generic;

public interface IReadRepository<TEntity> : IDisposable where TEntity : class
{
    IQueryable<TEntity> GetAll(bool hasTracking = false);
    IQueryable<TEntity> GetAllIgnoreQueryFilter(bool hasTracking = false);
    IQueryable<TEntity> GetAllInclude(string includeData, bool hasTracking = false);
    IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, bool hasTracking = false);
    IQueryable<TEntity> FindByIgnoreQueryFilter(Expression<Func<TEntity, bool>> predicate, bool hasTracking = false);
    TEntity GetById(long id);
    long GetCount(Expression<Func<TEntity, bool>> predicate);
    bool Exist(Expression<Func<TEntity, bool>> predicate);
}
