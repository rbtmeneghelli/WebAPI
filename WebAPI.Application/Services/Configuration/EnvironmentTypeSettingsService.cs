using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.EntitiesDTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Configuration;

public class EnvironmentTypeSettingsService : GenericService, IEnvironmentTypeSettingsService
{
    private readonly IEnvironmentTypeSettingsRepository _iEnvironmentTypeSettingsRepository;
    private EnvironmentVariables _environmentVariables;

    public EnvironmentTypeSettingsService(
        IEnvironmentTypeSettingsRepository iEnvironmentTypeSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables)
        : base(iNotificationMessageService)
    {
        _iEnvironmentTypeSettingsRepository = iEnvironmentTypeSettingsRepository;
        _environmentVariables = environmentVariables;
    }

    public async Task<IEnumerable<EnvironmentTypeSettingsResponseDTO>> GetAllEnvironmentTypeSettingsAsync()
    {
        try
        {
            return await (from p in _iEnvironmentTypeSettingsRepository.GetAll()
                          orderby p.Id ascending
                          select new EnvironmentTypeSettingsResponseDTO()
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.Description,
                              EnvironmentInitial = p.Initials,
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<EnvironmentTypeSettingsResponseDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<EnvironmentTypeSettingsResponseDTO> GetEnvironmentTypeSettingsByIdAsync(long id)
    {
        try
        {
            return await (from p in _iEnvironmentTypeSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                          select new EnvironmentTypeSettingsResponseDTO
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.Description,
                              EnvironmentInitial = p.Initials,
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

    public async Task<bool> ExistEnvironmentTypeSettingsByIdAsync(long id)
    {
        var result = _iEnvironmentTypeSettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateEnvironmentTypeSettingsAsync(EnvironmentTypeSettings environmentTypeSettings)
    {
        try
        {
            _iEnvironmentTypeSettingsRepository.Create(environmentTypeSettings);
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

    public async Task<bool> UpdateEnvironmentTypeSettingsAsync(long id, EnvironmentTypeSettings environmentTypeSettings)
    {
        try
        {
            EnvironmentTypeSettings environmentTypeSettingsDb = _iEnvironmentTypeSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(environmentTypeSettingsDb))
            {
                if (environmentTypeSettingsDb.Status)
                {
                    environmentTypeSettingsDb.UpdateDate = environmentTypeSettings.UpdateDate;
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

    public async Task<bool> LogicDeleteEnvironmentTypeSettingsByIdAsync(long id)
    {
        try
        {
            EnvironmentTypeSettings environmentTypeSettingsDb = _iEnvironmentTypeSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(environmentTypeSettingsDb))
            {
                environmentTypeSettingsDb.UpdateDate = environmentTypeSettingsDb.GetNewUpdateDate();
                environmentTypeSettingsDb.Status = false;
                _iEnvironmentTypeSettingsRepository.Update(environmentTypeSettingsDb);
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

    public async Task<bool> ReactiveEnvironmentTypeSettingsByIdAsync(long id)
    {
        try
        {
            EnvironmentTypeSettings environmentTypeSettingsDb = _iEnvironmentTypeSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(environmentTypeSettingsDb))
            {
                environmentTypeSettingsDb.UpdateDate = environmentTypeSettingsDb.GetNewUpdateDate();
                environmentTypeSettingsDb.Status = true;
                _iEnvironmentTypeSettingsRepository.Update(environmentTypeSettingsDb);
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

    public async Task<IEnumerable<EnvironmentTypeSettingsExcelDTO>> GetAllEnvironmentTypeSettingsExcelAsync()
    {
        try
        {
            return await (from p in _iEnvironmentTypeSettingsRepository.GetAll()
                          orderby p.Id ascending
                          select new EnvironmentTypeSettingsExcelDTO()
                          {
                              EnvironmentDescription = p.Description,
                              EnvironmentInitial = p.Initials,
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<EnvironmentTypeSettingsExcelDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }
}