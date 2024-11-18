using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Domain.DTO.Configuration;

public record EmailSettingsExcelDTO
{
    [DisplayName("EnvironmentDescription")]
    public string EnvironmentDescription { get; set; }

    [DisplayName("Host")]
    public string Host { get; set; }

    [DisplayName("SmtpConfig")]
    public string SmtpConfig { get; set; }

    [DisplayName("PrimaryPort")]
    public int PrimaryPort { get; set; }

    [DisplayName("Email")]
    public string Email { get; set; }

    [DisplayName("EnableSslDescription")]
    public string EnableSslDescription { get; set; }

    [DisplayName("StatusDescription")]
    public string StatusDescription { get; set; }
}

public record EmailSettingsResponseDTO
{
    [Display(Name = "Id", Description = "Id do registro")]
    public long Id { get; set; }

    [Display(Name = "EnvironmentDescription", Description = "Descrição do ambiente")]
    public string EnvironmentDescription { get; set; }

    [Display(Name = "Host", Description = "Nome do provedor de email")]
    public string Host { get; set; }

    [Display(Name = "SmtpConfig", Description = "Endereço SMTP do provedor de email")]
    public string SmtpConfig { get; set; }

    [Display(Name = "SmtpConfig", Description = "Porta principal do endereço SMTP")]
    public int PrimaryPort { get; set; }

    [Display(Name = "SmtpConfig", Description = "Email responsavel pelo envio de mensagens")]
    public string Email { get; set; }

    [Display(Name = "EnableSsl", Description = "Habilitar SSL")]
    public string EnableSslDescription { get; set; }

    [Display(Name = "Status", Description = "Status do registro")]
    public string StatusDescription { get; set; }
}

public record EmailSettingsCreateRequestDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

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

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record EmailSettingsUpdateRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

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

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record EmailSettingsReactiveRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }
}
