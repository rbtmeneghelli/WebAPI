using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Infra.Generic;
using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.Infra.Mapping.ControlPanel;

public class UserMapping : GenericMapping<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        _builder = builder;
        base.ConfigureDefaultColumns();
        //Exemplo de criação de tabela Temporal (Historico) que trabalha como uma trilha de auditoria
        _builder.ToTable("ControlPanel_User", e => e.IsTemporal(t =>
        {
            t.HasPeriodStart("InicioValidade");
            t.HasPeriodEnd("TerminoValidade");
            t.UseHistoryTable("UsersHistory");
        }));
        ConfigureColumns();
        ConfigureForeignKeys();
        ConfigureIndexes();
    }

    public override void ConfigureTableName(string tableName)
    {
        _builder.ToTable(tableName);
    }

    private void ConfigureForeignKeys()
    {
        _builder.HasOne(x => x.Employee).WithOne(x => x.User);
    }

    private void ConfigureIndexes()
    {
        // Indice exclusivo >> Permite que a coluna da tabela impede que valores duplicados existam
        //_builder.HasIndex(a => a.IdProfile).IsUnique(false);
        // Indice não exclusivo >> Permite que a coluna da tabela tenha valores duplicados, porém é apresentado uma melhora nas consultas
        //_builder.HasIndex(a => a.IdProfile);
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.Login).IsRequired(true).HasMaxLength(120).HasColumnName("Login");
        _builder.Property(x => x.Password).IsRequired(true).HasMaxLength(255).HasColumnName("Password");
        _builder.Property(x => x.LastPassword).IsRequired(false).HasMaxLength(255).HasColumnName("LastPassword");
        _builder.Property(x => x.IsAuthenticated).IsRequired(true).HasDefaultValue(false).HasColumnName("IsAuthenticated");
    }
}
