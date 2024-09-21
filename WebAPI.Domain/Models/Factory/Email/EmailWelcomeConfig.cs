using WebAPI.Domain.Enums;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.Domain.Models.Factory.Email;

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
