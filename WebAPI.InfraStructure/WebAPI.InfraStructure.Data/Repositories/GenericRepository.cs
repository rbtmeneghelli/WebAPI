using Microsoft.EntityFrameworkCore;
using System.Data;
using WebAPI.Domain.Constants;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.InfraStructure.Data.Context;

namespace WebAPI.InfraStructure.Data.Repositories;

public abstract class GenericRepository<TEntity> where TEntity : class
{
    protected readonly WebAPIContext _context;
    protected readonly DbSet<TEntity> DbSet;

    public GenericRepository(WebAPIContext context)
    {
        _context = context;
        DbSet = _context.Set<TEntity>();
    }

    protected virtual string[] GetValuesFromEntity(IEnumerable<TEntity> entity)
    {
        return entity.GetType().GetProperties().Select(x => x.Name + ": " + x.GetValue(entity, null)).ToArray();
    }

    protected virtual string[] GetValuesFromEntity(TEntity entity)
    {
        return entity.GetType().GetProperties().Select(x => x.Name + ": " + x.GetValue(entity, null)).ToArray();
    }

    protected virtual void InsertLogError(string[] values, string entity, string method, string messageError)
    {
        _context.Database.ExecuteSqlRaw(string.Format(FixConstants.SAVE_LOG, entity, method, messageError, DateOnlyExtensionMethods.GetDateTimeNowFromBrazil().ToString("yyyy-MM-dd"), string.Join(",", values)));
    }

    protected virtual void InsertLogError(string sql, string entity, string method, string messageError)
    {
        _context.Database.ExecuteSqlRaw(string.Format(FixConstants.SAVE_LOG, entity, method, messageError, DateOnlyExtensionMethods.GetDateTimeNowFromBrazil().ToString("yyyy-MM-dd"), sql));
    }

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
