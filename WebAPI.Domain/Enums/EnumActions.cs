using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Enums;

public enum EnumActions : byte
{
    [Display(Name = "Nenhum")]
    None = 0,

    [Display(Name = "Cadastro")]
    Create = 1,

    [Display(Name = "Edição")]
    Update = 2,

    [Display(Name = "Exclusão")]
    Delete = 3,

    [Display(Name = "Procurar")]
    Research = 4,

    [Display(Name = "Exportar")]
    Export = 5,

    [Display(Name = "Importar")]
    Import = 6,
}
