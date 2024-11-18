using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.InfraStructure.Data.Context;

public partial class WebAPIContext
{
    public virtual DbSet<Region> Region { get; set; }
    public virtual DbSet<States> State { get; set; }
    public virtual DbSet<Domain.ValueObject.AddressData> Cep { get; set; }
    public virtual DbSet<City> City { get; set; }
    public virtual DbSet<Audit> Audit { get; set; }
    public virtual DbSet<Log> Log { get; set; }


    #region ControlPanelMappings

    public virtual DbSet<Area> Area { get; set; }
    public virtual DbSet<Employee> Employee { get; set; }
    public virtual DbSet<Operation> Operation { get; set; }
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Profile> Profile { get; set; }
    public virtual DbSet<ProfileOperation> ProfileOperations { get; set; }
    public virtual DbSet<Client> Client { get; set; }

    #endregion

    #region ConfigurationMappings

    public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
    public virtual DbSet<EmailDisplay> EmailDisplays { get; set; }
    public virtual DbSet<EmailSettings> EmailSettings { get; set; }
    public virtual DbSet<AuthenticationSettings> AuthenticationSettings { get; set; }
    public virtual DbSet<ExpirationPasswordSettings> ExpirationPasswordSettings { get; set; }
    public virtual DbSet<LayoutSettings> LayoutSettings { get; set; }
    public virtual DbSet<LogSettings> LogSettings { get; set; }
    public virtual DbSet<RequiredPasswordSettings> RequiredPasswordSettings { get; set; }
    public virtual DbSet<EnvironmentTypeSettings> EnvironmentTypeSettings { get; set; }
    public virtual DbSet<UploadSettings> UploadSettings { get; set; }

    #endregion
}
