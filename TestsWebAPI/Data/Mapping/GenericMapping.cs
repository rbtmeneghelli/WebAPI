namespace TestsWebAPI.Data.Mapping;

public abstract class GenericMapping<T> : IEntityTypeConfiguration<T> where T : GenericEntity
{
    protected EntityTypeBuilder<AuthenticateEntity> _builder;

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn(1, 1).HasColumnName("Id");
        builder.Property(x => x.Data).IsRequired(false).HasColumnName("Data");
        builder.Property(x => x.HoraInicial).IsRequired(false).HasColumnName("HoraInicial");
        builder.Property(x => x.HoraFinal).IsRequired(false).HasColumnName("HoraFinal");
    }
}
