using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;

namespace WebAPI.Application.Services.Configuration;

public sealed class EmailDisplaySettingsService : BaseHandlerService, IEmailDisplaySettingsService
{
    private readonly IEmailDisplaySettingsRepository _iEmailDisplaySettingsRepository;
    private EnvironmentVariables _environmentVariables;
    private readonly IMapperService _iMapperService;

    public EmailDisplaySettingsService(
        IEmailDisplaySettingsRepository iEmailDisplaySettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables,
        IMapperService iMapperService)
        : base(iNotificationMessageService)
    {
        _iEmailDisplaySettingsRepository = iEmailDisplaySettingsRepository;
        _environmentVariables = environmentVariables;
        _iMapperService = iMapperService;
    }

    public async Task<IEnumerable<EmailDisplaySettingsResponseDTO>> GetAllEmailDisplaySettingsAsync()
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
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }

    public async Task<EmailDisplaySettingsResponseDTO> GetEmailDisplaySettingsByIdAsync(long id)
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
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
    }

    public async Task<bool> ExistEmailDisplaySettingsByIdAsync(long id)
    {
        var result = _iEmailDisplaySettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateEmailDisplaySettingsAsync(EmailDisplaySettingsCreateRequestDTO emailDisplaySettingsCreateRequestDTO)
    {
        EmailDisplay emailDisplay = _iMapperService.ApplyMapToEntity<EmailDisplaySettingsCreateRequestDTO, EmailDisplay>(emailDisplaySettingsCreateRequestDTO);
        _iEmailDisplaySettingsRepository.Create(emailDisplay);
        return true;
    }

    public async Task<bool> UpdateEmailDisplaySettingsAsync(EmailDisplaySettingsUpdateRequestDTO emailDisplaySettingsUpdateRequestDTO)
    {
        EmailDisplay emailDisplay = _iMapperService.ApplyMapToEntity<EmailDisplaySettingsUpdateRequestDTO, EmailDisplay>(emailDisplaySettingsUpdateRequestDTO);
        EmailDisplay emailDisplayDb = _iEmailDisplaySettingsRepository.GetById(emailDisplay.Id.Value);

        if (GuardClauseExtension.IsNotNull(emailDisplayDb))
        {
            if (emailDisplayDb.IsActive.Value)
            {
                emailDisplayDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
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

    public async Task<bool> LogicDeleteEmailDisplaySettingsByIdAsync(long id)
    {
        EmailDisplay emailDisplayDb = _iEmailDisplaySettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(emailDisplayDb))
        {
            emailDisplayDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            emailDisplayDb.IsActive = false;
            _iEmailDisplaySettingsRepository.Update(emailDisplayDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
    }

    public async Task<bool> ReactiveEmailDisplaySettingsByIdAsync(long id)
    {
        EmailDisplay emailDisplayDb = _iEmailDisplaySettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(emailDisplayDb))
        {
            emailDisplayDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            emailDisplayDb.IsActive = true;
            _iEmailDisplaySettingsRepository.Update(emailDisplayDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
    }

    public async Task<IEnumerable<EmailDisplaySettingsExcelDTO>> GetAllEmailDisplaySettingsExcelAsync()
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
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }
}
