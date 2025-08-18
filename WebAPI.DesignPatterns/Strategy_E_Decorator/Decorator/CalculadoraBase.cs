namespace WebAPI.DesignPatterns.Strategy_E_Decorator.Decorator;

public sealed class CalculadoraBase : ICalculadoraDecorator
{
    public decimal Calcular(decimal valorPedido) => valorPedido;
}
