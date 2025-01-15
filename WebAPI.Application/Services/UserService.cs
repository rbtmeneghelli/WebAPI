using WebAPI.Application.Factory;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Cryptography;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Filters.ControlPanel;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services;

public class UserService : GenericService, IUserService
{
    private readonly IUserRepository _iUserRepository;
    private readonly IMapperService _iMapperService;

    public UserService(
        IUserRepository iUserRepository,
        INotificationMessageService iNotificationMessageService,
        IMapperService iMapperService) : base(iNotificationMessageService)
    {
        _iUserRepository = iUserRepository;
        _iMapperService = iMapperService;;
    }

    private IQueryable<User> GetAllUsers(UserFilter filter)
    {
        // Exemplo Utilizando SimpleFactory
        // var obj = UserFactory.GetData(EnumProfileType.Admin);
        // return _userRepository.GetAllTracking().Include(x => x.Profile).Where(obj.GetPredicate(filter)).AsQueryable();
        if (filter.IsActive.HasValue)
            return _iUserRepository.GetAllIgnoreQueryFilter().Include(x => x.Employee).ThenInclude(x => x.Profile).Where(GetPredicate(filter)).AsQueryable();
        else
            return _iUserRepository.GetAll().Include(x => x.Employee).ThenInclude(x => x.Profile).Where(GetPredicate(filter)).AsQueryable();
    }

    private Expression<Func<User, bool>> GetPredicate(UserFilter filter)
    {
        if (filter.IsActive.HasValue)
            return p =>
            (GuardClauses.IsNullOrWhiteSpace(filter.Login) || p.Login.StartsWith(filter.Login.ApplyTrim()))
            &&
            (!filter.IsAuthenticated.HasValue || filter.IsAuthenticated == p.IsAuthenticated)
            &&
            (!filter.IsActive.HasValue || filter.IsActive == p.Status)
            &&
            (!filter.IdProfile.HasValue || filter.IdProfile == p.Employee.IdProfile);
        else
            return p =>
            (GuardClauses.IsNullOrWhiteSpace(filter.Login) || p.Login.StartsWith(filter.Login.ApplyTrim()))
            &&
            (!filter.IsAuthenticated.HasValue || filter.IsAuthenticated == p.IsAuthenticated)
            &&
            (!filter.IdProfile.HasValue || filter.IdProfile == p.Employee.IdProfile);
    }

