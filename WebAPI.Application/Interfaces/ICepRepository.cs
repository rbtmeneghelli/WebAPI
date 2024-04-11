using WebAPI.Domain.ValueObject;

namespace WebAPI.Application.Interfaces
{
    public interface ICepRepository
    {
        IQueryable<Domain.ValueObject.AddressData> GetAll(bool hasTracking = false);
        void Update(Domain.ValueObject.AddressData ceps);
        void Add(Domain.ValueObject.AddressData ceps);
        IQueryable<Domain.ValueObject.AddressData> FindBy(Expression<Func<Domain.ValueObject.AddressData, bool>> predicate, bool hasTracking = false);
        Domain.ValueObject.AddressData GetById(long id);
    }
}
