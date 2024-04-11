using WebAPI.DesignPatterns.Abstract_Factory.Passo_2;

namespace WebAPI.DesignPatterns.Abstract_Factory.Passo_3;

public sealed class ClienteVip : AbstractCliente
{
    public ClienteVip() : base("Nome Vip", 1)
    {

    }
}

public sealed class ClienteComum : AbstractCliente
{
    public ClienteComum() : base("Nome Comum", 2)
    {
    }
}
