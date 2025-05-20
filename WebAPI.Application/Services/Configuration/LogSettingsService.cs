using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;

namespace WebAPI.Application.Services.Configuration;

public sealed class LogSettingsService : BaseHandlerService, ILogSettingsService
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
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }

    public async Task<LogSettingsResponseDTO> GetLogSettingsByEnvironmentAsync()
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
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
    }

    public async Task<LogSettingsResponseDTO> GetLogSettingsByIdAsync(long id)
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
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
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
        LogSettings logSettings = _iMapperService.MapDTOToEntity<LogSettingsCreateRequestDTO, LogSettings>(logSettingsCreateRequestDTO);
        _iLogSettingsRepository.Create(logSettings);
        return true;
    }

    public async Task<bool> UpdateLogSettingsAsync(LogSettingsUpdateRequestDTO logSettingsUpdateRequestDTO)
    {
        LogSettings logSettings = _iMapperService.MapDTOToEntity<LogSettingsUpdateRequestDTO, LogSettings>(logSettingsUpdateRequestDTO);
        LogSettings logSettingsDb = _iLogSettingsRepository.GetById(logSettings.Id.Value);

        if (GuardClauseExtension.IsNotNull(logSettingsDb))
        {
            if (logSettingsDb.IsActive.Value)
            {
                logSettingsDb.UpdatedAt = logSettings.UpdatedAt;
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

    public async Task<bool> LogicDeleteLogSettingsByIdAsync(long id)
    {
        LogSettings logSettingsDb = _iLogSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(logSettingsDb))
        {
            logSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            logSettingsDb.IsActive = false;
            _iLogSettingsRepository.Update(logSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
    }

    public async Task<bool> ReactiveLogSettingsByIdAsync(long id)
    {
        LogSettings logSettingsDb = _iLogSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(logSettingsDb))
        {
            logSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            logSettingsDb.IsActive = true;
            _iLogSettingsRepository.Update(logSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
    }

    public async Task<IEnumerable<LogSettingsExcelDTO>> GetAllLogSettingsExcelAsync()
    {
        return await (from p in _iLogSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                      orderby p.EnvironmentTypeSettings.Id ascending
                      select new LogSettingsExcelDTO()
                      {
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          SaveLogCreateDataDescription = p.SaveLogCreateData.GetDescriptionByBoolean(),
                          SaveLogDeleteDataDescription = p.SaveLogDeleteData.GetDescriptionByBoolean(),
                          SaveLogResearchDataDescription = p.SaveLogResearchData.GetDescriptionByBoolean(),
                          SaveLogTurnOffSystemDescription = p.SaveLogTurnOffSystem.GetDescriptionByBoolean(),
                          SaveLogTurnOnSystemDescription = p.SaveLogTurnOnSystem.GetDescriptionByBoolean(),
                          SaveLogUpdateDataDescription = p.SaveLogUpdateData.GetDescriptionByBoolean(),
                          StatusDescriptionDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }
}
