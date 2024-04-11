namespace TestsWebAPI.Data.Context;

public class WebAPITestContext : DbContext
{
    public WebAPITestContext(DbContextOptions<WebAPITestContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebAPITestContext).Assembly);
        modelBuilder.ApplyConfiguration(new AuthenticateMapping());
        modelBuilder.ExecuteSeed();
        base.OnModelCreating(modelBuilder);
    }

    public new DbSet<T> Set<T>() where T : class
    {
        return base.Set<T>();
    }

    public virtual DbSet<AuthenticateEntity> Authenticates { get; set; }
}
