using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.EntitiesDTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Configuration;

public class EmailSettingsService : GenericService, IEmailSettingsService
{
    private readonly IEmailSettingsRepository _iEmailSettingsRepository;
    private EnvironmentVariables _environmentVariables;

    public EmailSettingsService(
        IEmailSettingsRepository iEmailSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables)
        : base(iNotificationMessageService)
    {
        _iEmailSettingsRepository = iEmailSettingsRepository;
        _environmentVariables = environmentVariables;
    }

    public async Task<IEnumerable<EmailSettingsResponseDTO>> GetAllEmailSettingsAsync()
    {
        try
        {
            return await (from p in _iEmailSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                          orderby p.EnvironmentTypeSettings.Id ascending
                          select new EmailSettingsResponseDTO()
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              Host = p.Host,
                              SmtpConfig = p.SmtpConfig,
                              PrimaryPort = p.PrimaryPort,
                              Email = p.Email,
                              EnableSslDescription = p.EnableSsl ? "SSL Habilitado" : "SSL não Habilitado",
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<EmailSettingsResponseDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<EmailSettingsResponseDTO> GetEmailSettingsByEnvironmentAsync()
    {
        try
        {
            return await (from p in _iEmailSettingsRepository.FindBy(x => x.IdEnvironmentType == (int)_environmentVariables.Environment).AsQueryable()
                          select new EmailSettingsResponseDTO
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              Host = p.Host,
                              SmtpConfig = p.SmtpConfig,
                              PrimaryPort = p.PrimaryPort,
                              Email = p.Email,
                              EnableSslDescription = p.EnableSsl ? "SSL Habilitado" : "SSL não Habilitado",
                              StatusDescription = p.GetStatusDescription()
                          }).FirstOrDefaultAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETID);
            return default;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<EmailSettingsResponseDTO> GetEmailSettingsByIdAsync(long id)
    {
        try
        {
            return await (from p in _iEmailSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                          select new EmailSettingsResponseDTO
                          {
                              Id = p.Id.Value,
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              Host = p.Host,
                              SmtpConfig = p.SmtpConfig,
                              PrimaryPort = p.PrimaryPort,
                              Email = p.Email,
                              EnableSslDescription = p.EnableSsl ? "SSL Habilitado" : "SSL não Habilitado",
                              StatusDescription = p.GetStatusDescription()
                          }).FirstOrDefaultAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETID);
            return default;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> ExistEmailSettingsByEnvironmentAsync()
    {
        var result = _iEmailSettingsRepository.Exist(x => x.IdEnvironmentType == (int)_environmentVariables.Environment);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> ExistEmailSettingsByIdAsync(long id)
    {
        var result = _iEmailSettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateEmailSettingsAsync(EmailSettings emailSettings)
    {
        try
        {
            _iEmailSettingsRepository.Create(emailSettings);
            return true;
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_ADD);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> UpdateEmailSettingsAsync(long id, EmailSettings emailSettings)
    {
        try
        {
            EmailSettings emailSettingsDb = _iEmailSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(emailSettingsDb))
            {
                if (emailSettingsDb.Status)
                {
                    emailSettingsDb.UpdateDate = emailSettings.UpdateDate;
                    emailSettingsDb.Host = emailSettings.Host;
                    emailSettingsDb.SmtpConfig = emailSettings.SmtpConfig;
                    emailSettingsDb.PrimaryPort = emailSettings.PrimaryPort;
                    emailSettingsDb.Email = emailSettings.Email;
                    emailSettingsDb.Password = emailSettings.Password;
                    emailSettingsDb.EnableSsl = emailSettings.EnableSsl;
                    _iEmailSettingsRepository.Update(emailSettingsDb);
                    return true;
                }

                Notify(FixConstants.ERROR_IN_UPDATE);
                return false;
            }

            Notify(FixConstants.ERROR_IN_UPDATE);
            return false;
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_UPDATE);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> LogicDeleteEmailSettingsByIdAsync(long id)
    {
        try
        {
            EmailSettings emailSettingsDb = _iEmailSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(emailSettingsDb))
            {
                emailSettingsDb.UpdateDate = emailSettingsDb.GetNewUpdateDate();
                emailSettingsDb.Status = false;
                _iEmailSettingsRepository.Update(emailSettingsDb);
                return true;
            }
            else
            {
                Notify(FixConstants.ERROR_IN_DELETELOGIC);
                return false;
            }
        }
        catch (Exception)
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> ReactiveEmailSettingsByIdAsync(long id)
    {
        try
        {
            EmailSettings emailSettingsDb = _iEmailSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(emailSettingsDb))
            {
                emailSettingsDb.UpdateDate = emailSettingsDb.GetNewUpdateDate();
                emailSettingsDb.Status = true;
                _iEmailSettingsRepository.Update(emailSettingsDb);
                return true;
            }
            else
            {
                Notify(FixConstants.ERROR_IN_DELETELOGIC);
                return false;
            }
        }
        catch (Exception)
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<IEnumerable<EmailSettingsExcelDTO>> GetAllEmailSettingsExcelAsync()
    {
        try
        {
            return await (from p in _iEmailSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                          orderby p.EnvironmentTypeSettings.Id ascending
                          select new EmailSettingsExcelDTO()
                          {
                              EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                              Host = p.Host,
                              SmtpConfig = p.SmtpConfig,
                              PrimaryPort = p.PrimaryPort,
                              Email = p.Email,
                              EnableSslDescription = p.EnableSsl ? "SSL Habilitado" : "SSL não Habilitado",
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<EmailSettingsExcelDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }
}
