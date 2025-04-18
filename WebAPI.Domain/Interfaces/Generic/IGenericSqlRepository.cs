namespace WebAPI.Domain.Interfaces.Generic;

public interface IGenericSqlRepository : IDisposable
{
    IEnumerable<dynamic> ExecuteDynamicSQL(string sql, Dictionary<string, object> parameters = null);
    T ExecuteStoredProcedure<T>(string procedureName = "[dbo].[FelizAnoNovo]") where T : class;
    IEnumerable<TModel> GetAllFromSqlQuery<TModel>(string query);
    bool ExecuteSql(string sql, params object[] parameters);
    bool ExecuteProcedureSql(string sql);
    string GetConnectionStringFromDatabase();
    Task<bool> ExceuteStoredProcedureAsync(string procName, string paramName, string paramValue);
    Task<bool> ExecuteSqlBackupAsync(string directory);
    void InsertLogError(string sql, string entity, string method, string messageError);
    string TransformIQueryAbleToSqlScript(IQueryable sql);
}
