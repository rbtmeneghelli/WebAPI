using Dapper;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Generic;


namespace WebAPI.Application.Services;

public sealed class AuditService : BaseHandlerService, IAuditService
{
    private readonly IAuditRepository _iAuditRepository;
    private readonly IGenericReadDapperRepository<Audit> _iAuditReadRepositoryDapper;
    private readonly IGenericWriteDapperRepository _iAuditWriteRepositoryDapper;
    private readonly IMapperService _iMapperService;

    public AuditService(
        IAuditRepository iAuditRepository,
        IGenericReadDapperRepository<Audit> iAuditReadRepositoryDapper,
        IGenericWriteDapperRepository iAuditWriteRepositoryDapper,
        INotificationMessageService iNotificationMessageService,
        IMapperService iMapperService) : base(iNotificationMessageService)
    {
        _iAuditRepository = iAuditRepository;
        _iAuditReadRepositoryDapper = iAuditReadRepositoryDapper;
        _iAuditWriteRepositoryDapper = iAuditWriteRepositoryDapper;
        _iMapperService = iMapperService;
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
        return p => GuardClauseExtension.IsNullOrWhiteSpace(filter.TableName) || p.TableName.StartsWith(filter.TableName.ApplyTrim());
    }

    public async Task<AuditResponseDTO> GetAuditByIdAsync(long id)
    {
        var data = await Task.FromResult(_iAuditRepository.GetById(id));
        return _iMapperService.MapEntityToDTO<Audit, AuditResponseDTO>(data);
    }

    public async Task<IEnumerable<Audit>> GetAllAuditWithLikeAsync(string parameter)
    {
        return await _iAuditRepository.FindBy(x => EF.Functions.Like(x.TableName, $"%{parameter}%")).ToListAsync();
    }

    public async Task<BasePagedResultModel<AuditResponseDTO>> GetAllDapperAsync(AuditFilter filter)
    {
        string sql = @"select count(*) from ControlPanel_Audit " +
        @"select Id = Id, TableName = Table_Name, ActionName = Action_Name from ControlPanel_Audit where (Table_Name = '" + filter.TableName + "')";
        var reader = await _iAuditReadRepositoryDapper.GetMultipleResult(sql);

        var queryResult = from x in reader.Result.AsQueryable()
                          orderby x.UpdatedAt descending
                          select new AuditResponseDTO()
                          {
                              Id = x.Id,
                              TableName = x.TableName,
                              ActionName = x.ActionName,
                              UpdateTime = x.UpdatedAt,
                              KeyValues = x.KeyValues,
                              OldValues = x.OldValues,
                              NewValues = x.NewValues
                          };

        return BasePagedResultService.GetPaged(queryResult, BasePagedResultService.GetDefaultPageIndex(filter.PageIndex), BasePagedResultService.GetDefaultPageSize(filter.PageSize));
    }

    public async Task<BasePagedResultModel<AuditResponseDTO>> GetAllAuditPaginateAsync(AuditFilter filter)
    {
        var query = await GetAllWithFilterAsync(filter);
        var queryCount = await GetCountAsync(filter);

        var queryResult = from x in query.AsQueryable()
                          orderby x.UpdatedAt descending
                          select new AuditResponseDTO()
                          {
                              Id = x.Id,
                              TableName = x.TableName,
                              ActionName = x.ActionName,
                              UpdateTime = x.UpdatedAt,
                              KeyValues = x.KeyValues,
                              OldValues = x.OldValues,
                              NewValues = x.NewValues
                          };

        return BasePagedResultService.GetPaged(queryResult, BasePagedResultService.GetDefaultPageIndex(filter.PageIndex), BasePagedResultService.GetDefaultPageSize(filter.PageSize));
    }

    public async Task<bool> ExistAuditByIdAsync(long id)
    {
        var result = _iAuditRepository.Exist(x => x.Id == id);

        if (result == false)
            Notify(FixConstants.ERROR_IN_GETID);

        return result;
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
        parameters.Add("@CreateDate", DateOnlyExtension.GetDateTimeNowFromBrazil(), dbType: DbType.DateTime2, direction: ParameterDirection.Input);
        parameters.Add("@Status", true, dbType: DbType.Boolean, direction: ParameterDirection.Input);

        await _iAuditWriteRepositoryDapper.ExecuteQueryParams(scriptSQL, parameters);
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
        parameters.Add("@UpdateDate", DateOnlyExtension.GetDateTimeNowFromBrazil(), dbType: DbType.DateTime2, direction: ParameterDirection.Input);
        parameters.Add("@Id", audit.Id);

        await _iAuditWriteRepositoryDapper.ExecuteQueryParams(scriptSQL, parameters);
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
            parameters.Add("@UpdateDate", DateOnlyExtension.GetDateTimeNowFromBrazil(), dbType: DbType.DateTime2, direction: ParameterDirection.Input);
            parameters.Add("@Id", audit.Id);

            await _iAuditWriteRepositoryDapper.ExecuteQueryParams(scriptSQLUpdate, parameters);
        }
        else
        {
            string scriptSQLDelete = $@"DELETE FROM ControlPanel_Audit WHERE Id = @Id";

            parameters.Add("@Id", audit.Id);

            await _iAuditWriteRepositoryDapper.ExecuteQueryParams(scriptSQLDelete, parameters);
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
        parameters.Add("@UpdateDate", DateOnlyExtension.GetDateTimeNowFromBrazil(), dbType: DbType.DateTime2, direction: ParameterDirection.Input);
        parameters.Add("@Id", audit.Id);

        await _iAuditWriteRepositoryDapper.ExecuteQueryParams(scriptSQLUpdate, parameters);
    }
}