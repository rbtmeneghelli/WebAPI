using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;

namespace WebAPI.Application.Services.Configuration;

public sealed class ExpirationPasswordSettingsService : BaseHandlerService, IExpirationPasswordSettingsService
{
    private readonly IExpirationPasswordSettingsRepository _iExpirationPasswordSettingsRepository;
    private EnvironmentVariables _environmentVariables;
    private readonly IMapperService _iMapperService;

    public ExpirationPasswordSettingsService(
        IExpirationPasswordSettingsRepository iExpirationPasswordSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables,
        IMapperService iMapperService)
        : base(iNotificationMessageService)
    {
        _iExpirationPasswordSettingsRepository = iExpirationPasswordSettingsRepository;
        _environmentVariables = environmentVariables;
        _iMapperService = iMapperService;
    }

    public async Task<IEnumerable<ExpirationPasswordSettingsResponseDTO>> GetAllExpirationPasswordSettingsAsync()
    {
        return await (from p in _iExpirationPasswordSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                      orderby p.EnvironmentTypeSettings.Id ascending
                      select new ExpirationPasswordSettingsResponseDTO()
                      {
                          Id = p.Id.Value,
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          QtyDaysPasswordExpire = p.QtyDaysPasswordExpire,
                          NotifyExpirationDays = p.NotifyExpirationDays,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }

    public async Task<ExpirationPasswordSettingsResponseDTO> GetExpirationPasswordSettingsByEnvironmentAsync()
    {
        return await (from p in _iExpirationPasswordSettingsRepository.FindBy(x => x.IdEnvironmentType == (int)_environmentVariables.Environment).AsQueryable()
                      select new ExpirationPasswordSettingsResponseDTO
                      {
                          Id = p.Id.Value,
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          QtyDaysPasswordExpire = p.QtyDaysPasswordExpire,
                          NotifyExpirationDays = p.NotifyExpirationDays,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
    }

    public async Task<ExpirationPasswordSettingsResponseDTO> GetExpirationPasswordSettingsByIdAsync(long id)
    {
        return await (from p in _iExpirationPasswordSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                      select new ExpirationPasswordSettingsResponseDTO
                      {
                          Id = p.Id.Value,
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          QtyDaysPasswordExpire = p.QtyDaysPasswordExpire,
                          NotifyExpirationDays = p.NotifyExpirationDays,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
    }

    public async Task<bool> ExistExpirationPasswordSettingsByEnvironmentAsync()
    {
        var result = _iExpirationPasswordSettingsRepository.Exist(x => x.IdEnvironmentType == (int)_environmentVariables.Environment);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> ExistExpirationPasswordSettingsByIdAsync(long id)
    {
        var result = _iExpirationPasswordSettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateExpirationPasswordSettingsAsync(ExpirationPasswordSettingsCreateRequestDTO expirationPasswordSettingsCreateRequestDTO)
    {
        ExpirationPasswordSettings expirationPasswordSettings = _iMapperService.MapDTOToEntity<ExpirationPasswordSettingsCreateRequestDTO, ExpirationPasswordSettings>(expirationPasswordSettingsCreateRequestDTO);
        _iExpirationPasswordSettingsRepository.Create(expirationPasswordSettings);
        return true;
    }

    public async Task<bool> UpdateExpirationPasswordSettingsAsync(ExpirationPasswordSettingsUpdateRequestDTO expirationPasswordSettingsUpdateRequestDTO)
    {
        ExpirationPasswordSettings expirationPasswordSettings = _iMapperService.MapDTOToEntity<ExpirationPasswordSettingsUpdateRequestDTO, ExpirationPasswordSettings>(expirationPasswordSettingsUpdateRequestDTO);
        ExpirationPasswordSettings expirationPasswordSettingsDb = _iExpirationPasswordSettingsRepository.GetById(expirationPasswordSettings.Id.Value);

        if (GuardClauseExtension.IsNotNull(expirationPasswordSettingsDb))
        {
            if (expirationPasswordSettingsDb.IsActive.Value)
            {
                expirationPasswordSettingsDb.UpdatedAt = expirationPasswordSettings.UpdatedAt;
                expirationPasswordSettingsDb.QtyDaysPasswordExpire = expirationPasswordSettings.QtyDaysPasswordExpire;
                expirationPasswordSettingsDb.NotifyExpirationDays = expirationPasswordSettings.NotifyExpirationDays;
                _iExpirationPasswordSettingsRepository.Update(expirationPasswordSettingsDb);
                return true;
            }

            Notify(FixConstants.ERROR_IN_UPDATE);
            return false;
        }

        Notify(FixConstants.ERROR_IN_UPDATE);
        return false;
    }

    public async Task<bool> LogicDeleteExpirationPasswordSettingsByIdAsync(long id)
    {
        ExpirationPasswordSettings expirationPasswordSettingsDb = _iExpirationPasswordSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(expirationPasswordSettingsDb))
        {
            expirationPasswordSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            expirationPasswordSettingsDb.IsActive = false;
            _iExpirationPasswordSettingsRepository.Update(expirationPasswordSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
    }

    public async Task<bool> ReactiveExpirationPasswordSettingsByIdAsync(long id)
    {
        try
        {
            ExpirationPasswordSettings expirationPasswordSettingsDb = _iExpirationPasswordSettingsRepository.GetById(id);

            if (GuardClauseExtension.IsNotNull(expirationPasswordSettingsDb))
            {
                expirationPasswordSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
                expirationPasswordSettingsDb.IsActive = true;
                _iExpirationPasswordSettingsRepository.Update(expirationPasswordSettingsDb);
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

    public async Task<IEnumerable<ExpirationPasswordSettingsExcelDTO>> GetAllExpirationPasswordSettingsExcelAsync()
    {
        try
        {
            return await (from p in _iExpirationPasswordSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                          orderby p.EnvironmentTypeSettings.Id ascending
                          select new ExpirationPasswordSettingsExcelDTO()
                          {
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              QtyDaysPasswordExpire = p.QtyDaysPasswordExpire,
                              NotifyExpirationDays = p.NotifyExpirationDays,
                              StatusDescription = p.IsActive.GetDescriptionByBoolean()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<ExpirationPasswordSettingsExcelDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }
}
