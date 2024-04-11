using WebAPI.DesignPatterns.Abstract_Factory.Passo_1;

namespace WebAPI.DesignPatterns.Abstract_Factory.Passo_2;

public abstract class AbstractCliente : PessoaBase
{
    public Guid ClienteId { get; set; }

    public AbstractCliente(string nome, int idade) : base(nome, idade)
    {
        ClienteId = Guid.NewGuid();
    }
}
