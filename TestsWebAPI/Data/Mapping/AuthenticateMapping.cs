namespace TestsWebAPI.Data.Mapping;

public class AuthenticateMapping : GenericMapping<AuthenticateEntity>
{
    public override void Configure(EntityTypeBuilder<AuthenticateEntity> builder)
    {
        _builder = builder;
        base.Configure(_builder);
        _builder.ToTable("Authenticate");
        ConfigureColumns();
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Token).IsRequired(false).HasMaxLength(1000).HasColumnName("Token");
    }
}
