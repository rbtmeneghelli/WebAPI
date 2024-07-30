using WebAPI.Application.FactoryInterfaces;
using WebAPI.Application.FactoryServices.Email;

namespace WebAPI.Application.Factory;

public sealed class EmailFactory : IEmailFactory
{
    public IEmailConfigFactory SendEmailByEnumEmail(EnumEmail enumEmail)
    {
        return enumEmail switch
        {
            EnumEmail.Welcome => new EmailWelcomeConfig(),
            EnumEmail.ChangePassword => new EmailChangePasswordConfig(),
            EnumEmail.ResetPassword => new EmailResetPasswordConfig(),
            _ => throw new ApplicationException()
        };
    }     
}
