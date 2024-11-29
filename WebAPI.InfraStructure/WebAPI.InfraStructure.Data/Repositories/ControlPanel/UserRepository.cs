using WebAPI.Domain.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Generic;

namespace WebAPI.InfraStructure.Data.Repositories.ControlPanel;

public class UserRepository : IUserRepository
{
    private readonly IReadRepository<User> _iUserReadRepository;
    private readonly IWriteRepository<User> _iUserWriteRepository;
    private readonly IReadRepository<Employee> _iEmployeeReadRepository;
    private readonly IReadRepository<Profile> _iProfileReadRepository;

    public UserRepository(
        IReadRepository<User> iUserReadRepository,
        IWriteRepository<User> iUserWriteRepository,
        IReadRepository<Employee> iEmployeeReadRepository,
        IReadRepository<Profile> iProfileReadRepository)
    {
        _iUserReadRepository = iUserReadRepository;
        _iUserWriteRepository = iUserWriteRepository;
        _iEmployeeReadRepository = iEmployeeReadRepository;
        _iProfileReadRepository = iProfileReadRepository;
    }

    #region Operações CRUD

    public IQueryable<User> GetAll(bool hasTracking = false)
    {
        return _iUserReadRepository.GetAll(hasTracking);
    }

    public IQueryable<User> GetAllIgnoreQueryFilter(bool hasTracking = false)
    {
        return _iUserReadRepository.GetAllIgnoreQueryFilter(hasTracking);
    }

    public IQueryable<User> FindBy(Expression<Func<User, bool>> predicate)
    {
        return _iUserReadRepository.FindBy(predicate);
    }

    public IQueryable<User> FindByIgnoreQueryFilter(Expression<Func<User, bool>> predicate)
    {
        return _iUserReadRepository.FindByIgnoreQueryFilter(predicate);
    }

    public User GetById(long id)
    {
        return _iUserReadRepository.GetById(id);
    }

    public void Update(User user)
    {
        _iUserWriteRepository.Update(user);
    }

    public bool Exist(Expression<Func<User, bool>> predicate)
    {
        return _iUserReadRepository.Exist(predicate);
    }

    public void Add(User user)
    {
        _iUserWriteRepository.Create(user);
    }

    public void Remove(User user)
    {
        _iUserWriteRepository.Remove(user);
    }

    #endregion

    public async Task<User> GetUserCredentialsById(long id)
    {
        return await _iUserReadRepository.GetAllInclude("Employee.Profile.ProfileOperations.Operation", true).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<User> GetUserCredentialsByLogin(string login)
    {
        return await _iUserReadRepository.GetAllInclude("Employee.Profile.ProfileOperations.Operation", true).FirstOrDefaultAsync(p => p.Login == login.ApplyTrim());
    }

    public async Task<bool> CanDelete(long userId)
    {
        return await Task.FromResult(Exist(x => x.Id == userId));
    }

    #region Operações de junções

    public async Task<IEnumerable<User>> UserProfileJoinLinq()
    {
        return await (from _user in _iUserReadRepository.GetAll()
                      join _employee in _iEmployeeReadRepository.GetAll()
                      on _user.Id equals _employee.IdUser
                      join _profile in _iProfileReadRepository.GetAll()
                      on _employee.IdProfile equals _profile.Id
                      select new User
                      {
                          Id = _user.Id,
                          Login = _user.Login
                      }).ToListAsync();
    }

    public async Task<IEnumerable<User>> UserProfileJoinLinqAndLambda()
    {
        return await _iUserReadRepository.GetAll()
               .Join(
                    _iEmployeeReadRepository.GetAll(),
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
        return await (from _user in _iUserReadRepository.GetAll()
                      join _employee in _iEmployeeReadRepository.GetAll()
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
        return await (from _employee in _iEmployeeReadRepository.GetAll()
                      join _user in _iUserReadRepository.GetAll()
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
