using Microsoft.AspNetCore.Http;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.EntitiesDTO.Configuration;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Configuration;

public class UploadSettingsService : GenericService, IUploadSettingsService
{
    private readonly IUploadSettingsRepository _iUploadSettingsRepository;
    private readonly ILayoutSettingsRepository _iLayoutSettingsRepository;
    private readonly GeneralMethod _generalMethod;
    private EnvironmentVariables _environmentVariables;

    private const string ERROR_UPLOAD = "Ocorreu um erro no upload do logo web. Tente novamente! \n O arquivo deve ser do tipo {0} e de tamanho maximo de {1}";

    public UploadSettingsService(
        IUploadSettingsRepository iUploadSettingsRepository,
        ILayoutSettingsRepository iLayoutSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables)
        : base(iNotificationMessageService)

    {
        _generalMethod = GeneralMethod.GetLoadExtensionMethods();
        _iUploadSettingsRepository = iUploadSettingsRepository;
        _iLayoutSettingsRepository = iLayoutSettingsRepository;
        _environmentVariables = environmentVariables;
    }

    public async Task<UploadSettingsResponseDTO> GetUploadSettingsByEnvironmentAsync()
    {
        try
        {
            return await(from p in _iUploadSettingsRepository.FindBy(x => x.IdEnvironmentType == (int)_environmentVariables.Environment).AsQueryable()
                         select new UploadSettingsResponseDTO
                         {
                             Id = p.Id.Value,
                             EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                             LogoWeb = p.LogoWeb,
                             LogoWebDescription = p.LogoWebDescription,
                             LogoMobile = p.LogoMobile,
                             LogoMobileDescription = p.LogoMobileDescription,
                             BannerWeb = p.BannerWeb,
                             BannerWebDescription = p.BannerWebDescription,
                             BannerMobile = p.BannerMobile,
                             BannerMobileDescription = p.BannerMobileDescription,
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

    public async Task<UploadSettingsResponseDTO> GetUploadSettingsByIdAsync(long id)
    {
        try
        {
            return await(from p in _iUploadSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
                         select new UploadSettingsResponseDTO
                         {
                             Id = p.Id.Value,
                             EnvironmentDescription = p.EnvironmentTypeSettings.Description,
                             LogoWeb = p.LogoWeb,
                             LogoWebDescription = p.LogoWebDescription,
                             LogoMobile = p.LogoMobile,
                             LogoMobileDescription = p.LogoMobileDescription,
                             BannerWeb = p.BannerWeb,
                             BannerWebDescription = p.BannerWebDescription,
                             BannerMobile = p.BannerMobile,
                             BannerMobileDescription = p.BannerMobileDescription,           
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

    public async Task<bool> ExistUploadSettingsByEnvironmentAsync()
    {
        var result = _iUploadSettingsRepository.Exist(x => x.IdEnvironmentType == (int)_environmentVariables.Environment);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> ExistUploadSettingsByIdAsync(long id)
    {
        var result = _iUploadSettingsRepository.Exist(x => x.Id == id);
        await Task.CompletedTask;
        return result;
    }

    public async Task<bool> CreateUploadSettingsAsync(UploadSettingsCreateRequestDTO uploadSettingsCreateRequestDTO)
    {
        try
        {
            LayoutSettings layoutSettings = _iLayoutSettingsRepository
                                            .FindBy(x => x.IdEnvironmentType == uploadSettingsCreateRequestDTO.IdEnvironment && x.Status)
                                            .FirstOrDefault();

            if (GuardClauses.ObjectIsNull(layoutSettings))
            {
                Notify(FixConstants.SUCCESS_IN_NOTFOUND);
                return false;
            }

            string[] arrExtensions = layoutSettings.ImageFileContentToUpload.Split(',');
            bool LogoWebValidation = _generalMethod.ValidateFile(uploadSettingsCreateRequestDTO.LogoWeb);
            bool LogoMobileValidation = _generalMethod.ValidateFile(uploadSettingsCreateRequestDTO.LogoMobile);
            bool BannerWebValidation = _generalMethod.ValidateFile(uploadSettingsCreateRequestDTO.BannerWeb);
            bool BannerMobileValidation = _generalMethod.ValidateFile(uploadSettingsCreateRequestDTO.BannerMobile);

            if (!LogoWebValidation)
            {
                Notify(string.Format(ERROR_UPLOAD, uploadSettingsCreateRequestDTO.LogoWeb, layoutSettings));
                return false;
            }

            if (!LogoMobileValidation)
            {
                Notify(string.Format(ERROR_UPLOAD, uploadSettingsCreateRequestDTO.LogoMobile, arrExtensions));
                return false;
            }

            if (!BannerWebValidation)
            {
                Notify(string.Format(ERROR_UPLOAD, uploadSettingsCreateRequestDTO.BannerWeb, arrExtensions));
                return false;
            }

            if (!BannerMobileValidation)
            {
                Notify(string.Format(ERROR_UPLOAD, uploadSettingsCreateRequestDTO.BannerMobile, arrExtensions));
                return false;
            }

            byte[] arrLogoWeb = await _generalMethod.SetFileToByteArray(uploadSettingsCreateRequestDTO.LogoWeb);
            byte[] arrLogoMobile = await _generalMethod.SetFileToByteArray(uploadSettingsCreateRequestDTO.LogoMobile);
            byte[] arrBannerWeb = await _generalMethod.SetFileToByteArray(uploadSettingsCreateRequestDTO.BannerWeb);
            byte[] arrBannerMobile = await _generalMethod.SetFileToByteArray(uploadSettingsCreateRequestDTO.BannerMobile);

            UploadSettings uploadSettings = new UploadSettings()
            {
                LogoWeb = arrLogoWeb,
                LogoWebDescription = uploadSettingsCreateRequestDTO.LogoWeb.FileName ?? string.Empty,
                LogoMobile = arrLogoMobile,
                LogoMobileDescription = uploadSettingsCreateRequestDTO.LogoMobile.FileName ?? string.Empty,
                BannerWeb = arrBannerWeb,
                BannerWebDescription = uploadSettingsCreateRequestDTO.BannerWeb.FileName ?? string.Empty,
                BannerMobile = arrBannerMobile,
                BannerMobileDescription = uploadSettingsCreateRequestDTO.BannerMobile.FileName ?? string.Empty,
                CreateDate = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(),
                Status = true,
                IdEnvironmentType = uploadSettingsCreateRequestDTO.IdEnvironment
            };

            _iUploadSettingsRepository.Create(uploadSettings);
            return true;
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_ADD);
            return false;
        }
    }

    public async Task<bool> UpdateUploadSettingsAsync(UploadSettingsUpdateRequestDTO uploadSettingsUpdateRequestDTO)
    {
        try
        {
            LayoutSettings layoutSettings = _iLayoutSettingsRepository
                                .FindBy(x => x.IdEnvironmentType == uploadSettingsUpdateRequestDTO.IdEnvironment && x.Status)
                                .FirstOrDefault();

            if (GuardClauses.ObjectIsNull(layoutSettings))
            {
                Notify(FixConstants.SUCCESS_IN_NOTFOUND);
                return false;
            }

            var uploadSettingsDb = _iUploadSettingsRepository.GetById(uploadSettingsUpdateRequestDTO.Id.Value);

            if (GuardClauses.ObjectIsNotNull(layoutSettings))
            {
                if (uploadSettingsDb.Status)
                {
                    bool LogoWebValidation = ValidationFile(uploadSettingsUpdateRequestDTO.LogoWeb);
                    bool LogoMobileValidation = ValidationFile(uploadSettingsUpdateRequestDTO.LogoMobile);
                    bool BannerWebValidation = ValidationFile(uploadSettingsUpdateRequestDTO.BannerWeb);
                    bool BannerMobileValidation = ValidationFile(uploadSettingsUpdateRequestDTO.BannerMobile);

                    uploadSettingsDb.LogoWeb = await GetByteArray(LogoWebValidation, uploadSettingsUpdateRequestDTO.LogoWeb, uploadSettingsDb.LogoWeb);
                    uploadSettingsDb.LogoMobile = await GetByteArray(LogoMobileValidation, uploadSettingsUpdateRequestDTO.LogoMobile, uploadSettingsDb.LogoMobile);
                    uploadSettingsDb.BannerWeb = await GetByteArray(BannerWebValidation, uploadSettingsUpdateRequestDTO.BannerWeb, uploadSettingsDb.BannerWeb);
                    uploadSettingsDb.BannerMobile = await GetByteArray(BannerMobileValidation, uploadSettingsUpdateRequestDTO.BannerMobile, uploadSettingsDb.BannerMobile);
                    uploadSettingsDb.IdEnvironmentType = uploadSettingsUpdateRequestDTO.IdEnvironment;
                    uploadSettingsDb.UpdateDate = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
                    _iUploadSettingsRepository.Update(uploadSettingsDb);
                    return true;
                }
                else
                {
                    Notify(FixConstants.ERROR_IN_UPDATE);
                    return false;
                }
            }
            else
            {
                Notify(FixConstants.SUCCESS_IN_NOTFOUND);
                return false;
            }
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_UPDATE);
            return false;
        }
    }

    public async Task<bool> LogicDeleteUploadSettingsByIdAsync(long id)
    {
        try
        {
            UploadSettings uploadSettingsDb = _iUploadSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(uploadSettingsDb))
            {
                uploadSettingsDb.UpdateDate = uploadSettingsDb.GetNewUpdateDate();
                uploadSettingsDb.Status = false;
                _iUploadSettingsRepository.Update(uploadSettingsDb);
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

    public async Task<bool> ReactiveUploadSettingsByIdAsync(long id)
    {
        try
        {
            UploadSettings uploadSettingsDb = _iUploadSettingsRepository.GetById(id);

            if (GuardClauses.ObjectIsNotNull(uploadSettingsDb))
            {
                uploadSettingsDb.UpdateDate = uploadSettingsDb.GetNewUpdateDate();
                uploadSettingsDb.Status = true;
                _iUploadSettingsRepository.Update(uploadSettingsDb);
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

    private bool ValidationFile(IFormFile formFile)
    {
        bool fileValidation = _generalMethod.ExistFile(formFile) ? _generalMethod.ValidateFile(formFile) : false;
        return fileValidation;
    }

    private async Task<byte[]> GetByteArray(bool fileValidation, IFormFile formFile, byte[] arrByteFileDb)
    {
        byte[] arrByteFile = new byte[0];

        if (fileValidation)
        {
            arrByteFile = await _generalMethod.SetFileToByteArray(formFile);
            return arrByteFile;
        }

        return arrByteFileDb;
    }
}

