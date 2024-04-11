namespace WebAPI.DesignPatterns.Abstract_Factory.Passo_1;

public abstract class PessoaBase
{
    public string Nome { get; init; }
    public int Idade { get; init; }

    public PessoaBase(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
}