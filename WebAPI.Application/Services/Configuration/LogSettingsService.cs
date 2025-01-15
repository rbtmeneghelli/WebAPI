using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Configuration;

public class LogSettingsService : GenericService, ILogSettingsService
{
    private readonly ILogSettingsRepository _iLogSettingsRepository;
    private EnvironmentVariables _environmentVariables;
    private readonly IMapperService _iMapperService;

    public LogSettingsService(
        ILogSettingsRepository iLogSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables,
        IMapperService iMapperService)
        : base(iNotificationMessageService)
    {
        _iLogSettingsRepository = iLogSettingsRepository;
        _environmentVariables = environmentVariables;
        _iMapperService = iMapperService;
    }

    public async Task<IEnumerable<LogSettingsResponseDTO>> GetAllLogSettingsAsync()
    {
        try
        {
            return await (from p in _iLogSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                          orderby p.EnvironmentTypeSettings.Id ascending
                          select new LogSettingsResponseDTO()
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              SaveLogCreateData = p.SaveLogCreateData,
                              SaveLogDeleteData = p.SaveLogDeleteData,
                              SaveLogResearchData = p.SaveLogResearchData,
                              SaveLogTurnOffSystem = p.SaveLogTurnOffSystem,
                              SaveLogTurnOnSystem = p.SaveLogTurnOnSystem,
                              SaveLogUpdateData = p.SaveLogUpdateData,
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<LogSettingsResponseDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<LogSettingsResponseDTO> GetLogSettingsByEnvironmentAsync()
    {
        try
        {
            return await (from p in _iLogSettingsRepository.FindBy(x => x.IdEnvironmentType == (int)_environmentVariables.Environment).AsQueryable()
                          select new LogSettingsResponseDTO
                          {
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              SaveLogCreateData = p.SaveLogCreateData,
                              SaveLogDeleteData = p.SaveLogDeleteData,
                              SaveLogResearchData = p.SaveLogResearchData,
                              SaveLogTurnOffSystem = p.SaveLogTurnOffSystem,
                              SaveLogTurnOnSystem = p.SaveLogTurnOnSystem,
                              SaveLogUpdateData = p.SaveLogUpdateData,
                              StatusDescription = p.GetStatusDescription()
                          }).FirstOrDefaultAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETID);
            return default;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<LogSettingsResponseDTO> GetLogSettingsByIdAsync(long id)
    {
        try
        {
            return await (from p in _iLogSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                          select new LogSettingsResponseDTO
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              SaveLogCreateData = p.SaveLogCreateData,
                              SaveLogDeleteData = p.SaveLogDeleteData,
                              SaveLogResearchData = p.SaveLogResearchData,
                              SaveLogTurnOffSystem = p.SaveLogTurnOffSystem,
                              SaveLogTurnOnSystem = p.SaveLogTurnOnSystem,
                              SaveLogUpdateData = p.SaveLogUpdateData,
                              StatusDescription = p.GetStatusDescription()
                          }).FirstOrDefaultAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETID);
            return default;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> ExistLogSettingsByEnvironmentAsync()
    {
        var result = _iLogSettingsRepository.Exist(x => x.IdEnvironmentType == (int)_environmentVariables.Environment);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> ExistLogSettingsByIdAsync(long id)
    {
        var result = _iLogSettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateLogSettingsAsync(LogSettingsCreateRequestDTO logSettingsCreateRequestDTO)
    {
        try
        {
            LogSettings logSettings = _iMapperService.ApplyMapToEntity<LogSettingsCreateRequestDTO, LogSettings>(logSettingsCreateRequestDTO);
            _iLogSettingsRepository.Create(logSettings);
            return true;
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_ADD);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> UpdateLogSettingsAsync(LogSettingsUpdateRequestDTO logSettingsUpdateRequestDTO)
    {
        try
        {
            LogSettings logSettings = _iMapperService.ApplyMapToEntity<LogSettingsUpdateRequestDTO, LogSettings>(logSettingsUpdateRequestDTO);
            LogSettings logSettingsDb = _iLogSettingsRepository.GetById(logSettings.Id.Value);

            if (GuardClauses.ObjectIsNotNull(logSettingsDb))
            {
                if (logSettingsDb.Status)
                {
                    logSettingsDb.UpdateDate = logSettings.UpdateDate;
                    logSettingsDb.SaveLogCreateData = logSettings.SaveLogCreateData;
                    logSettingsDb.SaveLogDeleteData = logSettings.SaveLogDeleteData;
                    logSettingsDb.SaveLogResearchData = logSettings.SaveLogResearchData;
                    logSettingsDb.SaveLogTurnOffSystem = logSettings.SaveLogTurnOffSystem;
                    logSettingsDb.SaveLogTurnOnSystem = logSettings.SaveLogTurnOnSystem;
                    logSettingsDb.SaveLogUpdateData = logSettings.SaveLogUpdateData;
                    _iLogSettingsRepository.Update(logSettingsDb);
                    return true;
                }

                Notify(FixConstants.ERROR_IN_UPDATE);
                return false;
            }

            Notify(FixConstants.ERROR_IN_UPDATE);
            return false;
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_UPDATE);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> LogicDeleteLogSettingsByIdAsync(long id)
    {
        try
        {
            LogSettings logSettingsDb = _iLogSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(logSettingsDb))
            {
                logSettingsDb.UpdateDate = logSettingsDb.GetNewUpdateDate();
                logSettingsDb.Status = false;
                _iLogSettingsRepository.Update(logSettingsDb);
                return true;
            }
            else
            {
                Notify(FixConstants.ERROR_IN_DELETELOGIC);
                return false;
            }
        }
        catch (Exception)
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> ReactiveLogSettingsByIdAsync(long id)
    {
        try
        {
            LogSettings logSettingsDb = _iLogSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(logSettingsDb))
            {
                logSettingsDb.UpdateDate = logSettingsDb.GetNewUpdateDate();
                logSettingsDb.Status = true;
                _iLogSettingsRepository.Update(logSettingsDb);
                return true;
            }
            else
            {
                Notify(FixConstants.ERROR_IN_UPDATESTATUS);
                return false;
            }
        }
        catch (Exception)
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<IEnumerable<LogSettingsExcelDTO>> GetAllLogSettingsExcelAsync()
    {
        try
        {
            return await (from p in _iLogSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                          orderby p.EnvironmentTypeSettings.Id ascending
                          select new LogSettingsExcelDTO()
                          {
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              SaveLogCreateDataDescription = p.GetStatusDescription(),
                              SaveLogDeleteDataDescription = p.GetStatusDescription(),
                              SaveLogResearchDataDescription = p.GetStatusDescription(),
                              SaveLogTurnOffSystemDescription = p.GetStatusDescription(),
                              SaveLogTurnOnSystemDescription = p.GetStatusDescription(),
                              SaveLogUpdateDataDescription = p.GetStatusDescription(),
                              StatusDescriptionDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<LogSettingsExcelDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }
}
