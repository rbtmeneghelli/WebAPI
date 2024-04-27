using WebAPI.Application;
using WebAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace WebAPI.Infra.Data.Repositories
{
    public partial class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private string[] GetValuesFromEntity<TEntity>(IEnumerable<TEntity> entity)
        {
            return entity.GetType().GetProperties().Select(x => x.Name + ": " + x.GetValue(entity, null)).ToArray();
        }

        private string[] GetValuesFromEntity<TEntity>(TEntity entity)
        {
            return entity.GetType().GetProperties().Select(x => x.Name + ": " + x.GetValue(entity, null)).ToArray();
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

        private void SaveLogError(string[] values, string entity, string method, string messageError)
        {
            _context.Database.ExecuteSqlRaw(string.Format(FixConstants.SAVE_LOG, entity, method, messageError, FixConstants.GetDateTimeNowFromBrazil().ToString("yyyy-MM-dd"), string.Join(",", values)));
        }

        private void SaveLogErrorSql(string sql, string entity, string method, string messageError)
        {
            _context.Database.ExecuteSqlRaw(string.Format(FixConstants.SAVE_LOG, entity, method, messageError, FixConstants.GetDateTimeNowFromBrazil().ToString("yyyy-MM-dd"), sql));
        }
    }
}
