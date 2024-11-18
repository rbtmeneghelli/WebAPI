using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.InfraStructure.Data.Mapping;

public class LogMapping : IEntityTypeConfiguration<Log>
{
    private EntityTypeBuilder<Log> _builder;

    public void Configure(EntityTypeBuilder<Log> builder)
    {
        _builder = builder;
        ConfigureTableName("ControlPanel_Logs");
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
        _builder.Property(x => x.Class).IsRequired().HasMaxLength(100).HasColumnName("Class");
        _builder.Property(x => x.Method).IsRequired().HasMaxLength(100).HasColumnName("Method");
        _builder.Property(x => x.MessageError).IsRequired(false).HasMaxLength(10000).HasColumnName("Error");
        _builder.Property(x => x.Object).IsRequired(false).HasMaxLength(10000).HasColumnName("Object");
        _builder.Property(x => x.UpdateTime).HasColumnName("UpdateDate");
    }
}
