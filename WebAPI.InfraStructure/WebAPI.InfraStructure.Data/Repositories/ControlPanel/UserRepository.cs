using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Generic;
using FastPackForShare.Extensions;
using Microsoft.EntityFrameworkCore.Internal;

namespace WebAPI.InfraStructure.Data.Repositories.ControlPanel;

public class UserRepository : IUserRepository
{
    private readonly IGenericReadRepository<User> _iUserReadRepository;
    private readonly IGenericWriteRepository<User> _iUserWriteRepository;
    private readonly IGenericReadRepository<Employee> _iEmployeeReadRepository;
    private readonly IGenericReadRepository<Profile> _iProfileReadRepository;

    public UserRepository(
        IGenericReadRepository<User> iUserReadRepository,
        IGenericWriteRepository<User> iUserWriteRepository,
        IGenericReadRepository<Employee> iEmployeeReadRepository,
        IGenericReadRepository<Profile> iProfileReadRepository)
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
        return _iUserReadRepository.GetByPredicate(predicate);
    }

    public IQueryable<User> FindByIgnoreQueryFilter(Expression<Func<User, bool>> predicate)
    {
        return _iUserReadRepository.GetByPredicateIgnoreQueryFilter(predicate);
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

    #region Aplicação do LEFT ou RIGHT JOIN, ANTES DO NET 10

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

    #endregion

    #region Aplicação do LEFT ou RIGHT JOIN, A PARTIR DO NET 10

    //public async Task<IEnumerable<User>> UserProfileLeftJoinLinqNET10()
    //{
    //    var userSet = _iUserReadRepository.GetAll();
    //    var employeeSet = _iEmployeeReadRepository.GetAll();

    //    var query = await Task.FromResult(userSet
    //                                      .LeftJoin(
    //                                      employeeSet,
    //                                      _user => _user.Id,
    //                                      _employee => _employee.IdUser,
    //                                      (_user, _employee) => new User { Id = _user.Id, Login = _user.Login }
    //                                      ));

    //    return query?.ToList() ?? Enumerable.Empty<User>();
    //}

    //public async Task<IEnumerable<User>> UserProfileRightJoinLinqNET10()
    //{
    //    var userSet = _iUserReadRepository.GetAll();
    //    var employeeSet = _iEmployeeReadRepository.GetAll();

    //    var query = await Task.FromResult(employeeSet
    //                                      .RightJoin(
    //                                      userSet,
    //                                      _employee => _employee.IdUser,
    //                                      _user => _user.Id,
    //                                      (_employee, _user) => new User { Id = _user?.Id, Login = _user?.Login }
    //                                      ));

    //    return query?.ToList() ?? Enumerable.Empty<User>();
    //}

    #endregion

    public async Task<IEnumerable<User>> UserProfileFullJoinLinq()
    {
        var _userResultLeftJoin = await UserProfileLeftJoinLinq();
        var _userResultRightJoin = await UserProfileRightJoinLinq();
        var _userResultFullJoin = _userResultLeftJoin.Union(_userResultRightJoin).ToList();
        return _userResultFullJoin;
    }

    #endregion
}
