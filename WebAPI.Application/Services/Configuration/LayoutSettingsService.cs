using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;

namespace WebAPI.Application.Services.Configuration;

public sealed class LayoutSettingsService : BaseHandlerService, ILayoutSettingsService
{
    private readonly ILayoutSettingsRepository _iLayoutSettingsRepository;
    private EnvironmentVariables _environmentVariables;
    private readonly IMapperService _iMapperService;

    public LayoutSettingsService(
        ILayoutSettingsRepository iLayoutSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables,
        IMapperService iMapperService)
        : base(iNotificationMessageService)
    {
        _iLayoutSettingsRepository = iLayoutSettingsRepository;
        _environmentVariables = environmentVariables;
        _iMapperService = iMapperService;
    }

    public async Task<IEnumerable<LayoutSettingsResponseDTO>> GetAllLayoutSettingsAsync()
    {
        return await (from p in _iLayoutSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                      orderby p.EnvironmentTypeSettings.Id ascending
                      select new LayoutSettingsResponseDTO()
                      {
                          Id = p.Id.Value,
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          DocumentFileContentToUpload = p.DocumentFileContentToUpload,
                          ImageFileContentToUpload = p.ImageFileContentToUpload,
                          MaxDocumentFileSize = p.MaxDocumentFileSize,
                          MaxImageFileSize = p.MaxImageFileSize,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }

    public async Task<LayoutSettingsResponseDTO> GetLayoutSettingsByEnvironmentAsync()
    {
        return await (from p in _iLayoutSettingsRepository.FindBy(x => x.IdEnvironmentType == (int)_environmentVariables.Environment).AsQueryable()
                      select new LayoutSettingsResponseDTO
                      {
                          Id = p.Id.Value,
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          DocumentFileContentToUpload = p.DocumentFileContentToUpload,
                          ImageFileContentToUpload = p.ImageFileContentToUpload,
                          MaxDocumentFileSize = p.MaxDocumentFileSize,
                          MaxImageFileSize = p.MaxImageFileSize,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
    }

    public async Task<LayoutSettingsResponseDTO> GetLayoutSettingsByIdAsync(long id)
    {
        return await (from p in _iLayoutSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                      select new LayoutSettingsResponseDTO
                      {
                          Id = p.Id.Value,
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          DocumentFileContentToUpload = p.DocumentFileContentToUpload,
                          ImageFileContentToUpload = p.ImageFileContentToUpload,
                          MaxDocumentFileSize = p.MaxDocumentFileSize,
                          MaxImageFileSize = p.MaxImageFileSize,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
    }

    public async Task<bool> ExistLayoutSettingsByEnvironmentAsync()
    {
        var result = _iLayoutSettingsRepository.Exist(x => x.IdEnvironmentType == (int)_environmentVariables.Environment);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> ExistLayoutSettingsByIdAsync(long id)
    {
        var result = _iLayoutSettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateLayoutSettingsAsync(LayoutSettingsCreateRequestDTO layoutSettingsCreateRequestDTO)
    {
        LayoutSettings layoutSettings = _iMapperService.MapDTOToEntity<LayoutSettingsCreateRequestDTO, LayoutSettings>(layoutSettingsCreateRequestDTO);
        _iLayoutSettingsRepository.Create(layoutSettings);
        return true;
    }

    public async Task<bool> UpdateLayoutSettingsAsync(LayoutSettingsUpdateRequestDTO layoutSettingsUpdateRequestDTO)
    {
        LayoutSettings layoutSettings = _iMapperService.MapDTOToEntity<LayoutSettingsUpdateRequestDTO, LayoutSettings>(layoutSettingsUpdateRequestDTO);
        LayoutSettings layoutSettingsDb = _iLayoutSettingsRepository.GetById(layoutSettings.Id.Value);

        if (GuardClauseExtension.IsNotNull(layoutSettingsDb))
        {
            if (layoutSettingsDb.IsActive.Value)
            {
                layoutSettingsDb.UpdatedAt = layoutSettings.UpdatedAt;
                layoutSettingsDb.DocumentFileContentToUpload = layoutSettings.DocumentFileContentToUpload;
                layoutSettingsDb.ImageFileContentToUpload = layoutSettings.ImageFileContentToUpload;
                layoutSettingsDb.MaxDocumentFileSize = layoutSettings.MaxDocumentFileSize;
                layoutSettingsDb.MaxImageFileSize = layoutSettings.MaxImageFileSize;
                layoutSettingsDb.IdEnvironmentType = layoutSettings.IdEnvironmentType;
                _iLayoutSettingsRepository.Update(layoutSettingsDb);
                return true;
            }

            Notify(FixConstants.ERROR_IN_UPDATE);
            return false;
        }

        Notify(FixConstants.ERROR_IN_UPDATE);
        return false;
    }

    public async Task<bool> LogicDeleteLayoutSettingsByIdAsync(long id)
    {
        LayoutSettings layoutSettingsDb = _iLayoutSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(layoutSettingsDb))
        {
            layoutSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            layoutSettingsDb.IsActive = false;
            _iLayoutSettingsRepository.Update(layoutSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
    }

    public async Task<bool> ReactiveLayoutSettingsByIdAsync(long id)
    {
        LayoutSettings layoutSettingsDb = _iLayoutSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(layoutSettingsDb))
        {
            layoutSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            layoutSettingsDb.IsActive = true;
            _iLayoutSettingsRepository.Update(layoutSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
    }

    public async Task<IEnumerable<LayoutSettingsExcelDTO>> GetAllLayoutSettingsExcelAsync()
    {
        return await (from p in _iLayoutSettingsRepository.GetAllInclude("EnvironmentTypeSettings")
                      orderby p.EnvironmentTypeSettings.Id ascending
                      select new LayoutSettingsExcelDTO()
                      {
                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                          DocumentFileContentToUpload = p.DocumentFileContentToUpload,
                          ImageFileContentToUpload = p.ImageFileContentToUpload,
                          MaxDocumentFileSize = p.MaxDocumentFileSize,
                          MaxImageFileSize = p.MaxImageFileSize,
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).ToListAsync();
    }
}
