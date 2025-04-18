using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.InfraStructure.Data.Mapping.ControlPanel;

public class ProfileOperationMapping : IEntityTypeConfiguration<ProfileOperation>
{
    private EntityTypeBuilder<ProfileOperation> _builder;

    public void Configure(EntityTypeBuilder<ProfileOperation> builder)
    {
        _builder = builder;
        _builder.ToTable("ControlPanel_ProfileOperations");
        ConfigurePrimaryKey();
        ConfigureColumns();
        ConfigureForeignKeys();
        ConfigureIndexes();
    }

    public void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn(1, 1).HasColumnName("Id");
        _builder.Property(a => a.IdProfile).IsRequired(true).HasColumnName("IdProfile");
        _builder.Property(a => a.IdOperation).IsRequired(true).HasColumnName("IdOperation");
        _builder.Property(a => a.Order).IsRequired(true).HasColumnName("Order");
        _builder.Property(a => a.IsEnable).IsRequired(true).HasDefaultValue(false).HasColumnName("IsEnable");
        _builder.Property(a => a.RoleTag).IsRequired(true).HasMaxLength(255).HasColumnName("RoleTag");

        _builder.Property(x => x.Id).HasColumnOrder(0);
        _builder.Property(x => x.IdProfile).HasColumnOrder(1);
        _builder.Property(x => x.IdOperation).HasColumnOrder(2);
        _builder.Property(x => x.RoleTag).HasColumnOrder(3);
        _builder.Property(x => x.IsEnable).HasColumnOrder(4);
        _builder.Property(x => x.Order).HasColumnOrder(5);
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
                a.Id,
                a.IdProfile,
                a.IdOperation
            })
            .IsUnique(true);
    }

    private void ConfigurePrimaryKey()
    {
        _builder.HasKey(a => new
        {
            a.Id,
            a.IdProfile,
            a.IdOperation
        });
    }
}