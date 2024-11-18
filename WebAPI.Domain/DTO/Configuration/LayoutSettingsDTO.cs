using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Domain.DTO.Configuration;

public record LayoutSettingsExcelDTO
{
    [DisplayName("EnvironmentDescription")]
    public string EnvironmentDescription { get; set; }

    [DisplayName("ImageFileContentToUpload")]
    public string ImageFileContentToUpload { get; set; }

    [DisplayName("DocumentFileContentToUpload")]
    public string DocumentFileContentToUpload { get; set; }

    [DisplayName("MaxImageFileSize")]
    public double MaxImageFileSize { get; set; }

    [DisplayName("MaxDocumentFileSize")]
    public double MaxDocumentFileSize { get; set; }

    [DisplayName("StatusDescription")]
    public string StatusDescription { get; set; }
}
public record LayoutSettingsResponseDTO
{
    [Display(Name = "Id", Description = "Id do registro")]
    public long Id { get; set; }

    [Display(Name = "EnvironmentDescription", Description = "Descrição do ambiente")]
    public string EnvironmentDescription { get; set; }

    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string ImageFileContentToUpload { get; set; }

    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string DocumentFileContentToUpload { get; set; }

    [Display(Name = "BannerMobile", Description = "Tamanho máximo do arquivo imagem")]
    public double MaxImageFileSize { get; set; }

    [Display(Name = "MaxDocumentFileSize", Description = "Tamanho máximo do arquivo documento")]
    public double MaxDocumentFileSize { get; set; }

    [Display(Name = "Status", Description = "Status do registro")]
    public string StatusDescription { get; set; }
}

public record LayoutSettingsCreateRequestDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string ImageFileContentToUpload { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string DocumentFileContentToUpload { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Tamanho máximo do arquivo imagem")]
    public double MaxImageFileSize { get; set; }

    [Required]
    [Display(Name = "MaxDocumentFileSize", Description = "Tamanho máximo do arquivo documento")]
    public double MaxDocumentFileSize { get; set; }

    [Required]
    [Display(Name = "IdEnvironment", Description = "Id do ambiente")]
    public long? IdEnvironment { get; set; }
}

public record LayoutSettingsUpdateRequestDTO
{
    [Required]
    [Display(Name = "Id", Description = "Id do registro")]
    public long? Id { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string ImageFileContentToUpload { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Banner da aplicação Mobile")]
    public string DocumentFileContentToUpload { get; set; }

    [Required]
    [Display(Name = "BannerMobile", Description = "Tamanho máximo do arquivo imagem")]
    public double MaxImageFileSize { get; set; }

    [Required]
    [Display(Name = "MaxDocumentFileSize", Description = "Tamanho máximo do arquivo documento")]
    public double MaxDocumentFileSize { get; set; }

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
