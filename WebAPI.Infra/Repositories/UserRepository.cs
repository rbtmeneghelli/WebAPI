using WebAPI.Domain.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IGenericRepository<Employee> _employeeRepository;
    private readonly IGenericRepository<Profile> _profileRepository;

    public UserRepository(IGenericRepository<User> userRepository, IGenericRepository<Employee> employeeRepository, IGenericRepository<Profile> profileRepository)
    {
        _userRepository = userRepository;
        _employeeRepository = employeeRepository;
        _profileRepository = profileRepository;
    }

    #region Operações CRUD

    public IQueryable<User> GetAll(bool hasTracking = false)
    {
        return _userRepository.GetAll(hasTracking);
    }

    public IQueryable<User> GetAllIgnoreQueryFilter(bool hasTracking = false)
    {
        return _userRepository.GetAllIgnoreQueryFilter(hasTracking);
    }

    public IQueryable<User> FindBy(Expression<Func<User, bool>> predicate)
    {
        return _userRepository.FindBy(predicate);
    }

    public IQueryable<User> FindByIgnoreQueryFilter(Expression<Func<User, bool>> predicate)
    {
        return _userRepository.FindByIgnoreQueryFilter(predicate);
    }

    public User GetById(long id)
    {
        return _userRepository.GetById(id);
    }

    public void Update(User user)
    {
        _userRepository.Update(user);
    }

    public bool Exist(Expression<Func<User, bool>> predicate)
    {
        return _userRepository.Exist(predicate);
    }

    public void Add(User user)
    {
        _userRepository.Add(user);
    }

    public void Remove(User user)
    {
        _userRepository.Remove(user);
    }

    #endregion

    public async Task<User> GetUserCredentialsById(long id)
    {
        return await _userRepository.GetAllInclude("Employee.Profile.ProfileOperations.Operation", true).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<User> GetUserCredentialsByLogin(string login)
    {
        return await _userRepository.GetAllInclude("Employee.Profile.ProfileOperations.Operation", true).FirstOrDefaultAsync(p => p.Login == login.ApplyTrim());
    }

    public async Task<bool> CanDelete(long userId)
    {
        return await Task.FromResult(Exist(x => x.Id == userId));
    }

    #region Operações de junções

    public async Task<IEnumerable<User>> UserProfileJoinLinq()
    {
        return await (from _user in _userRepository.GetAll()
                      join _employee in _employeeRepository.GetAll()
                      on _user.Id equals _employee.IdUser
                      join _profile in _profileRepository.GetAll()
                      on _employee.IdProfile equals _profile.Id
                      select new User
                      {
                          Id = _user.Id,
                          Login = _user.Login
                      }).ToListAsync();
    }

    public async Task<IEnumerable<User>> UserProfileJoinLinqAndLambda()
    {
        return await _userRepository.GetAll()
               .Join(
                    _employeeRepository.GetAll(),
                    _user => _user.Id,
                    _employee => _employee.IdUser,
                    (_user, _employee) => new User
                    {
                        Id = _user.Id,
                        Login = _user.Login
                    }).ToListAsync();
    }

    public async Task<IEnumerable<User>> UserProfileLeftJoinLinq()
    {
        return await (from _user in _userRepository.GetAll()
                      join _employee in _employeeRepository.GetAll()
                      on _user.Id equals _employee.IdUser
                      into _userEmployeeJoin
                      from _userEmployeeResult in _userEmployeeJoin.DefaultIfEmpty()
                      select new User
                      {
                          Id = _user.Id,
                          Login = _user.Login,
                      }).ToListAsync();
    }

    public async Task<IEnumerable<User>> UserProfileRightJoinLinq()
    {
        return await (from _employee in _employeeRepository.GetAll()
                      join _user in _userRepository.GetAll()
                      on _employee.IdUser equals _user.Id
                      into _userEmployeeJoin
                      from _userEmployeeResult in _userEmployeeJoin.DefaultIfEmpty()
                      select new User
                      {
                          Id = _userEmployeeResult.Id,
                          Login = _userEmployeeResult.Login,
                      }).ToListAsync();
    }

    public async Task<IEnumerable<User>> UserProfileFullJoinLinq()
    {
        var _userResultLeftJoin = await UserProfileLeftJoinLinq();
        var _userResultRightJoin = await UserProfileRightJoinLinq();
        var _userResultFullJoin = _userResultLeftJoin.Union(_userResultRightJoin).ToList();
        return _userResultFullJoin;
    }

    #endregion
}
