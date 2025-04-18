using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.Filters.ControlPanel;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Application.Services;

public sealed class UserService : BaseHandlerService, IUserService
{
    private readonly IUserRepository _iUserRepository;
    private readonly IMapperService _iMapperService;

    public UserService(
        IUserRepository iUserRepository,
        INotificationMessageService iNotificationMessageService,
        IMapperService iMapperService) : base(iNotificationMessageService)
    {
        _iUserRepository = iUserRepository;
        _iMapperService = iMapperService; ;
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
            (GuardClauseExtension.IsNullOrWhiteSpace(filter.Login) || p.Login.StartsWith(filter.Login.ApplyTrim()))
            &&
            (!filter.IsAuthenticated.HasValue || filter.IsAuthenticated == p.IsAuthenticated)
            &&
            (!filter.IsActive.HasValue || filter.IsActive == p.IsActive)
            &&
            (!filter.IdProfile.HasValue || filter.IdProfile == p.Employee.IdProfile);
        else
            return p =>
            (GuardClauseExtension.IsNullOrWhiteSpace(filter.Login) || p.Login.StartsWith(filter.Login.ApplyTrim()))
            &&
            (!filter.IsAuthenticated.HasValue || filter.IsAuthenticated == p.IsAuthenticated)
            &&
            (!filter.IdProfile.HasValue || filter.IdProfile == p.Employee.IdProfile);
    }

    public async Task<IEnumerable<UserResponseDTO>> GetAllUserAsync()
    {
        var data = await (from p in _iUserRepository.GetAll().Include(x => x.Employee).ThenInclude(x => x.Profile)
                          orderby p.Login ascending
                          select p).ToListAsync();

        return _iMapperService.ApplyMapToEntity<IEnumerable<User>, IEnumerable<UserResponseDTO>>(data);
    }

    public async Task<BasePagedResultModel<UserResponseDTO>> GetAllUserPaginateAsync(UserFilter filter)
    {
        var query = GetAllUsers(filter);

        var queryResult = await Task.FromResult(from p in query.AsQueryable()
                                                orderby p.Login ascending
                                                select p);

        var data = _iMapperService.ApplyMapToEntity<IEnumerable<User>, IEnumerable<UserResponseDTO>>(queryResult);

        return BasePagedResultService.GetPaged(data.AsQueryable(), BasePagedResultService.GetDefaultPageIndex(filter.PageIndex), BasePagedResultService.GetDefaultPageSize(filter.PageSize));
    }

    public async Task<UserResponseDTO> GetUserByIdAsync(long id)
    {
        var data = await (from p in _iUserRepository.FindBy(x => x.Id == id).AsQueryable()
                          orderby p.Login ascending
                          select p).FirstOrDefaultAsync();

        return _iMapperService.ApplyMapToEntity<User, UserResponseDTO>(data);
    }

    public async Task<UserResponseDTO> GetUserByLoginAsync(string login)
    {
        var data = await (from p in _iUserRepository.FindBy(x => x.Login == login.ApplyTrim()).AsQueryable()
                          orderby p.Login ascending
                          select p).FirstOrDefaultAsync();

        return _iMapperService.ApplyMapToEntity<User, UserResponseDTO>(data);
    }

    public async Task<IEnumerable<DropDownListModel>> GetUsersAsync()
    {
        var result = _iUserRepository.FindBy(x => x.IsAuthenticated == true)
                     .Select(x => new DropDownListModel()
                     {
                         Id = x.Id.Value,
                         Description = x.Login
                     }).AsEnumerable();

        await Task.CompletedTask;

        return result;
    }

    public async Task<bool> ExistUserByIdAsync(long id)
    {
        var result = _iUserRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> ExistUserByLoginAsync(string login)
    {
        if (GuardClauseExtension.IsNullOrWhiteSpace(login))
        {
            return false;
        }

        var result = _iUserRepository.Exist(x => x.Login == login.ApplyTrim());
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateUserAsync(UserRequestDTO userRequestDTO)
    {
        User user = _iMapperService.ApplyMapToEntity<UserRequestDTO, User>(userRequestDTO);

        if (GuardClauseExtension.IsNullOrWhiteSpace(user.Login) || GuardClauseExtension.IsNullOrWhiteSpace(user.Password))
        {
            Notify("Para realizar o cadastro do login, o campo login e senha deve ser preenchido");
            return false;
        }

        else if (_iUserRepository.Exist(x => x.Login == user.Login) == false)
        {
            user.Password = new HashingManager().HashToString(user.Password);
            _iUserRepository.Add(user);
            return true;
        }

        Notify($"Já existe um login {user.Login} cadastrado, troque de login");
        return false;
    }

    public async Task<bool> UpdateUserAsync(long id, UserRequestDTO userRequestDTO)
    {
        User user = _iMapperService.ApplyMapToEntity<UserRequestDTO, User>(userRequestDTO);
        User userDb = _iUserRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(userDb))
        {
            userDb.LastPassword = userDb.Password;
            userDb.Password = new HashingManager().HashToString(user.Password);
            userDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            _iUserRepository.Update(userDb);
            return true;
        }

        Notify(FixConstants.ERROR_IN_UPDATE);
        return false;
    }

    public async Task<bool> DeleteUserPhysicalAsync(long id)
    {
        User user = _iUserRepository.GetById(id);

        if (GuardClauseExtension.IsNull(user) == false)
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

    public async Task<bool> DeleteUserLogicAsync(long id)
    {
        User user = _iUserRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(user))
        {
            user.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            user.IsActive = false;
            _iUserRepository.Update(user);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
    }

    public async Task<bool> CanDeleteUserByIdAsync(long id)
    {
        return await _iUserRepository.CanDelete(id);
    }

    public async Task<bool> ReactiveUserByIdAsync(long id)
    {
        User user = _iUserRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(user))
        {
            user.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            user.IsActive = true;
            _iUserRepository.Update(user);
            return true;
        }

        return false;
    }

    public async Task<IEnumerable<UserExcelDTO>> ExportData(UserFilter filter)
    {
        var list = await GetAllUserPaginateAsync(filter);

        if (list?.Results?.Count() > 0)
        {
            return _iMapperService.ApplyMapToEntity<IEnumerable<UserResponseDTO>, IEnumerable<UserExcelDTO>>(list.Results);
        }

        return Enumerable.Empty<UserExcelDTO>();
    }
}
