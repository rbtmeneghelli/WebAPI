namespace WebAPI.Domain.Enums;

public enum EnumHierarchyLevel : byte
{
    [Display(Name = "Desenvolvimento")]
    Development = 0,

    [Display(Name = "Principal")]
    Principal = 1,

    [Display(Name = "Áreas")]
    Areas = 2,

    [Display(Name = "Diretores")]
    Directors = 3,

    [Display(Name = "Gerentes")]
    Managers = 4,

    [Display(Name = "Líderes")]
    Leaders = 5,

    [Display(Name = "Colaboradores")]
    Cooperator = 6,
}
