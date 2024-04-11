namespace TestsWebAPI.Data.Repositories
{
    public class GenericRepositoryTest<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly WebAPITestContext _context;
        protected readonly DbSet<TEntity> DbSet;

        protected GenericRepositoryTest(WebAPITestContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll(bool hasTracking = false)
        {
            if (hasTracking)
                return DbSet;

            return DbSet.AsNoTracking();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, bool hasTracking = false)
        {
            if (hasTracking)
                return DbSet.Where(predicate);

            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual TEntity GetById(long id)
        {
            var result = DbSet.Find(id);
            _context.Entry(result).State = EntityState.Detached;
            return result;
        }

        public virtual bool ExistAnyRecord()
        {
            return DbSet.AsNoTracking().Any();
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                DbSet.Add(entity);
                SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                DbSet.Update(entity);
                SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public virtual long SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
