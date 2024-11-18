using WebAPI.Domain.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.InfraStructure.Data.Repositories.ControlPanel;

public class UserRepository : IUserRepository
{
    private readonly IGenericRepository<User> _iUserRepository;
    private readonly IGenericRepository<Employee> _iEmployeeRepository;
    private readonly IGenericRepository<Profile> _iProfileRepository;

    public UserRepository(IGenericRepository<User> iUserRepository, IGenericRepository<Employee> iEmployeeRepository, IGenericRepository<Profile> iProfileRepository)
    {
        _iUserRepository = iUserRepository;
        _iEmployeeRepository = iEmployeeRepository;
        _iProfileRepository = iProfileRepository;
    }

    #region Operações CRUD

    public IQueryable<User> GetAll(bool hasTracking = false)
    {
        return _iUserRepository.GetAll(hasTracking);
    }

    public IQueryable<User> GetAllIgnoreQueryFilter(bool hasTracking = false)
    {
        return _iUserRepository.GetAllIgnoreQueryFilter(hasTracking);
    }

    public IQueryable<User> FindBy(Expression<Func<User, bool>> predicate)
    {
        return _iUserRepository.FindBy(predicate);
    }

    public IQueryable<User> FindByIgnoreQueryFilter(Expression<Func<User, bool>> predicate)
    {
        return _iUserRepository.FindByIgnoreQueryFilter(predicate);
    }

    public User GetById(long id)
    {
        return _iUserRepository.GetById(id);
    }

    public void Update(User user)
    {
        _iUserRepository.Update(user);
    }

    public bool Exist(Expression<Func<User, bool>> predicate)
    {
        return _iUserRepository.Exist(predicate);
    }

    public void Add(User user)
    {
        _iUserRepository.Create(user);
    }

    public void Remove(User user)
    {
        _iUserRepository.Remove(user);
    }

    #endregion

    public async Task<User> GetUserCredentialsById(long id)
    {
        return await _iUserRepository.GetAllInclude("Employee.Profile.ProfileOperations.Operation", true).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<User> GetUserCredentialsByLogin(string login)
    {
        return await _iUserRepository.GetAllInclude("Employee.Profile.ProfileOperations.Operation", true).FirstOrDefaultAsync(p => p.Login == login.ApplyTrim());
    }

    public async Task<bool> CanDelete(long userId)
    {
        return await Task.FromResult(Exist(x => x.Id == userId));
    }

    #region Operações de junções

    public async Task<IEnumerable<User>> UserProfileJoinLinq()
    {
        return await (from _user in _iUserRepository.GetAll()
                      join _employee in _iEmployeeRepository.GetAll()
                      on _user.Id equals _employee.IdUser
                      join _profile in _iProfileRepository.GetAll()
                      on _employee.IdProfile equals _profile.Id
                      select new User
                      {
                          Id = _user.Id,
                          Login = _user.Login
                      }).ToListAsync();
    }

    public async Task<IEnumerable<User>> UserProfileJoinLinqAndLambda()
    {
        return await _iUserRepository.GetAll()
               .Join(
                    _iEmployeeRepository.GetAll(),
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
        return await (from _user in _iUserRepository.GetAll()
                      join _employee in _iEmployeeRepository.GetAll()
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
        return await (from _employee in _iEmployeeRepository.GetAll()
                      join _user in _iUserRepository.GetAll()
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
