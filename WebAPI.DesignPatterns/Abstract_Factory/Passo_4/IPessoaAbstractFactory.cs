using WebAPI.DesignPatterns.Abstract_Factory.Passo_1;

namespace WebAPI.DesignPatterns.Abstract_Factory.Passo_4;

public interface IPessoaAbstractFactory
{
    PessoaBase CriarPessoa(int opcao);
}
