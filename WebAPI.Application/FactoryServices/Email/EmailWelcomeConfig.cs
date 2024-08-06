using WebAPI.Application.FactoryInterfaces;
using WebAPI.Domain.ExtensionMethods;

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

    public (string Subject, string TemplateId) GetSendGridIdToSend()
    {
        return (EnumEmail.Welcome.GetDisplayShortName(), "d-0000b111d222222222222c333333333333");
    }
}
