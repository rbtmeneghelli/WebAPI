using WebAPI.Domain.Interfaces.Factory;
using WebAPI.Domain.Models.Factory.Email;

namespace WebAPI.Application.Factory;

public sealed class EmailFactory : IEmailFactory
{
    public IEmailConfigFactory SendEmailByEnumEmail(EnumEmail enumEmail)
    {
        return enumEmail switch
        {
            EnumEmail.Welcome => new EmailWelcome(),
            EnumEmail.ChangePassword => new EmailChangePassword(),
            EnumEmail.ResetPassword => new EmailResetPassword(),
            EnumEmail.ForgetPassword => new EmailForgetPassword(),
            EnumEmail.ConfirmPassword => new EmailConfirmPassword(),
            _ => throw new ApplicationException()
        };
    }     
}
