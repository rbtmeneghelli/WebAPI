using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Models;
using WebAPI.Domain.ValueObject;

namespace WebAPI.Application.Interfaces
{
    public interface ICepService
    {
        Task RefreshCepAsync(RefreshCep refreshCep);
        Task<Domain.ValueObject.AddressData> GetByCepAsync(string cep);
        Task<bool> UpdateStatusByIdAsync(long id);
        Task<IEnumerable<Domain.ValueObject.AddressData>> GetAllWithLikeAsync(string paremeter);
        Task<PagedResult<Domain.ValueObject.AddressData>> GetAllWithPaginateAsync(CepFilter filter);
    }
}
