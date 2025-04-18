using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.Filters.ControlPanel;

namespace WebAPI.Application.Services.Configuration;

public class AuthenticationSettingsService : BaseHandlerService, IAuthenticationSettingsService
{
    private readonly IAuthenticationSettingsRepository _iAuthenticationSettingsRepository;
    private readonly IMapperService _iMapperService;
    private EnvironmentVariables _environmentVariables;

    public AuthenticationSettingsService(
        IAuthenticationSettingsRepository iAuthenticationSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables,
        IMapperService iMapperService)
        : base(iNotificationMessageService)
    {
        _iAuthenticationSettingsRepository = iAuthenticationSettingsRepository;
        _environmentVariables = environmentVariables;
        _iMapperService = iMapperService;
    }

    public async Task<IEnumerable<AuthenticationSettingsResponseDTO>> GetAllAuthenticationSettingsAsync()
    {
        try
        {
            return await (from p in _iAuthenticationSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                          orderby p.EnvironmentTypeSettings.Id ascending
                          select new AuthenticationSettingsResponseDTO()
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              NumberOfTryToBlockUser = p.NumberOfTryToBlockUser,
                              BlockUserTime = p.BlockUserTime,
                              ApplyTwoFactoryValidation = p.ApplyTwoFactoryValidation,
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<AuthenticationSettingsResponseDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<AuthenticationSettingsResponseDTO> GetAuthenticationSettingsByEnvironmentAsync()
    {
        try
        {
            return await (from p in _iAuthenticationSettingsRepository.FindBy(x => x.IdEnvironmentType == (int)_environmentVariables.Environment).AsQueryable()
                          select new AuthenticationSettingsResponseDTO
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              NumberOfTryToBlockUser = p.NumberOfTryToBlockUser,
                              BlockUserTime = p.BlockUserTime,
                              ApplyTwoFactoryValidation = p.ApplyTwoFactoryValidation,
                              StatusDescription = p.Status ? FixConstants.STATUS_ACTIVE : FixConstants.STATUS_INACTIVE
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

    public async Task<AuthenticationSettingsResponseDTO> GetAuthenticationSettingsByIdAsync(long id)
    {
        try
        {
            return await (from p in _iAuthenticationSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                          select new AuthenticationSettingsResponseDTO
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              NumberOfTryToBlockUser = p.NumberOfTryToBlockUser,
                              BlockUserTime = p.BlockUserTime,
                              ApplyTwoFactoryValidation = p.ApplyTwoFactoryValidation,
                              StatusDescription = p.Status ? FixConstants.STATUS_ACTIVE : FixConstants.STATUS_INACTIVE
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

    public async Task<bool> ExistAuthenticationSettingsByEnvironmentAsync()
    {
        var result = _iAuthenticationSettingsRepository.Exist(x => x.IdEnvironmentType == (int)_environmentVariables.Environment);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> ExistAuthenticationSettingsByIdAsync(long id)
    {
        var result = _iAuthenticationSettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateAuthenticationSettingsAsync(AuthenticationSettingsCreateRequestDTO authenticationSettingsCreateRequestDTO)
    {
        try
        {
            AuthenticationSettings authenticationSettings = _iMapperService.ApplyMapToEntity<AuthenticationSettingsCreateRequestDTO, AuthenticationSettings>(authenticationSettingsCreateRequestDTO);
            _iAuthenticationSettingsRepository.Create(authenticationSettings);
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

    public async Task<bool> UpdateAuthenticationSettingsAsync(AuthenticationSettingsUpdateRequestDTO authenticationSettingsCreateRequestDTO)
    {
        try
        {
            AuthenticationSettings authenticationSettings = _iMapperService.ApplyMapToEntity<AuthenticationSettingsUpdateRequestDTO, AuthenticationSettings>(authenticationSettingsCreateRequestDTO);
            AuthenticationSettings authenticationSettingsDb = _iAuthenticationSettingsRepository.GetById(authenticationSettings.Id.Value);

            if (GuardClauses.ObjectIsNotNull(authenticationSettingsDb))
            {
                if (authenticationSettingsDb.Status)
                {
                    authenticationSettingsDb.UpdateDate = authenticationSettings.UpdateDate;
                    authenticationSettingsDb.NumberOfTryToBlockUser = authenticationSettings.NumberOfTryToBlockUser;
                    authenticationSettingsDb.BlockUserTime = authenticationSettings.BlockUserTime;
                    authenticationSettingsDb.ApplyTwoFactoryValidation = authenticationSettings.ApplyTwoFactoryValidation;
                    _iAuthenticationSettingsRepository.Update(authenticationSettingsDb);
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

    public async Task<bool> LogicDeleteAuthenticationSettingsByIdAsync(long id)
    {
        try
        {
            AuthenticationSettings authenticationSettingsDb = _iAuthenticationSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(authenticationSettingsDb))
            {
                authenticationSettingsDb.UpdateDate = authenticationSettingsDb.GetNewUpdateDate();
                authenticationSettingsDb.Status = false;
                _iAuthenticationSettingsRepository.Update(authenticationSettingsDb);
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

    public async Task<bool> ReactiveAuthenticationSettingsByIdAsync(long id)
    {
        try
        {
            AuthenticationSettings authenticationSettingsDb = _iAuthenticationSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(authenticationSettingsDb))
            {
                authenticationSettingsDb.UpdateDate = authenticationSettingsDb.GetNewUpdateDate();
                authenticationSettingsDb.Status = true;
                _iAuthenticationSettingsRepository.Update(authenticationSettingsDb);
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

    public async Task<IEnumerable<AuthenticationSettingsExcelDTO>> GetAllAuthenticationSettingsExcelAsync()
    {
        try
        {
            return await (from p in _iAuthenticationSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                          orderby p.EnvironmentTypeSettings.Id ascending
                          select new AuthenticationSettingsExcelDTO()
                          {
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              NumberOfTryToBlockUser = p.NumberOfTryToBlockUser,
                              BlockUserTime = p.BlockUserTime,
                              ApplyTwoFactoryValidation = p.ApplyTwoFactoryValidation,
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<AuthenticationSettingsExcelDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }
}
