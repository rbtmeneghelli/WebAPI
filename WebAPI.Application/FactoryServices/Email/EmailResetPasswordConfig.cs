using WebAPI.Application.FactoryInterfaces;

namespace WebAPI.Application.FactoryServices.Email;

public class EmailResetPasswordConfig : IEmailConfigFactory
{
    public int GetDisplayIdToSend()
    {
        return (int)EnumEmail.ChangePassword;
    }
}
