using WebAPI.Application.Factory;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Cryptography;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.EntitiesDTO.ControlPanel;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Filters.ControlPanel;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services;

public class UserService : GenericService, IUserService
{
    private readonly IUserRepository _iUserRepository;

    public UserService(IUserRepository iUserRepository, INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
    {
        _iUserRepository = iUserRepository;
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

    public async Task<IEnumerable<UserResponseDTO>> GetAllAsync()
    {
        try
        {
            return await (from p in _iUserRepository.GetAll().Include(x => x.Employee).ThenInclude(x => x.Profile)
                          orderby p.Login ascending
                          select new UserResponseDTO()
                          {
                              Id = p.Id,
                              Login = p.Login,
                              IsAuthenticated = p.IsAuthenticated,
                              IsActive = p.Status,
                              Password = "-",
                              LastPassword = "-",
                              Employee = p.Employee.Name,
                              Profile = p.Employee.Profile.Description,
                              Status = p.GetStatusDescription(),
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<UserResponseDTO>().ToList();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<PagedResult<UserResponseDTO>> GetAllPaginateAsync(UserFilter filter)
    {
        try
        {
            var query = GetAllUsers(filter);

            var queryResult = from p in query.AsQueryable()
                              orderby p.Login ascending
                              select new UserResponseDTO
                              {
                                  Id = p.Id,
                                  Login = p.Login,
                                  IsAuthenticated = p.IsAuthenticated,
                                  IsActive = p.Status,
                                  Password = "-",
                                  LastPassword = "-",
                                  Profile = p.Employee.Profile.Description,
                                  Status = p.GetStatusDescription(),
                              };

            return PagedFactory.GetPaged(queryResult, PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
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

    public async Task<UserResponseDTO> GetByIdAsync(long id)
    {
        try
        {
            return await (from p in _iUserRepository.FindBy(x => x.Id == id).AsQueryable()
                          orderby p.Login ascending
                          select new UserResponseDTO
                          {
                              Id = p.Id,
                              Login = p.Login,
                              IsAuthenticated = p.IsAuthenticated,
                              IsActive = p.Status,
                              Password = "-",
                              LastPassword = "-",
                              Status = p.GetStatusDescription(),
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

    public async Task<UserResponseDTO> GetByLoginAsync(string login)
    {
        try
        {
            return await (from p in _iUserRepository.FindBy(x => x.Login == login.ApplyTrim()).AsQueryable()
                          orderby p.Login ascending
                          select new UserResponseDTO
                          {
                              Id = p.Id,
                              Login = p.Login,
                              IsAuthenticated = p.IsAuthenticated,
                              IsActive = p.Status,
                              Password = "-",
                              LastPassword = "-",
                              Profile = p.Employee.Profile.Description,
                              Status = p.GetStatusDescription(),
                          }).FirstOrDefaultAsync();
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

    public async Task<bool> ExistByIdAsync(long id)
    {
        try
        {
            var result = _iUserRepository.Exist(x => x.Id == id);

            if (result == false)
                Notify(FixConstants.ERROR_IN_GETID);

            return result;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETID);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> ExistByLoginAsync(string login)
    {
        try
        {
            if (GuardClauses.IsNullOrWhiteSpace(login))
            {
                Notify("O campo login está em branco, por favor preencha!");
                return false;
            }

            var result = _iUserRepository.Exist(x => x.Login == login.ApplyTrim());

            if (result == false)
                Notify("Ocorreu um erro para pesquisar o registro do login solicitado. Entre em contato com o Administrador");

            return result;
        }
        catch
        {
            Notify("Ocorreu um erro para pesquisar o registro do login solicitado. Entre em contato com o Administrador");
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> AddAsync(User user)
    {
        try
        {
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

    public async Task<bool> UpdateAsync(long id, User user)
    {
        try
        {
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

    public async Task<bool> DeletePhysicalAsync(long id)
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

    public async Task<bool> DeleteLogicAsync(long id)
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

    public async Task<bool> CanDeleteAsync(long id)
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

    public async Task<bool> ReactiveUserAsync(long id)
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
}
