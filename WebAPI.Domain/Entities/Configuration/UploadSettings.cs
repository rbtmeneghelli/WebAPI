using System.ComponentModel;
using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.Configuration;

public class UploadSettings : BaseEntityModel
{
    [DisplayName("LogoWeb")]
    public byte[] LogoWeb { get; set; }

    [DisplayName("LogoWebDescription")]
    public string LogoWebDescription { get; set; }

    [DisplayName("BannerWeb")]
    public byte[] BannerWeb { get; set; }

    [DisplayName("BannerWebDescription")]
    public string BannerWebDescription { get; set; }

    [DisplayName("LogoMobile")]
    public byte[] LogoMobile { get; set; }

    [DisplayName("LogoMobileDescription")]
    public string LogoMobileDescription { get; set; }

    [DisplayName("BannerMobile")]
    public byte[] BannerMobile { get; set; }

    [DisplayName("BannerMobileDescription")]
    public string BannerMobileDescription { get; set; }

    public virtual EnvironmentTypeSettings EnvironmentTypeSettings { get; set; }
    public virtual long? IdEnvironmentType { get; set; }

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }
}
