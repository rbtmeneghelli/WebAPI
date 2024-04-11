using WebAPI.DesignPatterns.Strategy.Passo_2;

namespace WebAPI.DesignPatterns.Strategy.Passo_3
{
    public class Somar : Calcular
    {
        public override double Operacao(double primeiroValor, double segundoValor)
        {
            return primeiroValor + segundoValor;
        }
    }
}
