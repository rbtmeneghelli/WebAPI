namespace WebAPI.Application.InterfacesRepository
{
    public interface IAuditRepository
    {
        IQueryable<Audit> GetAll(bool hasTracking = false);
        Audit GetById(long id);
        IQueryable<Audit> FindBy(Expression<Func<Audit, bool>> predicate, bool hasTracking = false);
        bool Exist(Expression<Func<Audit, bool>> predicate);
    }
}
