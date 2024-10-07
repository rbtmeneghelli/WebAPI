namespace TestsWebAPI.Data.Mapping;

public abstract class GenericMapping<T> : IEntityTypeConfiguration<T> where T : GenericEntity
{
    protected EntityTypeBuilder<AuthenticateEntity> _builder;

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn(1, 1).HasColumnName("Id");
        builder.Property(x => x.Data).IsRequired(false).HasColumnName("Date");
        builder.Property(x => x.InitialHour).IsRequired(false).HasColumnName("InitialHour");
        builder.Property(x => x.FinalHour).IsRequired(false).HasColumnName("FinalHour");
    }
}
