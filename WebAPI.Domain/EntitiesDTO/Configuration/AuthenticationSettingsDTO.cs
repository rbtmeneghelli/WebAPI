using System.ComponentModel.DataAnnotations;
using WebAPI.Domain.Generic;

namespace WebAPI.Domain.EntitiesDTO.Configuration;

public record AuthenticationSettingsDTO
{
    [Required]
    [Display(Name = "NumberOfTryToBlockUser", Description = "Número de tentativas antes do bloqueio do usuário")]
    [Range(1, 10, ErrorMessage = "O campo {0} deve ser preenchido com valor de {1} até {2}")]
    public int NumberOfTryToBlockUser { get; set; }

    [Required]
    [Display(Name = "BlockUserTime", Description = "Duração do bloqueio em minutos")]
    [Range(1, 120, ErrorMessage = "O campo {0} deve ser preenchido com valor de {1} até {2}")]
    public int BlockUserTime { get; set; }

    [Required]
    [Display(Name = "ApplyTwoFactoryValidation", Description = "Aplicar validação de dois fatores")]
    public bool ApplyTwoFactoryValidation { get; set; }
}
