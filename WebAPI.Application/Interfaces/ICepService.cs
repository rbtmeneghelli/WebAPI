using WebAPI.Domain.ValueObject;

namespace WebAPI.Application.Interfaces
{
    public interface ICepService
    {
        Task RefreshCepAsync(RefreshCep refreshCep);
        Task<Domain.ValueObject.AddressData> GetByCepAsync(string cep);
        Task<bool> UpdateStatusByIdAsync(long id);
        Task<List<Domain.ValueObject.AddressData>> GetAllWithLikeAsync(string parametro);
        Task<PagedResult<Domain.ValueObject.AddressData>> GetAllWithPaginateAsync(CepFilter filter);
    }
}
