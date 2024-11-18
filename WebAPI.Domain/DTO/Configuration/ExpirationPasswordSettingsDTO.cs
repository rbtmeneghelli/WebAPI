using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Domain.DTO.Configuration;

public record ExpirationPasswordSettingsExcelDTO
{
    [DisplayName("EnvironmentDescription")]
    public string EnvironmentDescription { get; set; }

    [DisplayName("QtyDaysPasswordExpire")]
    public int QtyDaysPasswordExpire { get; set; }

    [DisplayName("NotifyExpirationDays")]
    public int NotifyExpirationDays { get; set; }

    [DisplayName("StatusDescription")]
    public string StatusDescription { get; set; }
}

public record ExpirationPasswordSettingsResponseDTO
{
    [Display(Name = "Id", Description = "Id do registro")]
    public long Id { get; set; }

    [Display(Name = "EnvironmentDescription", Description = "Descrição do ambiente")]
    public string EnvironmentDescription { get; set; }

    [Display(Name = "QtyDaysPasswordExpire", Description = "Quantidade de dias para expirar a senha")]
    public int QtyDaysPasswordExpire { get; set; }

    [Display(Name = "NotifyExpirationDays", Description = "Dias para enviar notificação antes de expirar")]
    public int NotifyExpirationDays { get; set; }

    [Display(Name = "Status", Description = "Status do registro")]
    public string StatusDescription { get; set; }
}

public record ExpirationPasswordSettingsCreateRequestDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Required]
    [Display(Name = "QtyDaysPasswordExpire", Description = "Quantidade de dias para expiração")]
    [Range(1, 90, ErrorMessage = "O campo {0} deve ser preenchido com valor de {1} até {2}")]
    public int QtyDaysPasswordExpire { get; set; }

    [Required]
    [Display(Name = "NotifyExpirationDays", Description = "Notificação de expiração dias antes")]
    [Range(1, 10, ErrorMessage = "O campo {0} deve ser preenchido com valor de {1} até {2}")]
    public int NotifyExpirationDays { get; set; }

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record ExpirationPasswordSettingsUpdateRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Required]
    [Display(Name = "QtyDaysPasswordExpire", Description = "Quantidade de dias para expiração")]
    [Range(1, 90, ErrorMessage = "O campo {0} deve ser preenchido com valor de {1} até {2}")]
    public int QtyDaysPasswordExpire { get; set; }

    [Required]
    [Display(Name = "NotifyExpirationDays", Description = "Notificação de expiração dias antes")]
    [Range(1, 10, ErrorMessage = "O campo {0} deve ser preenchido com valor de {1} até {2}")]
    public int NotifyExpirationDays { get; set; }

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record ExpirationPasswordSettingsReactiveRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }
}
