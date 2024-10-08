using Dapper;
using WebAPI.Application.Factory;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.EntitiesDTO.Others;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Tools;


namespace WebAPI.Application.Services;

public class AuditService : GenericService, IAuditService
{
    private readonly IAuditRepository _iAuditRepository;
    private readonly IGenericRepositoryDapper<Audit> _iAuditRepositoryDapper;

    public AuditService(IAuditRepository iAuditRepository, IGenericRepositoryDapper<Audit> iAuditRepositoryDapper, INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
    {
        _iAuditRepository = iAuditRepository;
        _iAuditRepositoryDapper = iAuditRepositoryDapper;
    }

    private async Task<IQueryable<Audit>> GetAllWithFilterAsync(AuditFilter filter)
    {
        return await Task.FromResult(_iAuditRepository.GetAll().Where(GetPredicate(filter)).AsQueryable());
    }

    private async Task<int> GetCountAsync(AuditFilter filter)
    {
        return await _iAuditRepository.GetAll().CountAsync(GetPredicate(filter));
    }

    private Expression<Func<Audit, bool>> GetPredicate(AuditFilter filter)
    {
        return p => GuardClauses.IsNullOrWhiteSpace(filter.TableName) || p.TableName.StartsWith(filter.TableName.ApplyTrim());
    }

    public async Task<Audit> GetAuditByIdAsync(long id)
    {
        return await Task.FromResult(_iAuditRepository.GetById(id));
    }

    public async Task<IEnumerable<Audit>> GetAllAuditWithLikeAsync(string parameter)
    {
        return await _iAuditRepository.FindBy(x => EF.Functions.Like(x.TableName, $"%{parameter}%")).ToListAsync();
    }

    public async Task<PagedResult<AuditResponseDTO>> GetAllDapperAsync(AuditFilter filter)
    {
        string sql = @"select count(*) from ControlPanel_Audit " +
        @"select Id = Id, TableName = Table_Name, ActionName = Action_Name from ControlPanel_Audit where (Table_Name = '" + filter.TableName + "')";
        var reader = await _iAuditRepositoryDapper.QueryMultiple(sql);

        var queryResult = from x in reader.Result.AsQueryable()
                          orderby x.UpdateDate descending
                          select new AuditResponseDTO()
                          {
                              Id = x.Id,
                              TableName = x.TableName,
                              ActionName = x.ActionName,
                              UpdateTime = x.UpdateDate,
                              KeyValues = x.KeyValues,
                              OldValues = x.OldValues,
                              NewValues = x.NewValues
                          };

        return PagedFactory.GetPaged(queryResult, PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
    }

    public async Task<PagedResult<AuditResponseDTO>> GetAllAuditPaginateAsync(AuditFilter filter)
    {
        try
        {
            var query = await GetAllWithFilterAsync(filter);
            var queryCount = await GetCountAsync(filter);

            var queryResult = from x in query.AsQueryable()
                              orderby x.UpdateDate descending
                              select new AuditResponseDTO()
                              {
                                  Id = x.Id,
                                  TableName = x.TableName,
                                  ActionName = x.ActionName,
                                  UpdateTime = x.UpdateDate,
                                  KeyValues = x.KeyValues,
                                  OldValues = x.OldValues,
                                  NewValues = x.NewValues
                              };

            return PagedFactory.GetPaged(queryResult, PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return PagedFactory.GetPaged(Enumerable.Empty<AuditResponseDTO>().AsQueryable(), PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
        }
    }

    public async Task<bool> ExistAuditByIdAsync(long id)
    {
        try
        {
            var result = _iAuditRepository.Exist(x => x.Id == id);

            if (result == false)
                Notify(FixConstants.ERROR_IN_GETID);

            return result;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETID);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task CreateAuditBySQLScript(Audit audit)
    {
        var scriptSQL = SqlExtensionMethod.CreateSQLInsertScript(audit, typeof(Audit));
        await _iAuditRepositoryDapper.ExecuteQuery(scriptSQL);
    }

    /// <summary>
    /// O DbType do Tipo AnsiString é para ser aplicado, quando o campo for Criptografado
    /// </summary>
    /// <param name="audit"></param>
    /// <returns></returns>
    public async Task CreateAuditByDapper(Audit audit)
    {
        string scriptSQL = $@"INSERT INTO ControlPanel_Audit(TableName,ActionName,KeyValues,OldValues,NewValues, CreateDate, Status)
                              VALUES(@TableName,@ActionName,@KeyValues,@OldValues,@NewValues, @CreateDate, @Status)";

        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("@TableName", audit.TableName, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
        parameters.Add("@ActionName", audit.ActionName, dbType: DbType.String, direction: ParameterDirection.Input, size: 80);
        parameters.Add("@KeyValues", audit.KeyValues, dbType: DbType.DateTime, direction: ParameterDirection.Input, size: 10000);
        parameters.Add("@OldValues", audit.OldValues, dbType: DbType.String, direction: ParameterDirection.Input, size: 10000);
        parameters.Add("@NewValues", audit.NewValues, dbType: DbType.String, direction: ParameterDirection.Input, size: 10000);
        parameters.Add("@CreateDate", DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), dbType: DbType.DateTime2, direction: ParameterDirection.Input);
        parameters.Add("@Status", true, dbType: DbType.Boolean, direction: ParameterDirection.Input);

        await _iAuditRepositoryDapper.ExecuteQueryParams(scriptSQL, parameters);
    }

    public async Task UpdateAuditByDapper(Audit audit)
    {
        string scriptSQL = $@"UPDATE ControlPanel_Audit SET 
                              TableName = COALESCE(@TableName,TableName)
                              ActionName = COALESCE(@ActionName,ActionName)
                              KeyValues = COALESCE(@KeyValues,KeyValues)
                              OldValues = COALESCE(@OldValues,OldValues)
                              NewValues = COALESCE(@NewValues,NewValues)
                              UpdateDate = @UpdateDate
                              WHERE Id = @Id";

        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("@TableName", audit.TableName, DbType.String, ParameterDirection.Input, size: 100);
        parameters.Add("@ActionName", audit.ActionName, DbType.String, ParameterDirection.Input, size: 80);
        parameters.Add("@KeyValues", audit.KeyValues, dbType: DbType.DateTime, direction: ParameterDirection.Input, size: 10000);
        parameters.Add("@OldValues", audit.OldValues, dbType: DbType.String, direction: ParameterDirection.Input, size: 10000);
        parameters.Add("@NewValues", audit.NewValues, dbType: DbType.String, direction: ParameterDirection.Input, size: 10000);
        parameters.Add("@UpdateDate", DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), dbType: DbType.DateTime2, direction: ParameterDirection.Input);
        parameters.Add("@Id", audit.Id);

        await _iAuditRepositoryDapper.ExecuteQueryParams(scriptSQL, parameters);
    }

    public async Task DeleteAuditByDapper(Audit audit, bool isLogicDelete = true)
    {
        DynamicParameters parameters = new DynamicParameters();

        if (isLogicDelete)
        {
            string scriptSQLUpdate = $@"UPDATE ControlPanel_Audit SET 
                                    Status = @Status,
                                    UpdateDate = @UpdateDate
                                    WHERE Id = @Id";

            parameters.Add("@Status", false, dbType: DbType.Boolean, direction: ParameterDirection.Input);
            parameters.Add("@UpdateDate", DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), dbType: DbType.DateTime2, direction: ParameterDirection.Input);
            parameters.Add("@Id", audit.Id);

            await _iAuditRepositoryDapper.ExecuteQueryParams(scriptSQLUpdate, parameters);
        }
        else
        {
            string scriptSQLDelete = $@"DELETE FROM ControlPanel_Audit WHERE Id = @Id";

            parameters.Add("@Id", audit.Id);

            await _iAuditRepositoryDapper.ExecuteQueryParams(scriptSQLDelete, parameters);
        }
    }

    public async Task ReactiveAuditByDapper(Audit audit)
    {
        DynamicParameters parameters = new DynamicParameters();

        string scriptSQLUpdate = $@"UPDATE ControlPanel_Audit SET 
                                    Status = @Status,
                                    UpdateDate = @UpdateDate
                                    WHERE Id = @Id";

        parameters.Add("@Status", true, dbType: DbType.Boolean, direction: ParameterDirection.Input);
        parameters.Add("@UpdateDate", DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), dbType: DbType.DateTime2, direction: ParameterDirection.Input);
        parameters.Add("@Id", audit.Id);

        await _iAuditRepositoryDapper.ExecuteQueryParams(scriptSQLUpdate, parameters);
    }
}