using FastPackForShare.Extensions;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.Domain.Models.Factory.Email;

public sealed class EmailResetPassword : IEmailConfigFactory
{
    public int GetDisplayIdToSend()
    {
        return (int)EnumEmail.ResetPassword;
    }

    public (string Subject, string TemplateId) GetSendGridIdToSend()
    {
        return (EnumEmail.ResetPassword.GetDisplayShortName(), "d-0000b111d222222222222c333333333333");
    }

    public string GetBodyText()
    {
        return $"Caro Administrador, <br> Sua senha de administrador foi resetada com sucesso. <br> Segue a sua nova senha: {FixConstants.DEFAULT_PASSWORD} ";
    }
}
