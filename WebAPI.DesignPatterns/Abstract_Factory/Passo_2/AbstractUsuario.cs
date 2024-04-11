using WebAPI.DesignPatterns.Abstract_Factory.Passo_1;

namespace WebAPI.DesignPatterns.Abstract_Factory.Passo_2;

public abstract class AbstractUsuario : PessoaBase
{
    public Guid UsuarioId { get; set; }

    public AbstractUsuario(string nome, int idade) : base(nome, idade)
    {
        UsuarioId = Guid.NewGuid();
    }
}
