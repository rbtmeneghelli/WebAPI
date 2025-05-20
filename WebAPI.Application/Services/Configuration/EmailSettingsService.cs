using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;

namespace WebAPI.Application.Services.Configuration;

public sealed class EmailSettingsService : BaseHandlerService, IEmailSettingsService
{
    private readonly IEmailSettingsRepository _iEmailSettingsRepository;
    private EnvironmentVariables _environmentVariables;
    private readonly IMapperService _iMapperService;

    public EmailSettingsService(
        IEmailSettingsRepository iEmailSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables,
        IMapperService iMapperService)
        : base(iNotificationMessageService)
    {
        _iEmailSettingsRepository = iEmailSettingsRepository;
        _environmentVariables = environmentVariables;
        _iMapperService = iMapperService;
    }

    public async Task<IEnumerable<EmailSettingsResponseDTO>> GetAllEmailSettingsAsync()
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
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }

    public async Task<EmailSettingsResponseDTO> GetEmailSettingsByEnvironmentAsync()
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
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
    }

    public async Task<EmailSettingsResponseDTO> GetEmailSettingsByIdAsync(long id)
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
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
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

    public async Task<bool> CreateEmailSettingsAsync(EmailSettingsCreateRequestDTO emailSettingsCreateRequestDTO)
    {
        EmailSettings emailSettings = _iMapperService.MapDTOToEntity<EmailSettingsCreateRequestDTO, EmailSettings>(emailSettingsCreateRequestDTO);
        _iEmailSettingsRepository.Create(emailSettings);
        return true;
    }

    public async Task<bool> UpdateEmailSettingsAsync(EmailSettingsUpdateRequestDTO emailSettingsUpdateRequestDTO)
    {
        EmailSettings emailSettings = _iMapperService.MapDTOToEntity<EmailSettingsUpdateRequestDTO, EmailSettings>(emailSettingsUpdateRequestDTO);
        EmailSettings emailSettingsDb = _iEmailSettingsRepository.GetById(emailSettings.Id.Value);

        if (GuardClauseExtension.IsNotNull(emailSettingsDb))
        {
            if (emailSettingsDb.IsActive.Value)
            {
                emailSettingsDb.UpdatedAt = emailSettings.UpdatedAt;
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

    public async Task<bool> LogicDeleteEmailSettingsByIdAsync(long id)
    {
        EmailSettings emailSettingsDb = _iEmailSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(emailSettingsDb))
        {
            emailSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            emailSettingsDb.IsActive = false;
            _iEmailSettingsRepository.Update(emailSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
    }

    public async Task<bool> ReactiveEmailSettingsByIdAsync(long id)
    {
        EmailSettings emailSettingsDb = _iEmailSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(emailSettingsDb))
        {
            emailSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            emailSettingsDb.IsActive = true;
            _iEmailSettingsRepository.Update(emailSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
    }

    public async Task<IEnumerable<EmailSettingsExcelDTO>> GetAllEmailSettingsExcelAsync()
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
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }
}
