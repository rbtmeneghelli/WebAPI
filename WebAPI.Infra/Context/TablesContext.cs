using WebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.Infra.Data.Context;

public partial class WebAPIContext
{
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Profile> Profile { get; set; }
    public virtual DbSet<ProfileOperation> ProfileOperations { get; set; }
    public virtual DbSet<Region> Region { get; set; }
    public virtual DbSet<States> State { get; set; }
    public virtual DbSet<Domain.ValueObject.AddressData> Cep { get; set; }
    public virtual DbSet<City> City { get; set; }
    public virtual DbSet<Audit> Audit { get; set; }
    public virtual DbSet<Log> Log { get; set; }
    public virtual DbSet<Operation> Operation { get; set; }
    public virtual DbSet<ArchiveType> ArchiveTypes { get; set; }
    public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
    public virtual DbSet<EmailDisplay> EmailDisplays { get; set; }
    public virtual DbSet<EmailType> EmailType { get; set; }
    public virtual DbSet<Area> Area { get; set; }
    public virtual DbSet<Employee> Employee { get; set; }
}
