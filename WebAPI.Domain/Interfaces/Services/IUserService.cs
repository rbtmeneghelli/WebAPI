
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.EntitiesDTO.ControlPanel;
using WebAPI.Domain.Filters.ControlPanel;
using WebAPI.Domain.Models;

namespace WebAPI.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserResponseDTO>> GetAllAsync();
    Task<PagedResult<UserResponseDTO>> GetAllPaginateAsync(UserFilter filter);
    Task<UserResponseDTO> GetByIdAsync(long id);
    Task<UserResponseDTO> GetByLoginAsync(string login);
    Task<IEnumerable<DropDownList>> GetUsersAsync();
    Task<bool> AddAsync(User user);
    Task<bool> UpdateAsync(long id, User user);
    Task<bool> DeletePhysicalAsync(long id);
    Task<bool> DeleteLogicAsync(long id);
    Task<bool> ExistByIdAsync(long id);
    Task<bool> CanDeleteAsync(long id);
    Task<bool> ReactiveUserAsync(long id);
    Task<bool> ExistByLoginAsync(string login);
}
