using System.ComponentModel.DataAnnotations;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Generic;

namespace WebAPI.Domain.EntitiesDTO.Configuration;

public record LogSettingsDTO : GenericDTO
{
    [Required]
    [Display(Name = "Ambiente", Description = "Ambiente que será aplicado as configurações")]
    public EnumEnvironment Environment { get; set; }

    [Required]
    [Display(Name = "SaveLogTurnOnSystem", Description = "Salvar log ao logar no sistema")]
    public bool SaveLogTurnOnSystem { get; set; }

    [Required]
    [Display(Name = "SaveLogTurnOffSystem", Description = "Salvar log ao deslogar no sistema")]
    public bool SaveLogTurnOffSystem { get; set; }

    [Required]
    [Display(Name = "SaveLogCreateData", Description = "Salvar log ao criar registro no sistema")]
    public bool SaveLogCreateData { get; set; }

    [Required]
    [Display(Name = "SaveLogResearchData", Description = "Salvar log ao pesquisar registro no sistema")]
    public bool SaveLogResearchData { get; set; }

    [Required]
    [Display(Name = "SaveLogUpdateData", Description = "Salvar log ao atualizar registro no sistema")]
    public bool SaveLogUpdateData { get; set; }

    [Required]
    [Display(Name = "SaveLogDeleteData", Description = "Salvar log ao excluir registro no sistema")]
    public bool SaveLogDeleteData { get; set; }
}
