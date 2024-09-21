using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.EntitiesDTO.Configuration;

public record ExpirationPasswordSettingsDTO
{
    [Required]
    [Display(Name = "QtyDaysPasswordExpire", Description = "Quantidade de dias para expiração")]
    [Range(1, 90, ErrorMessage = "O campo {0} deve ser preenchido com valor de {1} até {2}")]
    public int QtyDaysPasswordExpire { get; set; }

    [Required]
    [Display(Name = "NotifyExpirationDays", Description = "Notificação de expiração dias antes")]
    [Range(1, 10, ErrorMessage = "O campo {0} deve ser preenchido com valor de {1} até {2}")]
    public int NotifyExpirationDays { get; set; }
}
