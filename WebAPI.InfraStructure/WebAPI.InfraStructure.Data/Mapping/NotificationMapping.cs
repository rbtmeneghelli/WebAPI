using WebAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebAPI.Domain.Entities.Others;
using FastPackForShare.Extensions;

namespace WebAPI.InfraStructure.Data.Mapping;

public class NotificationMapping : IEntityTypeConfiguration<Notification>
{
    private EntityTypeBuilder<Notification> _builder;

    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        _builder = builder;
        ConfigureTableName("ControlPanel_Notification");
        ConfigureColumns();
    }

    public void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureColumns()
    {
        _builder.HasKey(x => x.Id);
        _builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn(1, 1).HasColumnName("Id");
        _builder.Property(x => x.Description).IsRequired().HasMaxLength(100).HasColumnName("Description");
        _builder.Property(x => x.CreatedDate).HasDefaultValue(DateOnlyExtension.GetDateTimeNowFromBrazil()).HasColumnName("CreatedDate");
        _builder.Property(x => x.Status).IsRequired().HasDefaultValue(true).HasColumnName("Status").HasColumnType("bit");
    }
}
