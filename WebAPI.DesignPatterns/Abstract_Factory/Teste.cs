using WebAPI.DesignPatterns.Abstract_Factory.Passo_4;

namespace WebAPI.DesignPatterns.Abstract_Factory;

public class Teste
{
    public Teste()
    {
        // Testando a funcionalidade Abstract Factory
        var usuarioFactory = PessoaAbstractFactory.CriarObjetoPessoa(1);
        var clienteFactory = PessoaAbstractFactory.CriarObjetoPessoa(2);

        var usuarioAdmin = usuarioFactory.CriarPessoa(1);
        var usuarioPadrao = usuarioFactory.CriarPessoa(2);
    }
}
