using System.ComponentModel.DataAnnotations;
using WebAPI.Domain.EntitiesDTO.Generic;
using WebAPI.Domain.Enums;

namespace WebAPI.Domain.EntitiesDTO.Configuration;

public record EmailSettingsDTO : GenericDTO
{
    public EnumEnvironment Environment { get; set; }

    [Required]
    [Display(Name = "Host", Description = "Host do Email")]
    [Length(10, 80, ErrorMessage = "{0} deve ter no minimo {2} e no maximo {1} caracteres preenchidos")]
    public string Host { get; set; }

    [Required]
    [Display(Name = "SmtpConfig", Description = "Endereço de SMTP do HOST")]
    [Length(10, 80, ErrorMessage = "{0} deve ter no minimo {2} e no maximo {1} caracteres preenchidos")]
    public string SmtpConfig { get; set; }

    [Required]
    [Display(Name = "PrimaryPort", Description = "Porta principal de acesso")]
    [Range(1, 999, ErrorMessage = "O campo {0} deve ser preenchido com valor de {1} até {2}")]
    public int PrimaryPort { get; set; }

    [DataType(DataType.EmailAddress)]
    [Required]
    [Display(Name = "Email", Description = "Email para envio")]
    [Length(10, 80, ErrorMessage = "{0} deve ter no minimo {2} e no maximo {1} caracteres preenchidos")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required]
    [Display(Name = "Password", Description = "Senha do Email")]
    [Length(1, 15, ErrorMessage = "{0} deve ter no minimo {2} e no maximo {1} caracteres preenchidos")]
    public string Password { get; set; }

    [Required]
    [Display(Name = "EnableSsl", Description = "Habilitar SSL")]
    public bool EnableSsl { get; set; }
}
