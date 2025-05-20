using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;

namespace WebAPI.Application.Services.Configuration;

public sealed class RequiredPasswordSettingsService : BaseHandlerService, IRequiredPasswordSettingsService
{
    private readonly IRequiredPasswordSettingsRepository _iRequiredPasswordSettingsRepository;
    private EnvironmentVariables _environmentVariables;
    private readonly IMapperService _iMapperService;

    public RequiredPasswordSettingsService(
        IRequiredPasswordSettingsRepository iRequiredPasswordSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables,
        IMapperService iMapperService)
        : base(iNotificationMessageService)
    {
        _iRequiredPasswordSettingsRepository = iRequiredPasswordSettingsRepository;
        _environmentVariables = environmentVariables;
        _iMapperService = iMapperService;
    }

    public async Task<IEnumerable<RequiredPasswordSettingsResponseDTO>> GetAllRequiredPasswordSettingsAsync()
    {
        return await (from p in _iRequiredPasswordSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                      orderby p.EnvironmentTypeSettings.Id ascending
                      select new RequiredPasswordSettingsResponseDTO()
                      {
                          Id = p.Id.Value,
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          MinimalOfChars = p.MinimalOfChars,
                          MustHaveNumbers = p.MustHaveNumbers,
                          MustHaveSpecialChars = p.MustHaveSpecialChars,
                          MustHaveUpperCaseLetter = p.MustHaveUpperCaseLetter,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }

    public async Task<RequiredPasswordSettingsResponseDTO> GetRequiredPasswordSettingsByEnvironmentAsync()
    {
        return await (from p in _iRequiredPasswordSettingsRepository.FindBy(x => x.IdEnvironmentType == (int)_environmentVariables.Environment).AsQueryable()
                      select new RequiredPasswordSettingsResponseDTO
                      {
                          Id = p.Id.Value,
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          MinimalOfChars = p.MinimalOfChars,
                          MustHaveNumbers = p.MustHaveNumbers,
                          MustHaveSpecialChars = p.MustHaveSpecialChars,
                          MustHaveUpperCaseLetter = p.MustHaveUpperCaseLetter,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
    }

    public async Task<RequiredPasswordSettingsResponseDTO> GetRequiredPasswordSettingsByIdAsync(long id)
    {
        return await (from p in _iRequiredPasswordSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                      select new RequiredPasswordSettingsResponseDTO
                      {
                          Id = p.Id.Value,
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          MinimalOfChars = p.MinimalOfChars,
                          MustHaveNumbers = p.MustHaveNumbers,
                          MustHaveSpecialChars = p.MustHaveSpecialChars,
                          MustHaveUpperCaseLetter = p.MustHaveUpperCaseLetter,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
    }

    public async Task<bool> ExistRequiredPasswordSettingsByEnvironmentAsync()
    {
        var result = _iRequiredPasswordSettingsRepository.Exist(x => x.IdEnvironmentType == (int)_environmentVariables.Environment);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> ExistRequiredPasswordSettingsByIdAsync(long id)
    {
        var result = _iRequiredPasswordSettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateRequiredPasswordSettingsAsync(RequiredPasswordSettingsCreateRequestDTO requiredPasswordSettingsCreateRequestDTO)
    {
        RequiredPasswordSettings requiredPasswordSettings = _iMapperService.MapDTOToEntity<RequiredPasswordSettingsCreateRequestDTO, RequiredPasswordSettings>(requiredPasswordSettingsCreateRequestDTO);
        _iRequiredPasswordSettingsRepository.Create(requiredPasswordSettings);
        return true;
    }

    public async Task<bool> UpdateRequiredPasswordSettingsAsync(RequiredPasswordSettingsUpdateRequestDTO requiredPasswordSettingsUpdateRequestDTO)
    {
        RequiredPasswordSettings requiredPasswordSettings = _iMapperService.MapDTOToEntity<RequiredPasswordSettingsUpdateRequestDTO, RequiredPasswordSettings>(requiredPasswordSettingsUpdateRequestDTO);
        RequiredPasswordSettings requiredPasswordSettingsDb = _iRequiredPasswordSettingsRepository.GetById(requiredPasswordSettings.Id.Value);

        if (GuardClauseExtension.IsNotNull(requiredPasswordSettingsDb))
        {
            if (requiredPasswordSettingsDb.IsActive.Value)
            {
                requiredPasswordSettingsDb.UpdatedAt = requiredPasswordSettings.UpdatedAt;
                requiredPasswordSettingsDb.MinimalOfChars = requiredPasswordSettings.MinimalOfChars;
                requiredPasswordSettingsDb.MustHaveNumbers = requiredPasswordSettings.MustHaveNumbers;
                requiredPasswordSettingsDb.MustHaveSpecialChars = requiredPasswordSettings.MustHaveSpecialChars;
                requiredPasswordSettingsDb.MustHaveUpperCaseLetter = requiredPasswordSettings.MustHaveUpperCaseLetter;
                _iRequiredPasswordSettingsRepository.Update(requiredPasswordSettingsDb);
                return true;
            }

            Notify(FixConstants.ERROR_IN_UPDATE);
            return false;
        }

        Notify(FixConstants.ERROR_IN_UPDATE);
        return false;
    }

    public async Task<bool> LogicDeleteRequiredPasswordSettingsByIdAsync(long id)
    {
        RequiredPasswordSettings requiredPasswordSettingsDb = _iRequiredPasswordSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(requiredPasswordSettingsDb))
        {
            requiredPasswordSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            requiredPasswordSettingsDb.IsActive = false;
            _iRequiredPasswordSettingsRepository.Update(requiredPasswordSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
    }

    public async Task<bool> ReactiveRequiredPasswordSettingsByIdAsync(long id)
    {
        RequiredPasswordSettings requiredPasswordSettingsDb = _iRequiredPasswordSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(requiredPasswordSettingsDb))
        {
            requiredPasswordSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            requiredPasswordSettingsDb.IsActive = true;
            _iRequiredPasswordSettingsRepository.Update(requiredPasswordSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
    }

    public async Task<IEnumerable<RequiredPasswordSettingsExcelDTO>> GetAllRequiredPasswordSettingsExcelAsync()
    {
        return await (from p in _iRequiredPasswordSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                      orderby p.EnvironmentTypeSettings.Id ascending
                      select new RequiredPasswordSettingsExcelDTO()
                      {
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          MinimalOfChars = p.MinimalOfChars,
                          MustHaveNumbersDescription = p.MustHaveNumbers.GetDescriptionByBoolean(),
                          MustHaveSpecialCharsDescription = p.MustHaveSpecialChars.GetDescriptionByBoolean(),
                          MustHaveUpperCaseLetterDescription = p.MustHaveUpperCaseLetter.GetDescriptionByBoolean(),
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }
}
