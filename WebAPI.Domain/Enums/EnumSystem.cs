namespace WebAPI.Domain.Enums;

public enum EnumSystem : byte
{
    [Display(Name = "Modo Anonimo")]
    Anonymous = 0,
    [Display(Name = "Modo Padrão")]
    Default = 1
}
