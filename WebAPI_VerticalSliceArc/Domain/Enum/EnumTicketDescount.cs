using System.ComponentModel.DataAnnotations;

namespace WebAPI_VerticalSliceArc.Domain.Enum;

public enum EnumTicketDescount : byte
{
    [Display(Name = "Nenhum")]
    None = 0,

    [Display(Name = "Cadastro")]
    Store = 1,

    [Display(Name = "Edição")]
    BlackFriday = 2,

    [Display(Name = "Exclusão")]
    Employee = 3,
}
