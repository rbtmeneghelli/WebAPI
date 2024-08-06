using WebAPI.Application.FactoryInterfaces;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Application.FactoryServices.Email;

public class EmailResetPasswordConfig : IEmailConfigFactory
{
    public int GetDisplayIdToSend()
    {
        return (int)EnumEmail.ChangePassword;
    }

    public (string Subject, string TemplateId) GetSendGridIdToSend()
    {
        return (EnumEmail.ChangePassword.GetDisplayShortName(), "d-0000b111d222222222222c333333333333");
    }
}
