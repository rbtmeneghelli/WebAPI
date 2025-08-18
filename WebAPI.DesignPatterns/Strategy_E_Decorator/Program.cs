using WebAPI.DesignPatterns.Strategy_E_Decorator.Decorator;

namespace WebAPI.DesignPatterns.Strategy_E_Decorator;

public class Program
{
    private readonly CalculadoraDeDesconto _calculadoraDeDesconto;

    public Program(CalculadoraDeDesconto calculadoraDeDesconto)
    {
        _calculadoraDeDesconto = calculadoraDeDesconto;
    }

    public decimal CalcularValorPedido(EnumCupom enumCupom)
    {
        var descontoBase = _calculadoraDeDesconto.Calcular("vip", 250m);

        ICalculadoraDecorator calc = enumCupom switch
        {
            EnumCupom.Promocional => new BlackFridayDecorator(new CalculadoraBase()),
            EnumCupom.BlackFriday => new CupomPromocionalDecorator(new CalculadoraBase()),
            _ => new CalculadoraBase()
        };

        return calc.Calcular(descontoBase);
    }

}
