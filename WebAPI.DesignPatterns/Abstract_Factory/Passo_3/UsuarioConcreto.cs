using WebAPI.DesignPatterns.Abstract_Factory.Passo_2;

namespace WebAPI.DesignPatterns.Abstract_Factory.Passo_3;

public sealed class UsuarioAdmin : AbstractUsuario
{
    public UsuarioAdmin() : base("Usuario Vip", 3)
    {

    }
}

public sealed class UsuarioPadrao : AbstractUsuario
{
    public UsuarioPadrao() : base("Usuario Comum", 4)
    {
    }
}
