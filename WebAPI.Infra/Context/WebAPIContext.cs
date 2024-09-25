using WebAPI.Domain;
using WebAPI.Domain.Enums;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Infra.Mapping.Configuration;
using WebAPI.Infra.Mapping.ControlPanel;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Infra.Data.Context;

public partial class WebAPIContext : DbContext
{
    public WebAPIContext(DbContextOptions<WebAPIContext> options) : base(options)
    {
        // Colocar esse comando dentro do construtor do DbContext,
        // esse comando faz que todas as queries de consulta não sejam rastreadas..
        // (Válido apenas para um banco que faz consulta apenas, sem precisar EDITAR um DADO)
        //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // This code will find slow queries in EF with the interceptor System
        //optionsBuilder.AddInterceptors(new SlowQueryInterceptor());

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebAPIContext).Assembly);

        #region ControlPanelMappings

        modelBuilder.ApplyConfiguration(new AreaMapping());
        modelBuilder.ApplyConfiguration(new EmployeeMapping());
        modelBuilder.ApplyConfiguration(new OperationMapping());
        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new ProfileMapping());
        modelBuilder.ApplyConfiguration(new ProfileOperationMapping());
        modelBuilder.ApplyConfiguration(new ClientMapping());

        #endregion

        #region ConfigurationMappings

        modelBuilder.ApplyConfiguration(new EmailTemplateMapping());
        modelBuilder.ApplyConfiguration(new EmailDisplayMapping());
        modelBuilder.ApplyConfiguration(new EmailSettingsMapping());
        modelBuilder.ApplyConfiguration(new AuthenticationSettingsMapping());
        modelBuilder.ApplyConfiguration(new ExpirationPasswordSettingsMapping());
        modelBuilder.ApplyConfiguration(new LayoutSettingsMapping());
        modelBuilder.ApplyConfiguration(new LogSettingsMapping());
        modelBuilder.ApplyConfiguration(new RequiredPasswordSettingsMapping());
        modelBuilder.ApplyConfiguration(new EnvironmentTypeSettingsMapping());
        modelBuilder.ApplyConfiguration(new UploadSettingsMapping());

        #endregion

        modelBuilder.ApplyConfiguration(new StatesMapping());
        modelBuilder.ApplyConfiguration(new CepsMapping());
        modelBuilder.ApplyConfiguration(new RegionMapping());
        modelBuilder.ApplyConfiguration(new AuditMapping());
        modelBuilder.ApplyConfiguration(new LogMapping());
        modelBuilder.ApplyConfiguration(new NotificationMapping());
        modelBuilder.ApplyConfiguration(new CityMapping());

        /* Código responsavel por impedir que os dados chaves de ADM sejam apresentados nas queries */
        modelBuilder.ApplyQueryFilterToTable<Area>(p => p.Id > 1);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) 
        relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        modelBuilder.ExecuteSeedControlPanel();
        modelBuilder.ExecuteSeedConfiguration();
        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Exemplo de configuração global para o tipo de campo das entidades
    /// </summary>
    /// <returns></returns>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //configurationBuilder.Properties<decimal>().HavePrecision(20, 2);
        //configurationBuilder.Properties<string>().AreUnicode(false);
        //configurationBuilder.Properties<string>().HaveMaxLength(500);
        base.ConfigureConventions(configurationBuilder);
    }

    public new DbSet<T> Set<T>() where T : class
    {
        return base.Set<T>();
    }

    #region Código responsavel por gravação de dados de Auditoria

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedDate").CurrentValue = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
                entry.Property("UpdateDate").IsModified = false;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("UpdateDate").IsModified = false;
                entry.Property("UpdateDate").CurrentValue = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
            }
        }

        var auditEntries = OnBeforeSaveChanges();
        var result = base.SaveChanges();
        OnAfterSaveChanges(auditEntries);
        return result;
    }

    private List<AuditEntry> OnBeforeSaveChanges()
    {
        ChangeTracker.DetectChanges();
        var auditEntries = new List<AuditEntry>();
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                continue;

            var auditEntry = new AuditEntry(entry);
            auditEntry.TableName = entry.Metadata.GetTableName();
            auditEntries.Add(auditEntry);

            foreach (var property in entry.Properties)
            {
                if (property.IsTemporary)
                {
                    auditEntry.TemporaryProperties.Add(property);
                    continue;
                }

                string propertyName = property.Metadata.Name;
                if (property.Metadata.IsPrimaryKey())
                {
                    auditEntry.KeyValues[propertyName] = property.CurrentValue;
                    continue;
                }

                switch (entry.State)
                {
                    case EntityState.Added:
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                        auditEntry.ActionName = EnumActions.Create.GetDisplayName();
                        break;

                    case EntityState.Deleted:
                        auditEntry.OldValues[propertyName] = property.OriginalValue;
                        auditEntry.ActionName = EnumActions.Delete.GetDisplayName();
                        break;

                    case EntityState.Modified:
                        if (property.IsModified)
                        {
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            auditEntry.ActionName = EnumActions.Update.GetDisplayName();
                        }
                        break;
                }
            }
        }

        foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
        {
            Audit.Add(auditEntry.ToAudit());
        }

        return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
    }

    private Task OnAfterSaveChanges(List<AuditEntry> auditEntries)
    {
        if (GuardClauses.ObjectIsNull(auditEntries) || auditEntries.Count == 0)
            return Task.CompletedTask;

        foreach (var auditEntry in auditEntries)
        {
            foreach (var prop in auditEntry.TemporaryProperties)
            {
                if (prop.Metadata.IsPrimaryKey())
                {
                    auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                }
                else
                {
                    auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                }
            }
            Audit.Add(auditEntry.ToAudit());
        }

        return Task.FromResult(SaveChanges());
    }

    #endregion
}