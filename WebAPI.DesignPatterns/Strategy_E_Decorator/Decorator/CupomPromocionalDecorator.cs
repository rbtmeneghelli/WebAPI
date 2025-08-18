using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DesignPatterns.Strategy.Passo_1;

namespace WebAPI.DesignPatterns.Strategy_E_Decorator.Decorator;

public class CupomPromocionalDecorator : DescontoDecorator
{
    public CupomPromocionalDecorator(ICalculadoraDecorator calculadora) : base(calculadora) { }

    public override decimal Calcular(decimal valorPedido)
    {
        var valorBase = _calculadora.Calcular(valorPedido);
        return valorBase - 50m;
    }
}
