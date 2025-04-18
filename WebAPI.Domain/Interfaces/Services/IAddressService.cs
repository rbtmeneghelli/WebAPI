using FastPackForShare.Default;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface IAddressService
{
    Task RefreshAddressAsync(RefreshCep refreshCep);
    Task<Domain.ValueObject.AddressData> GetAddressByCepAsync(string cep);
    Task<bool> UpdateAddressStatusByIdAsync(long id);
    Task<IEnumerable<Domain.ValueObject.AddressData>> GetAllAddressWithLikeAsync(string paremeter);
    Task<BasePagedResultModel<AddressDataDTO>> GetAllAddressWithPaginateAsync(CepFilter filter);
}
