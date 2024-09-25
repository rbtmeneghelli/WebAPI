using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Domain.EntitiesDTO.Configuration;

public record LayoutSettingsResponseDTO
{
    [Display(Name = "Id", Description = "Id do registro")]
    public long Id { get; set; }

    [Display(Name = "LogoWeb", Description = "Logo da aplicação Web")]
    public string LogoWeb { get; set; }

    [Display(Name = "BannerWeb", Description = "Banner da aplicação Web")]
    public string BannerWeb { get; set; }

    [Display(Name = "LogoMobile", Description = "Logo da aplicação Mobile")]
    public string LogoMobile { get; set; }

    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string BannerMobile { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string ImageFileContentToUpload { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string DocumentFileContentToUpload { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Tamanho máximo do arquivo imagem")]
    public int MaxImageFileSize { get; set; }

    [Required]
    [Display(Name = "MaxDocumentFileSize", Description = "Tamanho máximo do arquivo documento")]
    public int MaxDocumentFileSize { get; set; }

    [Display(Name = "Status", Description = "Status do registro")]
    public string StatusDescription { get; set; }
}

public record LayoutSettingsCreateRequestDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Required]
    [Display(Name = "LogoWeb", Description = "Logo da aplicação Web")]
    public IFormFile LogoWeb { get; set; }

    [Required]
    [Display(Name = "BannerWeb", Description = "Banner da aplicação Web")]
    public IFormFile BannerWeb { get; set; }

    [Required]
    [Display(Name = "LogoMobile", Description = "Logo da aplicação Mobile")]
    public IFormFile LogoMobile { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public IFormFile BannerMobile { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string ImageFileContentToUpload { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string DocumentFileContentToUpload { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Tamanho máximo do arquivo imagem")]
    public int MaxImageFileSize { get; set; }

    [Required]
    [Display(Name = "MaxDocumentFileSize", Description = "Tamanho máximo do arquivo documento")]
    public int MaxDocumentFileSize { get; set; }

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record LayoutSettingsUpdateRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Display(Name = "LogoWeb", Description = "Logo da aplicação Web")]
    public IFormFile LogoWeb { get; set; }

    [Display(Name = "BannerWeb", Description = "Banner da aplicação Web")]
    public IFormFile BannerWeb { get; set; }

    [Display(Name = "LogoMobile", Description = "Logo da aplicação Mobile")]
    public IFormFile LogoMobile { get; set; }

    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public IFormFile BannerMobile { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string ImageFileContentToUpload { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string DocumentFileContentToUpload { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Tamanho máximo do arquivo imagem")]
    public int MaxImageFileSize { get; set; }

    [Required]
    [Display(Name = "MaxDocumentFileSize", Description = "Tamanho máximo do arquivo documento")]
    public int MaxDocumentFileSize { get; set; }

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record LayoutSettingsReactiveRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }
}
