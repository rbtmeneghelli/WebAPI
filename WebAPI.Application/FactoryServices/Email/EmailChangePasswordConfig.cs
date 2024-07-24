using WebAPI.Application.FactoryInterfaces;

namespace WebAPI.Application.FactoryServices.Email;

public sealed class EmailChangePasswordConfig : IEmailConfigFactory
{
    public int GetDisplayIdToSend()
    {
        return (int)EnumEmail.ResetPassword;
    }
}
