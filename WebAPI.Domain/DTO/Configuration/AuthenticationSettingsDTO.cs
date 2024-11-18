using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Domain.DTO.Configuration;

public record AuthenticationSettingsExcelDTO
{
    [DisplayName("EnvironmentDescription")]
    public string EnvironmentDescription { get; set; }

    [DisplayName("NumberOfTryToBlockUser")]
    public int NumberOfTryToBlockUser { get; set; }

    [DisplayName("BlockUserTime")]
    public int BlockUserTime { get; set; }

    [DisplayName("ApplyTwoFactoryValidation")]
    public bool ApplyTwoFactoryValidation { get; set; }

    [DisplayName("Status")]
    public string StatusDescription { get; set; }
}

public record AuthenticationSettingsResponseDTO
{
    [Display(Name = "Id", Description = "Id do registro")]
    public long Id { get; set; }

    [Display(Name = "EnvironmentDescription", Description = "Descrição do ambiente")]
    public string EnvironmentDescription { get; set; }

    [Display(Name = "NumberOfTryToBlockUser", Description = "Número de tentativas antes do bloqueio do usuário")]
    public int NumberOfTryToBlockUser { get; set; }

    [Display(Name = "BlockUserTime", Description = "Duração do bloqueio em minutos")]
    public int BlockUserTime { get; set; }

    [Display(Name = "ApplyTwoFactoryValidation", Description = "Aplicar validação de dois fatores")]
    public bool ApplyTwoFactoryValidation { get; set; }

    [Display(Name = "Status", Description = "Status do registro")]
    public string StatusDescription { get; set; }
}

public record AuthenticationSettingsCreateRequestDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

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

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record AuthenticationSettingsUpdateRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

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

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record AuthenticationSettingsReactiveRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }
}
