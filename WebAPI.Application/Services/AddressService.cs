using FastPackForShare.Default;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.ValueObject;

namespace WebAPI.Application.Services;

public sealed class AddressService : BaseHandlerService, IAddressService
{
    private readonly IAddressRepository _iAddressRepository;

    public AddressService(IAddressRepository iAddressRepository, INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
    {
        _iAddressRepository = iAddressRepository;
    }

    private async Task<IQueryable<Domain.ValueObject.AddressData>> GetAllWithFilterAsync(CepFilter filter)
    {
        return await Task.FromResult(_iAddressRepository.GetAll().Where(GetPredicateAsync(filter)).AsQueryable());
    }

    private async Task<int> GetCountAsync(CepFilter filter)
    {
        return await _iAddressRepository.GetAll().CountAsync(GetPredicateAsync(filter));
    }

    private Expression<Func<Domain.ValueObject.AddressData, bool>> GetPredicateAsync(CepFilter filter)
    {
        return p =>
               (GuardClauseExtension.IsNullOrWhiteSpace(filter.ZipPostalCode) || p.Cep.StartsWith(filter.ZipPostalCode.ApplyTrim()));
    }

    public async Task RefreshAddressAsync(RefreshCep refreshCep)
    {
        if (GuardClauseExtension.IsNotNull(refreshCep.ModelCep))
        {

            refreshCep.ModelCep = new Domain.ValueObject.AddressData(refreshCep.ModelCep.Id.Value, refreshCep.Cep, refreshCep.ModelCepAPI, refreshCep.ModelCep.StateId, refreshCep.ModelCep.CreateDate);
            _iAddressRepository.Update(refreshCep.ModelCep);
        }
        else
        {
            refreshCep.ModelCep = new Domain.ValueObject.AddressData(refreshCep.Cep, refreshCep.ModelCepAPI);
            _iAddressRepository.Add(refreshCep.ModelCep);
        }
    }

    public async Task<Domain.ValueObject.AddressData> GetAddressByCepAsync(string cep)
    {
        return await _iAddressRepository.FindBy(x => x.Cep == cep).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateAddressStatusByIdAsync(long id)
    {
        Domain.ValueObject.AddressData record = await Task.FromResult(_iAddressRepository.GetById(id));

        if (GuardClauseExtension.IsNotNull(record))
        {
            record.IsActive = record.IsActive == true ? false : true;
            _iAddressRepository.Update(record);
            return true;
        }

        return false;
    }

    public async Task<IEnumerable<AddressData>> GetAllAddressWithLikeAsync(string parameter)
    {
        return await _iAddressRepository.FindBy(x => EF.Functions.Like(x.Cep, $"%{parameter}%")).ToListAsync();
    }

    public async Task<BasePagedResultModel<AddressData>> GetAllAddressWithPaginateAsync(CepFilter filter)
    {
        var query = await GetAllWithFilterAsync(filter);
        var queryCount = await GetCountAsync(filter);

        var queryResult = from x in query.AsQueryable()
                          orderby x.Street ascending
                          select new Domain.ValueObject.AddressData
                          {
                              Id = x.Id,
                              Cep = x.Cep,
                              Street = x.Street,
                              District = x.District,
                              Complement = x.Complement,
                              Ddd = x.Ddd,
                              Uf = x.Uf,
                              Gia = x.Gia,
                              Ibge = x.Ibge,
                              Location = x.Location,
                              Siafi = x.Siafi,
                              IsActive = x.IsActive
                          };

        return BasePagedResultService.GetPaged(queryResult, BasePagedResultService.GetDefaultPageIndex(filter.PageIndex), BasePagedResultService.GetDefaultPageSize(filter.PageSize));
    }
}
