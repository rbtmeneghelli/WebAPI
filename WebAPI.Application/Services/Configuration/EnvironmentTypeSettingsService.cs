using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;

namespace WebAPI.Application.Services.Configuration;

public sealed class EnvironmentTypeSettingsService : BaseHandlerService, IEnvironmentTypeSettingsService
{
    private readonly IEnvironmentTypeSettingsRepository _iEnvironmentTypeSettingsRepository;
    private readonly IMapperService _iMapperService;

    public EnvironmentTypeSettingsService(
        IEnvironmentTypeSettingsRepository iEnvironmentTypeSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables,
        IMapperService iMapperService)
        : base(iNotificationMessageService)
    {
        _iEnvironmentTypeSettingsRepository = iEnvironmentTypeSettingsRepository;
        _iMapperService = iMapperService;
    }

    public async Task<IEnumerable<EnvironmentTypeSettingsResponseDTO>> GetAllEnvironmentTypeSettingsAsync()
    {
        var data = await (from p in _iEnvironmentTypeSettingsRepository.GetAll()
                          orderby p.Id ascending
                          select p).ToListAsync();

        return _iMapperService.ApplyMapToEntity<IEnumerable<EnvironmentTypeSettings>, IEnumerable<EnvironmentTypeSettingsResponseDTO>>(data);
    }

    public async Task<EnvironmentTypeSettingsResponseDTO> GetEnvironmentTypeSettingsByIdAsync(long id)
    {
        var data = await (from p in _iEnvironmentTypeSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                          select p).FirstOrDefaultAsync();

        return _iMapperService.ApplyMapToEntity<EnvironmentTypeSettings, EnvironmentTypeSettingsResponseDTO>(data);
    }

    public async Task<bool> ExistEnvironmentTypeSettingsByIdAsync(long id)
    {
        var result = _iEnvironmentTypeSettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateEnvironmentTypeSettingsAsync(EnvironmentTypeSettingsCreateRequestDTO environmentTypeSettingsCreateRequestDTO)
    {
        EnvironmentTypeSettings environmentTypeSettings = _iMapperService.ApplyMapToEntity<EnvironmentTypeSettingsCreateRequestDTO, EnvironmentTypeSettings>(environmentTypeSettingsCreateRequestDTO);
        _iEnvironmentTypeSettingsRepository.Create(environmentTypeSettings);
        return true;
    }

    public async Task<bool> UpdateEnvironmentTypeSettingsAsync(EnvironmentTypeSettingsUpdateRequestDTO environmentTypeSettingsUpdateRequestDTO)
    {
        EnvironmentTypeSettings environmentTypeSettings = _iMapperService.ApplyMapToEntity<EnvironmentTypeSettingsUpdateRequestDTO, EnvironmentTypeSettings>(environmentTypeSettingsUpdateRequestDTO);
        EnvironmentTypeSettings environmentTypeSettingsDb = _iEnvironmentTypeSettingsRepository.GetById(environmentTypeSettings.Id.Value);

        if (GuardClauseExtension.IsNotNull(environmentTypeSettingsDb))
        {
            if (environmentTypeSettingsDb.IsActive.Value)
            {
                environmentTypeSettingsDb.UpdatedAt = environmentTypeSettings.UpdatedAt;
                environmentTypeSettingsDb.Description = environmentTypeSettings.Description;
                environmentTypeSettingsDb.Initials = environmentTypeSettings.Initials;
                _iEnvironmentTypeSettingsRepository.Update(environmentTypeSettingsDb);
                return true;
            }

            Notify(FixConstants.ERROR_IN_UPDATE);
            return false;
        }

        Notify(FixConstants.ERROR_IN_UPDATE);
        return false;
    }

    public async Task<bool> LogicDeleteEnvironmentTypeSettingsByIdAsync(long id)
    {
        EnvironmentTypeSettings environmentTypeSettingsDb = _iEnvironmentTypeSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(environmentTypeSettingsDb))
        {
            environmentTypeSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            environmentTypeSettingsDb.IsActive = false;
            _iEnvironmentTypeSettingsRepository.Update(environmentTypeSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
    }

    public async Task<bool> ReactiveEnvironmentTypeSettingsByIdAsync(long id)
    {
        EnvironmentTypeSettings environmentTypeSettingsDb = _iEnvironmentTypeSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(environmentTypeSettingsDb))
        {
            environmentTypeSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            environmentTypeSettingsDb.IsActive = true;
            _iEnvironmentTypeSettingsRepository.Update(environmentTypeSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
    }

    public async Task<IEnumerable<EnvironmentTypeSettingsExcelDTO>> GetAllEnvironmentTypeSettingsExcelAsync()
    {
            var data = await (from p in _iEnvironmentTypeSettingsRepository.GetAll()
                              orderby p.Id ascending
                              select p).ToListAsync();

        return _iMapperService.ApplyMapToEntity<IEnumerable<EnvironmentTypeSettings>, IEnumerable<EnvironmentTypeSettingsExcelDTO>>(data);
    }
}