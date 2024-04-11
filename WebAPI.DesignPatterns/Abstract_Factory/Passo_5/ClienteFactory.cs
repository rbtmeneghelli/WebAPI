using WebAPI.DesignPatterns.Abstract_Factory.Passo_1;
using WebAPI.DesignPatterns.Abstract_Factory.Passo_3;
using WebAPI.DesignPatterns.Abstract_Factory.Passo_4;

namespace WebAPI.DesignPatterns.Abstract_Factory.Passo_5;

public sealed class ClienteFactory : IPessoaAbstractFactory
{
    public PessoaBase CriarPessoa(int opcao)
    {
        switch (opcao)
        {
            case 1:
                {
                    return new ClienteVip();
                }
            case 2:
                {
                    return new ClienteComum();
                }
            default:
                throw new ArgumentOutOfRangeException("Tipo não implementado");
        }
    }
}
