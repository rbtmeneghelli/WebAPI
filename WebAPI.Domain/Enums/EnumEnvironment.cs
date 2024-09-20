using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Enums;

public enum EnumEnvironment : byte
{
    [Display(Name = "Ambiente Produção")]
    PRD = 0,

    [Display(Name = "Ambiente Pre-Produção")]
    PRE_PROD = 1,

    [Display(Name = "Ambiente Homologação")]
    HML = 2,

    [Display(Name = "Ambiente Teste")]
    QA = 3,

    [Display(Name = "Ambiente Desenvolvimento")]
    DEV = 4,

    [Display(Name = "Ambiente Local")]
    Local = 5,
}
