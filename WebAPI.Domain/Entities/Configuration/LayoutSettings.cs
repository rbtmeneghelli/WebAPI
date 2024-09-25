using System.ComponentModel;
using WebAPI.Domain.Entities.Generic;

namespace WebAPI.Domain.Entities.Configuration;

public class LayoutSettings : GenericEntity
{
    [DisplayName("LogoWeb")]
    public byte[] LogoWeb { get; set; }

    [DisplayName("BannerWeb")]
    public byte[] BannerWeb { get; set; }

    [DisplayName("LogoMobile")]
    public byte[] LogoMobile { get; set; }

    [DisplayName("BannerMobile")]
    public byte[] BannerMobile { get; set; }

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
