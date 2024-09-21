using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.EntitiesDTO.Configuration;

public record RequiredPasswordSettingsDTO
{
    [Required]
    [Display(Name = "MinimalOfChars", Description = "Mínimo de caracteres")]
    [Range(1, 15, ErrorMessage = "O campo {0} deve ser preenchido com valor de {1} até {2}")]
    public int MinimalOfChars { get; set; }

    [Required]
    [Display(Name = "MustHaveUpperCaseLetter", Description = "Deve conter letras maiúsculas")]
    public bool MustHaveUpperCaseLetter { get; set; }

    [Required]
    [Display(Name = "MustHaveNumbers", Description = "Deve conter números")]
    public bool MustHaveNumbers { get; set; }

    [Required]
    [Display(Name = "MustHaveSpecialChars", Description = "Deve conter caracteres especiais")]
    public bool MustHaveSpecialChars { get; set; }
}
