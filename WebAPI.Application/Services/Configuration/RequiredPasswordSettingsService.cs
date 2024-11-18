using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Configuration;

public class RequiredPasswordSettingsService : GenericService, IRequiredPasswordSettingsService
{
    private readonly IRequiredPasswordSettingsRepository _iRequiredPasswordSettingsRepository;
    private EnvironmentVariables _environmentVariables;

    public RequiredPasswordSettingsService(
        IRequiredPasswordSettingsRepository iRequiredPasswordSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables)
        : base(iNotificationMessageService)
    {
        _iRequiredPasswordSettingsRepository = iRequiredPasswordSettingsRepository;
        _environmentVariables = environmentVariables;
    }

    public async Task<IEnumerable<RequiredPasswordSettingsResponseDTO>> GetAllRequiredPasswordSettingsAsync()
    {
        try
        {
            return await (from p in _iRequiredPasswordSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                          orderby p.EnvironmentTypeSettings.Id ascending
                          select new RequiredPasswordSettingsResponseDTO()
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              MinimalOfChars = p.MinimalOfChars,
                              MustHaveNumbers = p.MustHaveNumbers,
                              MustHaveSpecialChars = p.MustHaveSpecialChars,
                              MustHaveUpperCaseLetter = p.MustHaveUpperCaseLetter,
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<RequiredPasswordSettingsResponseDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<RequiredPasswordSettingsResponseDTO> GetRequiredPasswordSettingsByEnvironmentAsync()
    {
        try
        {
            return await (from p in _iRequiredPasswordSettingsRepository.FindBy(x => x.IdEnvironmentType == (int)_environmentVariables.Environment).AsQueryable()
                          select new RequiredPasswordSettingsResponseDTO
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              MinimalOfChars = p.MinimalOfChars,
                              MustHaveNumbers = p.MustHaveNumbers,
                              MustHaveSpecialChars = p.MustHaveSpecialChars,
                              MustHaveUpperCaseLetter = p.MustHaveUpperCaseLetter,
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

    public async Task<RequiredPasswordSettingsResponseDTO> GetRequiredPasswordSettingsByIdAsync(long id)
    {
        try
        {
            return await (from p in _iRequiredPasswordSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                          select new RequiredPasswordSettingsResponseDTO
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              MinimalOfChars = p.MinimalOfChars,
                              MustHaveNumbers = p.MustHaveNumbers,
                              MustHaveSpecialChars = p.MustHaveSpecialChars,
                              MustHaveUpperCaseLetter = p.MustHaveUpperCaseLetter,
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

    public async Task<bool> ExistRequiredPasswordSettingsByEnvironmentAsync()
    {
        var result = _iRequiredPasswordSettingsRepository.Exist(x => x.IdEnvironmentType == (int)_environmentVariables.Environment);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> ExistRequiredPasswordSettingsByIdAsync(long id)
    {
        var result = _iRequiredPasswordSettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateRequiredPasswordSettingsAsync(RequiredPasswordSettings requiredPasswordSettings)
    {
        try
        {
            _iRequiredPasswordSettingsRepository.Create(requiredPasswordSettings);
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

    public async Task<bool> UpdateRequiredPasswordSettingsAsync(RequiredPasswordSettings requiredPasswordSettings)
    {
        try
        {
            RequiredPasswordSettings requiredPasswordSettingsDb = _iRequiredPasswordSettingsRepository.GetById(requiredPasswordSettings.Id.Value);

            if (GuardClauses.ObjectIsNotNull(requiredPasswordSettingsDb))
            {
                if (requiredPasswordSettingsDb.Status)
                {
                    requiredPasswordSettingsDb.UpdateDate = requiredPasswordSettings.UpdateDate;
                    requiredPasswordSettingsDb.MinimalOfChars = requiredPasswordSettings.MinimalOfChars;
                    requiredPasswordSettingsDb.MustHaveNumbers = requiredPasswordSettings.MustHaveNumbers;
                    requiredPasswordSettingsDb.MustHaveSpecialChars = requiredPasswordSettings.MustHaveSpecialChars;
                    requiredPasswordSettingsDb.MustHaveUpperCaseLetter = requiredPasswordSettings.MustHaveUpperCaseLetter;
                    _iRequiredPasswordSettingsRepository.Update(requiredPasswordSettingsDb);
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

    public async Task<bool> LogicDeleteRequiredPasswordSettingsByIdAsync(long id)
    {
        try
        {
            RequiredPasswordSettings requiredPasswordSettingsDb = _iRequiredPasswordSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(requiredPasswordSettingsDb))
            {
                requiredPasswordSettingsDb.UpdateDate = requiredPasswordSettingsDb.GetNewUpdateDate();
                requiredPasswordSettingsDb.Status = false;
                _iRequiredPasswordSettingsRepository.Update(requiredPasswordSettingsDb);
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

    public async Task<bool> ReactiveRequiredPasswordSettingsByIdAsync(long id)
    {
        try
        {
            RequiredPasswordSettings requiredPasswordSettingsDb = _iRequiredPasswordSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(requiredPasswordSettingsDb))
            {
                requiredPasswordSettingsDb.UpdateDate = requiredPasswordSettingsDb.GetNewUpdateDate();
                requiredPasswordSettingsDb.Status = true;
                _iRequiredPasswordSettingsRepository.Update(requiredPasswordSettingsDb);
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

    public async Task<IEnumerable<RequiredPasswordSettingsExcelDTO>> GetAllRequiredPasswordSettingsExcelAsync()
    {
        try
        {
            return await (from p in _iRequiredPasswordSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                          orderby p.EnvironmentTypeSettings.Id ascending
                          select new RequiredPasswordSettingsExcelDTO()
                          {
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              MinimalOfChars = p.MinimalOfChars,
                              MustHaveNumbersDescription = p.GetStatusDescription(),
                              MustHaveSpecialCharsDescription = p.GetStatusDescription(),
                              MustHaveUpperCaseLetterDescription = p.GetStatusDescription(),
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<RequiredPasswordSettingsExcelDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }
}
