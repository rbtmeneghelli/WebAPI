using System.Linq.Expressions;
using WebAPI.Domain.ValueObject;

namespace WebAPI.Domain.Interfaces.Repository;

public interface ICepRepository
{
    IQueryable<AddressData> GetAll(bool hasTracking = false);
    void Update(AddressData ceps);
    void Add(AddressData ceps);
    IQueryable<AddressData> FindBy(Expression<Func<AddressData, bool>> predicate, bool hasTracking = false);
    AddressData GetById(long id);
}
