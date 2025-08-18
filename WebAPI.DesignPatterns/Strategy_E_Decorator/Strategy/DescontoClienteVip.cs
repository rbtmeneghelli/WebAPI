namespace WebAPI.DesignPatterns.Strategy_E_Decorator.Strategy;

public sealed class DescontoClienteVip : IDescontoStrategy
{
    public string Tipo => "vip";
    public decimal CalcularDesconto(decimal valorPedido) => valorPedido * 0.15m;
}
