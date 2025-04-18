using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.Filters.ControlPanel;
using FastPackForShare.Default;
using FastPackForShare.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<UserResponseDTO>> GetAllUserAsync();
    Task<BasePagedResultModel<UserResponseDTO>> GetAllUserPaginateAsync(UserFilter filter);
    Task<UserResponseDTO> GetUserByIdAsync(long id);
    Task<UserResponseDTO> GetUserByLoginAsync(string login);
    Task<IEnumerable<DropDownListModel>> GetUsersAsync();
    Task<bool> CreateUserAsync(UserRequestDTO userRequestDTO);
    Task<bool> UpdateUserAsync(long id, UserRequestDTO userRequestDTO);
    Task<bool> DeleteUserPhysicalAsync(long id);
    Task<bool> DeleteUserLogicAsync(long id);
    Task<bool> ExistUserByIdAsync(long id);
    Task<bool> CanDeleteUserByIdAsync(long id);
    Task<bool> ReactiveUserByIdAsync(long id);
    Task<bool> ExistUserByLoginAsync(string login);
    Task<IEnumerable<UserExcelDTO>> ExportData(UserFilter filter);
}
