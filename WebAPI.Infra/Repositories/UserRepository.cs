using WebAPI.Domain.Entities;
using WebAPI.Domain.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Application.Generic;

namespace WebAPI.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IGenericRepository<Profile> _profileRepository;

    public UserRepository(IGenericRepository<User> userRepository, IGenericRepository<Profile> profileRepository)
    {
        _userRepository = userRepository;
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
        return await _userRepository.GetAllInclude("Profile.ProfileOperations.Operation.Roles", true).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<User> GetUserCredentialsByLogin(string login)
    {
        return await _userRepository.GetAllInclude("Profile.ProfileOperations.Operation.Roles", true).FirstOrDefaultAsync(p => p.Login == login.ApplyTrim());
    }

    public async Task<bool> CanDelete(long userId)
    {
        return await Task.FromResult(Exist(x => x.Id == userId && x.Profile != null));
    }

    #region Operações de junções

    public async Task<IEnumerable<User>> UserProfileJoinLinq()
    {
        return await (from _user in _userRepository.GetAll()
                      join _profile in _profileRepository.GetAll()
                      on _user.IdProfile equals _profile.Id
                      select new User
                      {
                          Id = _user.Id,
                          Login = _user.Login,
                          IdProfile = _profile.Id.GetValueOrDefault(0)
                      }).ToListAsync();
    }

    public async Task<IEnumerable<User>> UserProfileJoinLinqAndLambda()
    {
        return await _userRepository.GetAll()
               .Join(
                    _profileRepository.GetAll(),
                    _user => _user.IdProfile,
                    _profile => _profile.Id,
                    (_user, _profile) => new User
                    {
                        Id = _user.Id,
                        Login = _user.Login,
                        IdProfile = _profile.Id.GetValueOrDefault(0)
                    }).ToListAsync();
    }

    public async Task<IEnumerable<User>> UserProfileLeftJoinLinq()
    {
        return await (from _user in _userRepository.GetAll()
                      join _profile in _profileRepository.GetAll()
                      on _user.IdProfile equals _profile.Id
                      into _userProfileJoin
                      from _userProfileResult in _userProfileJoin.DefaultIfEmpty()
                      select new User
                      {
                          Id = _user.Id,
                          Login = _user.Login,
                          IdProfile = _userProfileResult.Id.GetValueOrDefault(0)
                      }).ToListAsync();
    }

    public async Task<IEnumerable<User>> UserProfileRightJoinLinq()
    {
        return await (from _profile in _profileRepository.GetAll()
                      join _user in _userRepository.GetAll()
                      on _profile.Id equals _user.IdProfile
                      into _userProfileJoin
                      from _userProfileResult in _userProfileJoin.DefaultIfEmpty()
                      select new User
                      {
                          Id = _userProfileResult.Id,
                          Login = _userProfileResult.Login,
                          IdProfile = _profile.Id.GetValueOrDefault(0)
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
