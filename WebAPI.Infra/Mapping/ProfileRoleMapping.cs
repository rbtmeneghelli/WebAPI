using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.Infra.Data.Mapping;


public class ProfileOperationMapping : IEntityTypeConfiguration<ProfileOperation>
{
    private EntityTypeBuilder<ProfileOperation> _builder;

    public void Configure(EntityTypeBuilder<ProfileOperation> builder)
    {
        _builder = builder;
        _builder.ToTable("ProfileOperations");
        ConfigurePrimaryKey();
        ConfigureColumns();
        ConfigureForeignKeys();
        ConfigureIndexes();
    }

    private void ConfigureColumns()
    {
        _builder.Property(a => a.IdProfile).IsRequired(true).HasColumnName("Id_Profile");
        _builder.Property(a => a.IdOperation).IsRequired(true).HasColumnName("Id_Operation");
        _builder.Property(a => a.Order).IsRequired(true).HasColumnName("CanCreate");
        _builder.Property(a => a.IsEnable).IsRequired(true).HasDefaultValue(false).HasColumnName("CanResearch");
        _builder.Property(a => a.RoleTag).IsRequired(true).HasMaxLength(255).HasColumnName("CanUpdate");
    }

    private void ConfigureForeignKeys()
    {
        _builder.HasOne(a => a.Profile)
            .WithMany(a => a.ProfileOperations)
            .HasForeignKey(a => a.IdProfile);

        _builder.HasOne(a => a.Operation)
            .WithMany(a => a.ProfileOperations)
            .HasForeignKey(a => a.IdOperation);
    }

    private void ConfigureIndexes()
    {
        _builder.HasIndex(a =>
            new
            {
                a.IdProfile,
                a.IdOperation
            })
            .IsUnique(true);
    }

    private void ConfigurePrimaryKey()
    {
        _builder.HasKey(a => new
        {
            a.IdProfile,
            a.IdOperation
        });
    }
}