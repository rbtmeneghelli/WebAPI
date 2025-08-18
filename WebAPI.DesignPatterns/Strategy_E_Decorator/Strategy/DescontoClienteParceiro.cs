namespace WebAPI.DesignPatterns.Strategy_E_Decorator.Strategy;

public sealed class DescontoClienteParceiro : IDescontoStrategy
{
    public string Tipo => "parceiro";
    public decimal CalcularDesconto(decimal valorPedido) => valorPedido * 0.10m;
}
