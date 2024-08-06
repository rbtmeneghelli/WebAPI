using WebAPI.Application.FactoryInterfaces;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Application.FactoryServices.Email;

public sealed class EmailChangePasswordConfig : IEmailConfigFactory
{
    public int GetDisplayIdToSend()
    {
        return (int)EnumEmail.ResetPassword;
    }

    public (string Subject, string TemplateId) GetSendGridIdToSend()
    {
        return (EnumEmail.ResetPassword.GetDisplayShortName(), "d-0000b111d222222222222c333333333333");
    }
}
