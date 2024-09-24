using WebAPI.Application.Factory;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Cryptography;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.EntitiesDTO.Configuration;
using WebAPI.Domain.EntitiesDTO.ControlPanel;
using WebAPI.Domain.Filters.ControlPanel;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Configuration;

public class AuthenticationSettingsService : GenericService, IAuthenticationSettingsService
{
    private readonly IAuthenticationSettingsRepository _iAuthenticationSettingsRepository;
    private EnvironmentVariables _environmentVariables;

    public AuthenticationSettingsService(
        IAuthenticationSettingsRepository iAuthenticationSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables)
        : base(iNotificationMessageService)
    {
        _iAuthenticationSettingsRepository = iAuthenticationSettingsRepository;
        _environmentVariables = environmentVariables;
    }

    public async Task<IEnumerable<AuthenticationSettingsResponseDTO>> GetAllAuthenticationSettingsAsync()
    {
        try
        {
            return await (from p in _iAuthenticationSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                          orderby p.EnvironmentTypeSettings.Id ascending
                          select new AuthenticationSettingsResponseDTO()
                          {
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              NumberOfTryToBlockUser = p.NumberOfTryToBlockUser,
                              BlockUserTime = p.BlockUserTime,
                              ApplyTwoFactoryValidation = p.ApplyTwoFactoryValidation,
                              StatusDescription = p.Status ? FixConstants.STATUS_ACTIVE : FixConstants.STATUS_INACTIVE
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

    public async Task<bool> CreateAuthenticationSettingsAsync(AuthenticationSettings authenticationSettings)
    {
        try
        {
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

    public async Task<bool> UpdateAuthenticationSettingsAsync(long id, AuthenticationSettings authenticationSettings)
    {
        try
        {
            AuthenticationSettings authenticationSettingsDb = _iAuthenticationSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(authenticationSettingsDb))
            {
                authenticationSettingsDb.Status = authenticationSettings.Status;
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

    //public async Task<bool> UpdateAsync(long id, User user)
    //{
    //    try
    //    {
    //        User userDb = _iUserRepository.GetById(id);

    //        if (GuardClauses.ObjectIsNotNull(userDb))
    //        {
    //            userDb.LastPassword = userDb.Password;
    //            userDb.Password = HashingManager.GetLoadHashingManager().HashToString(user.Password);
    //            userDb.UpdateDate = userDb.GetNewUpdateDate();
    //            _iUserRepository.Update(userDb);
    //            return true;
    //        }
    //        Notify(FixConstants.ERROR_IN_UPDATE);
    //        return false;
    //    }
    //    catch (Exception ex)
    //    {
    //        Notify(FixConstants.ERROR_IN_UPDATE);
    //        return false;
    //    }
    //    finally
    //    {
    //        await Task.CompletedTask;
    //    }
    //}

    //public async Task<bool> DeleteLogicAsync(long id)
    //{
    //    try
    //    {
    //        User user = _iUserRepository.GetById(id);

    //        if (GuardClauses.ObjectIsNotNull(user))
    //        {
    //            user.UpdateDate = user.GetNewUpdateDate();
    //            user.Status = false;
    //            _iUserRepository.Update(user);
    //            return true;
    //        }
    //        else
    //        {
    //            Notify(FixConstants.ERROR_IN_DELETELOGIC);
    //            return false;
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        Notify(FixConstants.ERROR_IN_DELETELOGIC);
    //        return false;
    //    }
    //    finally
    //    {
    //        await Task.CompletedTask;
    //    }
    //}

    //public async Task<bool> ReactiveUserAsync(long id)
    //{
    //    try
    //    {
    //        User user = _iUserRepository.GetById(id);

    //        if (GuardClauses.ObjectIsNotNull(user))
    //        {
    //            user.UpdateDate = user.GetNewUpdateDate();
    //            user.Status = true;
    //            _iUserRepository.Update(user);
    //            return true;
    //        }

    //        return false;
    //    }
    //    catch (Exception)
    //    {
    //        Notify(FixConstants.ERROR_IN_ACTIVERECORD);
    //        return false;
    //    }
    //    finally
    //    {
    //        await Task.CompletedTask;
    //    }
    //}
}
