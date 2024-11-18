using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Configuration;

public class ExpirationPasswordSettingsService : GenericService, IExpirationPasswordSettingsService
{
    private readonly IExpirationPasswordSettingsRepository _iExpirationPasswordSettingsRepository;
    private EnvironmentVariables _environmentVariables;

    public ExpirationPasswordSettingsService(
        IExpirationPasswordSettingsRepository iExpirationPasswordSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables)
        : base(iNotificationMessageService)
    {
        _iExpirationPasswordSettingsRepository = iExpirationPasswordSettingsRepository;
        _environmentVariables = environmentVariables;
    }

    public async Task<IEnumerable<ExpirationPasswordSettingsResponseDTO>> GetAllExpirationPasswordSettingsAsync()
    {
        try
        {
            return await (from p in _iExpirationPasswordSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                          orderby p.EnvironmentTypeSettings.Id ascending
                          select new ExpirationPasswordSettingsResponseDTO()
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              QtyDaysPasswordExpire = p.QtyDaysPasswordExpire,
                              NotifyExpirationDays = p.NotifyExpirationDays,
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<ExpirationPasswordSettingsResponseDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<ExpirationPasswordSettingsResponseDTO> GetExpirationPasswordSettingsByEnvironmentAsync()
    {
        try
        {
            return await (from p in _iExpirationPasswordSettingsRepository.FindBy(x => x.IdEnvironmentType == (int)_environmentVariables.Environment).AsQueryable()
                          select new ExpirationPasswordSettingsResponseDTO
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              QtyDaysPasswordExpire = p.QtyDaysPasswordExpire,
                              NotifyExpirationDays = p.NotifyExpirationDays,
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

    public async Task<ExpirationPasswordSettingsResponseDTO> GetExpirationPasswordSettingsByIdAsync(long id)
    {
        try
        {
            return await (from p in _iExpirationPasswordSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                          select new ExpirationPasswordSettingsResponseDTO
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              QtyDaysPasswordExpire = p.QtyDaysPasswordExpire,
                              NotifyExpirationDays = p.NotifyExpirationDays,
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

    public async Task<bool> CreateExpirationPasswordSettingsAsync(ExpirationPasswordSettings expirationPasswordSettings)
    {
        try
        {
            _iExpirationPasswordSettingsRepository.Create(expirationPasswordSettings);
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

    public async Task<bool> UpdateExpirationPasswordSettingsAsync(ExpirationPasswordSettings expirationPasswordSettings)
    {
        try
        {
            ExpirationPasswordSettings expirationPasswordSettingsDb = _iExpirationPasswordSettingsRepository.GetById(expirationPasswordSettings.Id.Value);

            if (GuardClauses.ObjectIsNotNull(expirationPasswordSettingsDb))
            {
                if (expirationPasswordSettingsDb.Status)
                {
                    expirationPasswordSettingsDb.UpdateDate = expirationPasswordSettings.UpdateDate;
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

    public async Task<bool> LogicDeleteExpirationPasswordSettingsByIdAsync(long id)
    {
        try
        {
            ExpirationPasswordSettings expirationPasswordSettingsDb = _iExpirationPasswordSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(expirationPasswordSettingsDb))
            {
                expirationPasswordSettingsDb.UpdateDate = expirationPasswordSettingsDb.GetNewUpdateDate();
                expirationPasswordSettingsDb.Status = false;
                _iExpirationPasswordSettingsRepository.Update(expirationPasswordSettingsDb);
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

    public async Task<bool> ReactiveExpirationPasswordSettingsByIdAsync(long id)
    {
        try
        {
            ExpirationPasswordSettings expirationPasswordSettingsDb = _iExpirationPasswordSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(expirationPasswordSettingsDb))
            {
                expirationPasswordSettingsDb.UpdateDate = expirationPasswordSettingsDb.GetNewUpdateDate();
                expirationPasswordSettingsDb.Status = true;
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
                              StatusDescription = p.GetStatusDescription()
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
