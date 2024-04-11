using WebAPI.DesignPatterns.Strategy.Passo_1;
using WebAPI.DesignPatterns.Strategy.Passo_3;

namespace WebAPI.DesignPatterns.Strategy;

public class Teste
{
    public Teste()
    {
        // Testando a funcionalidade Strategy
        Calculadora calculadora = new Calculadora();
        calculadora.calcular = new Somar();
        calculadora.CalcularOperacao(1, 2);
    }
}
