using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.EntitiesDTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Configuration;

public class EmailDisplaySettingsService : GenericService, IEmailDisplaySettingsService
{
    private readonly IEmailDisplaySettingsRepository _iEmailDisplaySettingsRepository;
    private EnvironmentVariables _environmentVariables;

    public EmailDisplaySettingsService(
        IEmailDisplaySettingsRepository iEmailDisplaySettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables)
        : base(iNotificationMessageService)
    {
        _iEmailDisplaySettingsRepository = iEmailDisplaySettingsRepository;
        _environmentVariables = environmentVariables;
    }

    public async Task<IEnumerable<EmailDisplaySettingsResponseDTO>> GetAllEmailDisplaySettingsAsync()
    {
        try
        {
            return await (from p in _iEmailDisplaySettingsRepository.GetAllInclude("EmailTemplates")
                          orderby p.Id ascending
                          select new EmailDisplaySettingsResponseDTO()
                          {
                              Id = p.Id.Value,
                              Title = p.Title,
                              Subject = p.Subject,
                              Body = p.Body,
                              MessagePriority = p.MessagePriority,
                              HasAttachment = p.HasAttachment,
                              TemplateDescription = p.EmailTemplates.Description,
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<EmailDisplaySettingsResponseDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<EmailDisplaySettingsResponseDTO> GetEmailDisplaySettingsByIdAsync(long id)
    {
        try
        {
            return await (from p in _iEmailDisplaySettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                          select new EmailDisplaySettingsResponseDTO
                          {
                              Id = p.Id.Value,
                              Title = p.Title,
                              Subject = p.Subject,
                              Body = p.Body,
                              MessagePriority = p.MessagePriority,
                              HasAttachment = p.HasAttachment,
                              TemplateDescription = p.EmailTemplates.Description,
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

    public async Task<bool> ExistEmailDisplaySettingsByIdAsync(long id)
    {
        var result = _iEmailDisplaySettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateEmailDisplaySettingsAsync(EmailDisplay emailDisplay)
    {
        try
        {
            _iEmailDisplaySettingsRepository.Create(emailDisplay);
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

    public async Task<bool> UpdateEmailDisplaySettingsAsync(long id, EmailDisplay emailDisplay)
    {
        try
        {
            EmailDisplay emailDisplayDb = _iEmailDisplaySettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(emailDisplayDb))
            {
                if (emailDisplayDb.Status)
                {
                    emailDisplayDb.UpdateDate = emailDisplay.UpdateDate;
                    emailDisplayDb.Title = emailDisplay.Title;
                    emailDisplayDb.Subject = emailDisplay.Subject;
                    emailDisplayDb.Body = emailDisplay.Body;
                    emailDisplayDb.MessagePriority = emailDisplay.MessagePriority;
                    emailDisplayDb.HasAttachment = emailDisplay.HasAttachment;
                    emailDisplayDb.EmailTemplateId = emailDisplay.EmailTemplateId;
                    _iEmailDisplaySettingsRepository.Update(emailDisplayDb);
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

    public async Task<bool> LogicDeleteEmailDisplaySettingsByIdAsync(long id)
    {
        try
        {
            EmailDisplay emailDisplayDb = _iEmailDisplaySettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(emailDisplayDb))
            {
                emailDisplayDb.UpdateDate = emailDisplayDb.GetNewUpdateDate();
                emailDisplayDb.Status = false;
                _iEmailDisplaySettingsRepository.Update(emailDisplayDb);
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

    public async Task<bool> ReactiveEmailDisplaySettingsByIdAsync(long id)
    {
        try
        {
            EmailDisplay emailDisplayDb = _iEmailDisplaySettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(emailDisplayDb))
            {
                emailDisplayDb.UpdateDate = emailDisplayDb.GetNewUpdateDate();
                emailDisplayDb.Status = true;
                _iEmailDisplaySettingsRepository.Update(emailDisplayDb);
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

    public async Task<IEnumerable<EmailDisplaySettingsExcelDTO>> GetAllEmailDisplaySettingsExcelAsync()
    {
        try
        {
            return await (from p in _iEmailDisplaySettingsRepository.GetAllInclude("EmailTemplates")
                          orderby p.Id ascending
                          select new EmailDisplaySettingsExcelDTO()
                          {
                              Title = p.Title,
                              Subject = p.Subject,
                              Body = p.Body,
                              MessagePriority = p.MessagePriority,
                              HasAttachment = p.HasAttachment,
                              TemplateDescription = p.EmailTemplates.Description,
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<EmailDisplaySettingsExcelDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }
}
