using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;

namespace WebAPI.Application.Services.Configuration;

public sealed class AuthenticationSettingsService : BaseHandlerService, IAuthenticationSettingsService
{
    private readonly IAuthenticationSettingsRepository _iAuthenticationSettingsRepository;
    private readonly IMapperService _iMapperService;
    private EnvironmentVariables _environmentVariables;

    public AuthenticationSettingsService(
        IAuthenticationSettingsRepository iAuthenticationSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables,
        IMapperService iMapperService)
        : base(iNotificationMessageService)
    {
        _iAuthenticationSettingsRepository = iAuthenticationSettingsRepository;
        _environmentVariables = environmentVariables;
        _iMapperService = iMapperService;
    }

    public async Task<IEnumerable<AuthenticationSettingsResponseDTO>> GetAllAuthenticationSettingsAsync()
    {
        return await (from p in _iAuthenticationSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                      orderby p.EnvironmentTypeSettings.Id ascending
                      select new AuthenticationSettingsResponseDTO()
                      {
                          Id = p.Id.Value,
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          NumberOfTryToBlockUser = p.NumberOfTryToBlockUser,
                          BlockUserTime = p.BlockUserTime,
                          ApplyTwoFactoryValidation = p.ApplyTwoFactoryValidation,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }

    public async Task<AuthenticationSettingsResponseDTO> GetAuthenticationSettingsByEnvironmentAsync()
    {
        return await (from p in _iAuthenticationSettingsRepository.FindBy(x => x.IdEnvironmentType == (int)_environmentVariables.Environment).AsQueryable()
                      select new AuthenticationSettingsResponseDTO
                      {
                          Id = p.Id.Value,
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          NumberOfTryToBlockUser = p.NumberOfTryToBlockUser,
                          BlockUserTime = p.BlockUserTime,
                          ApplyTwoFactoryValidation = p.ApplyTwoFactoryValidation,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
    }

    public async Task<AuthenticationSettingsResponseDTO> GetAuthenticationSettingsByIdAsync(long id)
    {
        return await (from p in _iAuthenticationSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                      select new AuthenticationSettingsResponseDTO
                      {
                          Id = p.Id.Value,
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          NumberOfTryToBlockUser = p.NumberOfTryToBlockUser,
                          BlockUserTime = p.BlockUserTime,
                          ApplyTwoFactoryValidation = p.ApplyTwoFactoryValidation,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
    }

    public async Task<bool> ExistAuthenticationSettingsByEnvironmentAsync()
    {
        var result = _iAuthenticationSettingsRepository.Exist(x => x.IdEnvironmentType == (int)_environmentVariables.Environment);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> ExistAuthenticationSettingsByIdAsync(long id)
    {
        var result = _iAuthenticationSettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateAuthenticationSettingsAsync(AuthenticationSettingsCreateRequestDTO authenticationSettingsCreateRequestDTO)
    {
        AuthenticationSettings authenticationSettings = _iMapperService.ApplyMapToEntity<AuthenticationSettingsCreateRequestDTO, AuthenticationSettings>(authenticationSettingsCreateRequestDTO);
        _iAuthenticationSettingsRepository.Create(authenticationSettings);
        return true;
    }

    public async Task<bool> UpdateAuthenticationSettingsAsync(AuthenticationSettingsUpdateRequestDTO authenticationSettingsCreateRequestDTO)
    {
        AuthenticationSettings authenticationSettings = _iMapperService.ApplyMapToEntity<AuthenticationSettingsUpdateRequestDTO, AuthenticationSettings>(authenticationSettingsCreateRequestDTO);
        AuthenticationSettings authenticationSettingsDb = _iAuthenticationSettingsRepository.GetById(authenticationSettings.Id.Value);

        if (GuardClauseExtension.IsNotNull(authenticationSettingsDb))
        {
            if (authenticationSettingsDb.IsActive.Value)
            {
                authenticationSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
                authenticationSettingsDb.NumberOfTryToBlockUser = authenticationSettings.NumberOfTryToBlockUser;
                authenticationSettingsDb.BlockUserTime = authenticationSettings.BlockUserTime;
                authenticationSettingsDb.ApplyTwoFactoryValidation = authenticationSettings.ApplyTwoFactoryValidation;
                _iAuthenticationSettingsRepository.Update(authenticationSettingsDb);
                return true;
            }

            Notify(FixConstants.ERROR_IN_UPDATE);
            return false;
        }

        Notify(FixConstants.ERROR_IN_UPDATE);
        return false;
    }

    public async Task<bool> LogicDeleteAuthenticationSettingsByIdAsync(long id)
    {
        AuthenticationSettings authenticationSettingsDb = _iAuthenticationSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(authenticationSettingsDb))
        {
            authenticationSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            authenticationSettingsDb.IsActive = false;
            _iAuthenticationSettingsRepository.Update(authenticationSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
    }

    public async Task<bool> ReactiveAuthenticationSettingsByIdAsync(long id)
    {
        AuthenticationSettings authenticationSettingsDb = _iAuthenticationSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(authenticationSettingsDb))
        {
            authenticationSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            authenticationSettingsDb.IsActive = true;
            _iAuthenticationSettingsRepository.Update(authenticationSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
    }

    public async Task<IEnumerable<AuthenticationSettingsExcelDTO>> GetAllAuthenticationSettingsExcelAsync()
    {
        return await (from p in _iAuthenticationSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                      orderby p.EnvironmentTypeSettings.Id ascending
                      select new AuthenticationSettingsExcelDTO()
                      {
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          NumberOfTryToBlockUser = p.NumberOfTryToBlockUser,
                          BlockUserTime = p.BlockUserTime,
                          ApplyTwoFactoryValidation = p.ApplyTwoFactoryValidation,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }
}
