using WebAPI.Application.Factory;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.ValueObject;

namespace WebAPI.Application.Services;

public class AddressService : GenericService, IAddressService
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
               (GuardClauses.IsNullOrWhiteSpace(filter.Cep) || p.Cep.StartsWith(filter.Cep.ApplyTrim()));
    }

    public async Task RefreshAddressAsync(RefreshCep refreshCep)
    {
        try
        {
            if (GuardClauses.ObjectIsNotNull(refreshCep.ModelCep))
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
        catch
        {
            Notify(FixConstants.ERROR_IN_REFRESHCEP);
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<Domain.ValueObject.AddressData> GetAddressByCepAsync(string cep)
    {
        return await _iAddressRepository.FindBy(x => x.Cep == cep).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateAddressStatusByIdAsync(long id)
    {
        try
        {
            Domain.ValueObject.AddressData record = await Task.FromResult(_iAddressRepository.GetById(id));
            if (GuardClauses.ObjectIsNotNull(record))
            {
                record.Status = record.Status == true ? false : true;
                _iAddressRepository.Update(record);
                return true;
            }
            return false;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
    }

    public async Task<IEnumerable<AddressData>> GetAllAddressWithLikeAsync(string parameter)
    {
        return await _iAddressRepository.FindBy(x => EF.Functions.Like(x.Cep, $"%{parameter}%")).ToListAsync();
    }

    public async Task<PagedResult<AddressData>> GetAllAddressWithPaginateAsync(CepFilter filter)
    {
        try
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
                                  Status = x.Status
                              };

            return PagedFactory.GetPaged(queryResult, PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return PagedFactory.GetPaged(Enumerable.Empty<AddressData>().AsQueryable(), PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
        }
    }
}
