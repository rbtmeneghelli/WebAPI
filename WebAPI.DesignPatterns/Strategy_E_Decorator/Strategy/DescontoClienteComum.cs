namespace WebAPI.DesignPatterns.Strategy_E_Decorator.Strategy;

public sealed class DescontoClienteComum : IDescontoStrategy
{
    public string Tipo => "comum";
    public decimal CalcularDesconto(decimal valorPedido) => valorPedido * 0.05m;
}
