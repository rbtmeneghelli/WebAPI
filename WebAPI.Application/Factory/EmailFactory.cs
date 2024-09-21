using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Interfaces.Factory;
using WebAPI.Domain.Models.Factory.Email;

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
