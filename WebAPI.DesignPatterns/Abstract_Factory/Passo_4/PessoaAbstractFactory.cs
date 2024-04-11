using WebAPI.DesignPatterns.Abstract_Factory.Passo_5;

namespace WebAPI.DesignPatterns.Abstract_Factory.Passo_4;

public abstract class PessoaAbstractFactory
{
    public static IPessoaAbstractFactory CriarObjetoPessoa(int opcao)
    {
        switch (opcao)
        {
            case 1:
                {
                    return new UsuarioFactory();
                }
            case 2:
                {
                    return new ClienteFactory();
                }
            default:
                throw new ArgumentOutOfRangeException(nameof(opcao), opcao, null);
        }
    }
}
