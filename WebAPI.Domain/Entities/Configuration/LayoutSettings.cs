using System.ComponentModel;
using WebAPI.Domain.Entities.Generic;
using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Entities.Configuration;

public class LayoutSettings : GenericEntity
{
    [DisplayName("LogoWeb")]
    public string LogoWeb { get; set; }

    [DisplayName("BannerWeb")]
    public string BannerWeb { get; set; }

    [DisplayName("LogoMobile")]
    public string LogoMobile { get; set; }

    [DisplayName("BannerMobile")]
    public string BannerMobile { get; set; }

    [DisplayName("ImageFileContentToUpload")]
    public string ImageFileContentToUpload { get; set; }

    [DisplayName("DocumentFileContentToUpload")]
    public string DocumentFileContentToUpload { get; set; }

    [DisplayName("MaxImageFileSize")]
    public int MaxImageFileSize { get; set; }

    [DisplayName("MaxDocumentFileSize")]
    public int MaxDocumentFileSize { get; set; }

    public virtual EnvironmentTypeSettings EnvironmentTypeSettings { get; set; }
    public virtual long? IdEnvironmentType { get; set; }
}
