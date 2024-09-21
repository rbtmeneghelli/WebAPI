using System.ComponentModel.DataAnnotations;
using WebAPI.Domain.EntitiesDTO.Generic;
using WebAPI.Domain.Enums;

namespace WebAPI.Domain.EntitiesDTO.Configuration;

public record UserSettingsDTO : GenericDTO
{
    [Required]
    [Display(Name = "Ambiente", Description = "Ambiente que será aplicado as configurações")]
    public EnumEnvironment Environment { get; set; }
    public ExpirationPasswordSettingsDTO ExpirationPasswordSettings { get; set; }
    public RequiredPasswordSettingsDTO RequiredPasswordSettings { get; set; }
    public AuthenticationSettingsDTO AuthenticationSettings { get; set; }
}
