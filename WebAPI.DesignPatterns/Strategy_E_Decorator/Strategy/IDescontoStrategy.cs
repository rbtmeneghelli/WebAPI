namespace WebAPI.DesignPatterns.Strategy_E_Decorator.Strategy;

public interface IDescontoStrategy
{
    string Tipo { get; }
    decimal CalcularDesconto(decimal valorPedido);
}
