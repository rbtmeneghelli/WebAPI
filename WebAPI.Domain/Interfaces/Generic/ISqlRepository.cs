namespace WebAPI.Domain.Interfaces.Generic;

public interface ISqlRepository : IDisposable
{
    IEnumerable<dynamic> ExecuteDynamicSQL(string sql, Dictionary<string, object> parameters = null);
    void SetCommandTimeout(int timeout);
    T RunStoredProcedureWithReturn<T>(string procedureName = "[dbo].[FelizAnoNovo]") where T : class;
    IEnumerable<TModel> GetAllFromSqlQuery<TModel>(string query);
    bool ExecuteSql(string sql, params object[] parameters);
    bool ExecuteProcedureSql(string sql);
    string GetConnectionStringFromDatabase();
    Task<bool> RunSqlProcedureAsync(string procName, string paramName, string paramValue);
    Task<bool> RunSqlBackupAsync(string directory);
}
