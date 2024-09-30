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

    public async Task<Audit> GetByIdAsync(long id)
    {
        return await Task.FromResult(_iAuditRepository.GetById(id));
    }

    public async Task<IEnumerable<Audit>> GetAllWithLikeAsync(string parameter)
    {
        return await _iAuditRepository.FindBy(x => EF.Functions.Like(x.TableName, $"%{parameter}%")).ToListAsync();
    }

    public async Task<PagedResult<AuditResponseDTO>> GetAllDapperAsync(AuditFilter filter)
    {
        string sql = @"select count(*) from audits " +
        @"select Id = Id, TableName = Table_Name, ActionName = Action_Name from audits where (Table_Name = '" + filter.TableName + "')";
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

    public async Task<PagedResult<AuditResponseDTO>> GetAllPaginateAsync(AuditFilter filter)
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

    public async Task<bool> ExistByIdAsync(long id)
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
}