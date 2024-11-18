using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Domain.DTO.Configuration;

public record RequiredPasswordSettingsExcelDTO
{
    [DisplayName("EnvironmentDescription")]
    public string EnvironmentDescription { get; set; }

    [DisplayName("MinimalOfChars")]
    public int MinimalOfChars { get; set; }

    [DisplayName("MustHaveUpperCaseLetter")]
    public string MustHaveUpperCaseLetterDescription { get; set; }

    [DisplayName("MustHaveNumbers")]
    public string MustHaveNumbersDescription { get; set; }

    [DisplayName("MustHaveSpecialChars")]
    public string MustHaveSpecialCharsDescription { get; set; }

    [DisplayName("StatusDescription")]
    public string StatusDescription { get; set; }
}

public record RequiredPasswordSettingsResponseDTO
{
    [Display(Name = "Id", Description = "Id do registro")]
    public long Id { get; set; }

    [Display(Name = "EnvironmentDescription", Description = "Descrição do ambiente")]
    public string EnvironmentDescription { get; set; }

    [Display(Name = "MinimalOfChars", Description = "Mínimo de caracteres")]
    public int MinimalOfChars { get; set; }

    [Display(Name = "MustHaveUpperCaseLetter", Description = "Deve conter letras maiúsculas")]
    public bool MustHaveUpperCaseLetter { get; set; }

    [Display(Name = "MustHaveNumbers", Description = "Deve conter números")]
    public bool MustHaveNumbers { get; set; }

    [Display(Name = "MustHaveSpecialChars", Description = "Deve conter caracteres especiais")]
    public bool MustHaveSpecialChars { get; set; }

    [Display(Name = "Status", Description = "Status do registro")]
    public string StatusDescription { get; set; }
}

public record RequiredPasswordSettingsCreateRequestDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

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

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record RequiredPasswordSettingsUpdateRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

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

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record RequiredPasswordSettingsReactiveRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }
}
