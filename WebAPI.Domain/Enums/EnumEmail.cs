using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Enums;

public enum EnumEmail : byte
{
    [Display(Name = "Email de boas vindas")]
    Welcome = 0,

    [Display(Name = "Email de troca de senha")]
    ChangePassword = 2,

    [Display(Name = "Email de reset de senha")]
    ResetPassword = 3,
}
