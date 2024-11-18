using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Configuration;

public class LayoutSettingsService : GenericService, ILayoutSettingsService
{
    private readonly ILayoutSettingsRepository _iLayoutSettingsRepository;
    private EnvironmentVariables _environmentVariables;

    public LayoutSettingsService(
        ILayoutSettingsRepository iLayoutSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables)
        : base(iNotificationMessageService)
    {
        _iLayoutSettingsRepository = iLayoutSettingsRepository;
        _environmentVariables = environmentVariables;
    }

    public async Task<IEnumerable<LayoutSettingsResponseDTO>> GetAllLayoutSettingsAsync()
    {
        try
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
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<LayoutSettingsResponseDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<LayoutSettingsResponseDTO> GetLayoutSettingsByEnvironmentAsync()
    {
        try
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

    public async Task<LayoutSettingsResponseDTO> GetLayoutSettingsByIdAsync(long id)
    {
        try
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

    public async Task<bool> CreateLayoutSettingsAsync(LayoutSettings layoutSettings)
    {
        try
        {
            _iLayoutSettingsRepository.Create(layoutSettings);
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

    public async Task<bool> UpdateLayoutSettingsAsync(LayoutSettings layoutSettings)
    {
        try
        {
            LayoutSettings layoutSettingsDb = _iLayoutSettingsRepository.GetById(layoutSettings.Id.Value);

            if (GuardClauses.ObjectIsNotNull(layoutSettingsDb))
            {
                if (layoutSettingsDb.Status)
                {
                    layoutSettingsDb.UpdateDate = layoutSettings.UpdateDate;
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

    public async Task<bool> LogicDeleteLayoutSettingsByIdAsync(long id)
    {
        try
        {
            LayoutSettings layoutSettingsDb = _iLayoutSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(layoutSettingsDb))
            {
                layoutSettingsDb.UpdateDate = layoutSettingsDb.GetNewUpdateDate();
                layoutSettingsDb.Status = false;
                _iLayoutSettingsRepository.Update(layoutSettingsDb);
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

    public async Task<bool> ReactiveLayoutSettingsByIdAsync(long id)
    {
        try
        {
            LayoutSettings layoutSettingsDb = _iLayoutSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(layoutSettingsDb))
            {
                layoutSettingsDb.UpdateDate = layoutSettingsDb.GetNewUpdateDate();
                layoutSettingsDb.Status = true;
                _iLayoutSettingsRepository.Update(layoutSettingsDb);
                return true;
            }
            else
            {
                Notify(FixConstants.ERROR_IN_UPDATESTATUS);
                return false;
            }
        }
        catch (Exception)
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<IEnumerable<LayoutSettingsExcelDTO>> GetAllLayoutSettingsExcelAsync()
    {
        try
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
                              StatusDescription = p.GetStatusDescription()
                          }).ToListAsync();
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return Enumerable.Empty<LayoutSettingsExcelDTO>();
        }
        finally
        {
            await Task.CompletedTask;
        }
    }
}
