using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FastPackForShare.Bases;

namespace WebAPI.Domain.Entities.ControlPanel;

public class ClientMapping : BaseMappingModel<Client>
{
    public override void Configure(EntityTypeBuilder<Client> builder)
    {
        _builder = builder;
        base.ConfigureBase("ControlPanel_Client");
        ConfigureColumns();
        ConfigureForeignKeys();
    }

    private void ConfigureForeignKeys()
    {
        _builder.OwnsOne(a => a.ClientAddress, add =>
         {
             add.Property(p => p.City).HasColumnName(nameof(Address.City));
             add.Property(p => p.Cep).HasColumnName(nameof(Address.Cep));
             add.ToTable("ControlPanel_ClientAddress"); // Com esse comando será criado uma tabela com relacionamento 1 para 1. Senão os campos são adicionados na entidade Client
         });

        _builder.OwnsOne(a => a.ClientDocument, add =>
        {
            add.Property(p => p.Cpf).HasColumnName(nameof(Document.Cpf));
            add.Property(p => p.Rg).HasColumnName(nameof(Document.Rg));
            add.Property(p => p.BirthDate).HasColumnName(nameof(Document.BirthDate));
            add.Property(p => p.Age).HasColumnName(nameof(Document.Age));
            add.ToTable("ControlPanel_ClientDocument"); // Com esse comando será criado uma tabela com relacionamento 1 para 1. Senão os campos são adicionados na entidade Client
        });

        //_builder.ComplexProperty(x => x.ClientCep, x => x.IsRequired());
        //_builder.ComplexProperty(x => x.ClientDocument, x => x.IsRequired());

        // Pode-se fazer 1 para N, com o comando _builder.OwnsMany
    }

    private void ConfigureColumns()
    {
        _builder.Property(x => x.ClientName).IsRequired(true).HasMaxLength(255).HasColumnName("Name");
    }
}