using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DesignPatterns.Strategy_E_Decorator.Strategy;

namespace WebAPI.DesignPatterns.Strategy_E_Decorator;

public sealed class CalculadoraDeDesconto
{
    private readonly IEnumerable<IDescontoStrategy> _estrategias;

    public CalculadoraDeDesconto(IEnumerable<IDescontoStrategy> estrategias)
    {
        _estrategias = estrategias;
    }

    public decimal Calcular(string tipoCliente, decimal valorPedido)
    {
        var estrategia = _estrategias.FirstOrDefault(e =>
            e.Tipo.Equals(tipoCliente, StringComparison.OrdinalIgnoreCase));

        if (estrategia is null)
            throw new ArgumentException($"Nenhuma estratégia encontrada para o tipo '{tipoCliente}'");

        return estrategia.CalcularDesconto(valorPedido);
    }
}
