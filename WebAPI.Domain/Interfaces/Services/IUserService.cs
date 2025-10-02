using WebAPI.Domain.DTO.ControlPanel;
using FastPackForShare.Default;
using FastPackForShare.Models;
using WebAPI.Domain.Filters.ControlPanel.Users;

namespace WebAPI.Domain.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<UserResponseDTO>> GetAllUserAsync();
    Task<BasePagedResultModel<UserResponseDTO>> GetAllUserPaginateAsync(UserPaginateFilter filter);
    Task<UserResponseDTO> GetUserByIdAsync(long id);
    Task<UserResponseDTO> GetUserByLoginAsync(string login);
    Task<IEnumerable<DropDownListModel>> GetUsersAsync(UserFilter userFilter);
    Task<bool> CreateUserAsync(UserRequestCreateDTO userRequestCreateDTO);
    Task<bool> UpdateUserAsync(long id, UserRequestUpdateDTO userRequestUpdateDTO);
    Task<bool> DeleteUserPhysicalAsync(long id);
    Task<bool> DeleteUserLogicAsync(long id);
    Task<bool> ExistUserByIdAsync(long id);
    Task<bool> CanDeleteUserByIdAsync(long id);
    Task<bool> ReactiveUserByIdAsync(long id);
    Task<bool> ExistUserByLoginAsync(string login);
    Task<IEnumerable<UserExcelDTO>> ExportData(UserPaginateFilter filter);
}
