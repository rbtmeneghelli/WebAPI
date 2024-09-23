using WebAPI.Application.Factory;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Cryptography;
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
    public AuthenticationSettingsService(
        IAuthenticationSettingsRepository iAuthenticationSettingsRepository,
        INotificationMessageService iNotificationMessageService) 
        : base(iNotificationMessageService)
    {
        _iAuthenticationSettingsRepository = iAuthenticationSettingsRepository;
    }

    public async Task<IEnumerable<AuthenticationSettingsResponseDTO>> GetAllAsync()
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

    //public async Task<PagedResult<UserResponseDTO>> GetAllPaginateAsync(UserFilter filter)
    //{
    //    try
    //    {
    //        var query = GetAllUsers(filter);

    //        var queryResult = from p in query.AsQueryable()
    //                          orderby p.Login ascending
    //                          select new UserResponseDTO
    //                          {
    //                              Id = p.Id,
    //                              Login = p.Login,
    //                              IsAuthenticated = p.IsAuthenticated,
    //                              IsActive = p.Status,
    //                              Password = "-",
    //                              LastPassword = "-",
    //                              Profile = p.Employee.Profile.Description,
    //                              Status = p.GetStatusDescription(),
    //                          };

    //        return PagedFactory.GetPaged(queryResult, PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
    //    }
    //    catch (Exception ex)
    //    {
    //        Notify(ex.Message);
    //        return PagedFactory.GetPaged(Enumerable.Empty<UserResponseDTO>().AsQueryable(), PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
    //    }
    //    finally
    //    {
    //        await Task.CompletedTask;
    //    }
    //}

    //public async Task<UserResponseDTO> GetByIdAsync(long id)
    //{
    //    try
    //    {
    //        return await (from p in _iUserRepository.FindBy(x => x.Id == id).AsQueryable()
    //                      orderby p.Login ascending
    //                      select new UserResponseDTO
    //                      {
    //                          Id = p.Id,
    //                          Login = p.Login,
    //                          IsAuthenticated = p.IsAuthenticated,
    //                          IsActive = p.Status,
    //                          Password = "-",
    //                          LastPassword = "-",
    //                          Status = p.GetStatusDescription(),
    //                      }).FirstOrDefaultAsync();
    //    }
    //    catch
    //    {
    //        Notify(FixConstants.ERROR_IN_GETID);
    //        return default;
    //    }
    //    finally
    //    {
    //        await Task.CompletedTask;
    //    }
    //}

    //public async Task<UserResponseDTO> GetByLoginAsync(string login)
    //{
    //    try
    //    {
    //        return await (from p in _iUserRepository.FindBy(x => x.Login == login.ApplyTrim()).AsQueryable()
    //                      orderby p.Login ascending
    //                      select new UserResponseDTO
    //                      {
    //                          Id = p.Id,
    //                          Login = p.Login,
    //                          IsAuthenticated = p.IsAuthenticated,
    //                          IsActive = p.Status,
    //                          Password = "-",
    //                          LastPassword = "-",
    //                          Profile = p.Employee.Profile.Description,
    //                          Status = p.GetStatusDescription(),
    //                      }).FirstOrDefaultAsync();
    //    }
    //    catch
    //    {
    //        Notify("Ocorreu um erro ao efetuar a pesquisa a partir do login. Entre em contato com o administrador");
    //        return default;
    //    }
    //    finally
    //    {
    //        await Task.CompletedTask;
    //    }
    //}

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
