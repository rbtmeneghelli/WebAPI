using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DesignPatterns.Strategy.Passo_1;

namespace WebAPI.DesignPatterns.Strategy_E_Decorator.Decorator;

public abstract class DescontoDecorator : ICalculadoraDecorator
{
    protected readonly ICalculadoraDecorator _calculadora;

    protected DescontoDecorator(ICalculadoraDecorator calculadora)
    {
        _calculadora = calculadora;
    }

    public abstract decimal Calcular(decimal valorPedido);
}
