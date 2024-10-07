namespace TestsWebAPI.Data.Context;

public static class ModelBuilderExtensions
{
    public static void ExecuteSeed(this ModelBuilder modelBuilder)
    {
        SeedUser(modelBuilder);
    }

    private static void SeedUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthenticateEntity>().HasData(new AuthenticateEntity()
        {
            Id = 1,
            Token = string.Empty,
            Data = FixConstants.GetDateTimeNowFromBrazil(),
            InitialHour = null,
            FinalHour = null
        });
    }
}
