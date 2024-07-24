using WebAPI.Application.FactoryInterfaces;

namespace WebAPI.Application.FactoryServices.Email;

public sealed class EmailWelcomeConfig : IEmailConfigFactory
{
    public EmailWelcomeConfig()
    {
    }
    public int GetDisplayIdToSend()
    {
        return (int)EnumEmail.Welcome;
    }
}
