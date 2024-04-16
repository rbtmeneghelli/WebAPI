using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Models.NFE.Classe;

public enum EnumNfeTag : byte
{
    [Display(Name = "ide")]
    ide = 1,
    [Display(Name = "emit")]
    emit,
    [Display(Name = "dest")]
    dest,
    [Display(Name = "retirada")]
    retirada,
    [Display(Name = "entrega")]
    entrega,
    [Display(Name = "det")]
    det,
    [Display(Name = "total")]
    total,
    [Display(Name = "transp")]
    transp,
    [Display(Name = "infAdic")]
    infAdic
}
