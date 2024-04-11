using WebAPI.DesignPatterns.Strategy.Passo_2;

namespace WebAPI.DesignPatterns.Strategy.Passo_1;

public sealed class Calculadora
{
    public Calcular calcular { get; set; }

    public void CalcularOperacao(double primeiroValor, double segundoValor)
    {
        calcular.Operacao(primeiroValor, segundoValor);
    }
}
