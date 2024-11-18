
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.Filters.ControlPanel;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<UserResponseDTO>> GetAllUserAsync();
    Task<PagedResult<UserResponseDTO>> GetAllUserPaginateAsync(UserFilter filter);
    Task<UserResponseDTO> GetUserByIdAsync(long id);
    Task<UserResponseDTO> GetUserByLoginAsync(string login);
    Task<IEnumerable<DropDownList>> GetUsersAsync();
    Task<bool> CreateUserAsync(User user);
    Task<bool> UpdateUserAsync(long id, User user);
    Task<bool> DeleteUserPhysicalAsync(long id);
    Task<bool> DeleteUserLogicAsync(long id);
    Task<bool> ExistUserByIdAsync(long id);
    Task<bool> CanDeleteUserByIdAsync(long id);
    Task<bool> ReactiveUserByIdAsync(long id);
    Task<bool> ExistUserByLoginAsync(string login);
}