    public async Task<IEnumerable<UserResponseDTO>> GetAllUserAsync()
    {
        try
        {
            var data = await (from p in _iUserRepository.GetAll().Include(x => x.Employee).ThenInclude(x => x.Profile)
                              orderby p.Login ascending
                              select p).ToListAsync();

            return _iMapperService.ApplyMapToEntity<IEnumerable<User>, IEnumerable<UserResponseDTO>>(data);
            //return data.ToDTO();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<UserResponseDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<PagedResult<UserResponseDTO>> GetAllUserPaginateAsync(UserFilter filter)
    {
        try
        {
            var query = GetAllUsers(filter);

            var queryResult = await Task.FromResult(from p in query.AsQueryable()
                                                    orderby p.Login ascending
                                                    select p);

            var data = _iMapperService.ApplyMapToEntity<IEnumerable<User>, IEnumerable<UserResponseDTO>>(queryResult);
            //var data = queryResult.ToDTO();

            return PagedFactory.GetPaged(data.AsQueryable(), PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
        }
        catch (Exception ex)
        {
            Notify(ex.Message);
            return PagedFactory.GetPaged(Enumerable.Empty<UserResponseDTO>().AsQueryable(), PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<UserResponseDTO> GetUserByIdAsync(long id)
    {
        try
        {
            var data = await (from p in _iUserRepository.FindBy(x => x.Id == id).AsQueryable()
                              orderby p.Login ascending
                              select p).FirstOrDefaultAsync();

            return _iMapperService.ApplyMapToEntity<User,UserResponseDTO>(data);
            //return data.ToDTO();
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

    public async Task<UserResponseDTO> GetUserByLoginAsync(string login)
    {
        try
        {
            var data = await (from p in _iUserRepository.FindBy(x => x.Login == login.ApplyTrim()).AsQueryable()
                              orderby p.Login ascending
                              select p).FirstOrDefaultAsync();

            return _iMapperService.ApplyMapToEntity<User, UserResponseDTO>(data);
            //return data.ToDTO();
        }
        catch
        {
            Notify("Ocorreu um erro ao efetuar a pesquisa a partir do login. Entre em contato com o administrador");
            return default;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<IEnumerable<DropDownList>> GetUsersAsync()
    {
        try
        {
            var result = _iUserRepository.FindBy(x => x.IsAuthenticated == true)
                         .Select(x => new DropDownList()
                         {
                             Id = x.Id.Value,
                             Description = x.Login
                         }).AsEnumerable();

            await Task.CompletedTask;

            return result;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETDDL);
            return Enumerable.Empty<DropDownList>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> ExistUserByIdAsync(long id)
    {
        var result = _iUserRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> ExistUserByLoginAsync(string login)
    {
        if (GuardClauses.IsNullOrWhiteSpace(login))
        {
            return false;
        }

        var result = _iUserRepository.Exist(x => x.Login == login.ApplyTrim());
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateUserAsync(UserRequestDTO userRequestDTO)
    {
        try
        {
            User user = _iMapperService.ApplyMapToEntity<UserRequestDTO, User>(userRequestDTO);

            if (GuardClauses.IsNullOrWhiteSpace(user.Login) || GuardClauses.IsNullOrWhiteSpace(user.Password))
            {
                Notify("Para realizar o cadastro do login, o campo login e senha deve ser preenchido");
                return false;
            }

            else if (_iUserRepository.Exist(x => x.Login == user.Login) == false)
            {
                user.Password = HashingManager.GetLoadHashingManager().HashToString(user.Password);
                _iUserRepository.Add(user);
                return true;
            }

            Notify($"Já existe um login {user.Login} cadastrado, troque de login");
            return false;
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

    public async Task<bool> UpdateUserAsync(long id, UserRequestDTO userRequestDTO)
    {
        try
        {
            User user = _iMapperService.ApplyMapToEntity<UserRequestDTO, User>(userRequestDTO);
            User userDb = _iUserRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(userDb))
            {
                userDb.LastPassword = userDb.Password;
                userDb.Password = HashingManager.GetLoadHashingManager().HashToString(user.Password);
                userDb.UpdateDate = userDb.GetNewUpdateDate();
                _iUserRepository.Update(userDb);
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

    public async Task<bool> DeleteUserPhysicalAsync(long id)
    {
        try
        {
            User user = _iUserRepository.GetById(id);

            if (GuardClauses.ObjectIsNull(user) == false)
            {
                _iUserRepository.Remove(user);
                return true;
            }
            else
            {
                Notify(FixConstants.ERROR_IN_DELETEPHYSICAL);
                return false;
            }
        }
        catch (Exception)
        {
            Notify(FixConstants.ERROR_IN_DELETEPHYSICAL);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> DeleteUserLogicAsync(long id)
    {
        try
        {
            User user = _iUserRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(user))
            {
                user.UpdateDate = user.GetNewUpdateDate();
                user.Status = false;
                _iUserRepository.Update(user);
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

    public async Task<bool> CanDeleteUserByIdAsync(long id)
    {
        try
        {
            return await _iUserRepository.CanDelete(id);
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_DELETEPHYSICAL);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> ReactiveUserByIdAsync(long id)
    {
        try
        {
            User user = _iUserRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(user))
            {
                user.UpdateDate = user.GetNewUpdateDate();
                user.Status = true;
                _iUserRepository.Update(user);
                return true;
            }

            return false;
        }
        catch (Exception)
        {
            Notify(FixConstants.ERROR_IN_ACTIVERECORD);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<IEnumerable<UserExcelDTO>> ExportData(UserFilter filter)
    {
        var list = await GetAllUserPaginateAsync(filter);

        if (list?.Results?.Count() > 0)
        {
            return _iMapperService.ApplyMapToEntity<IEnumerable<UserResponseDTO>,IEnumerable<UserExcelDTO>>(list.Results);
        }

        return Enumerable.Empty<UserExcelDTO>();
    }
}
