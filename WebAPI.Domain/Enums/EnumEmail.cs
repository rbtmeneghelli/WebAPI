using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Enums;

public enum EnumEmail : byte
{
    [Display(Name = "Email de reset de senha")]
    EmailPadrão = 0,

    [Display(Name = "Email de boas vindas")]
    Welcome = 1,

    [Display(Name = "Email de troca de senha")]
    ChangePassword = 2,

    [Display(Name = "Email de reset de senha")]
    ResetPassword = 3,

    [Display(Name = "Email de confirmação de senha")]
    ConfirmPassword = 4,

    [Display(Name = "Email de relatório")]
    Report = 5,
}
