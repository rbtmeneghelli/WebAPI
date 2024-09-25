using Microsoft.AspNetCore.Http;
using NPOI.Util.ArrayExtensions;
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
            return await (from p in _iUploadSettingsRepository.FindBy(x => x.IdEnvironmentType == (int)_environmentVariables.Environment).AsQueryable()
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
            return await (from p in _iUploadSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
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
            double maxSizeFile = layoutSettings.MaxImageFileSize;

            bool LogoWebValidation = _generalMethod.ValidateFile(uploadSettingsCreateRequestDTO.LogoWeb, arrExtensions, maxSizeFile);
            bool LogoMobileValidation = _generalMethod.ValidateFile(uploadSettingsCreateRequestDTO.LogoMobile, arrExtensions, maxSizeFile);
            bool BannerWebValidation = _generalMethod.ValidateFile(uploadSettingsCreateRequestDTO.BannerWeb, arrExtensions, maxSizeFile);
            bool BannerMobileValidation = _generalMethod.ValidateFile(uploadSettingsCreateRequestDTO.BannerMobile, arrExtensions, maxSizeFile);

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
                LogoWebDescription = Path.GetFileNameWithoutExtension(uploadSettingsCreateRequestDTO.LogoWeb.FileName) ?? StringExtensionMethod.GetEmptyString(),
                LogoMobile = arrLogoMobile,
                LogoMobileDescription = Path.GetFileNameWithoutExtension(uploadSettingsCreateRequestDTO.LogoMobile.FileName) ?? StringExtensionMethod.GetEmptyString(),
                BannerWeb = arrBannerWeb,
                BannerWebDescription = Path.GetFileNameWithoutExtension(uploadSettingsCreateRequestDTO.BannerWeb.FileName) ?? StringExtensionMethod.GetEmptyString(),
                BannerMobile = arrBannerMobile,
                BannerMobileDescription = Path.GetFileNameWithoutExtension(uploadSettingsCreateRequestDTO.BannerMobile.FileName) ?? StringExtensionMethod.GetEmptyString(),
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
                    string[] arrExtensions = layoutSettings.ImageFileContentToUpload.Split(',');
                    double maxSizeFile = layoutSettings.MaxImageFileSize;

                    bool existLogoWeb = _generalMethod.ExistFile(uploadSettingsUpdateRequestDTO.LogoWeb);
                    bool existLogoMobile = _generalMethod.ExistFile(uploadSettingsUpdateRequestDTO.LogoMobile);
                    bool existBannerWeb = _generalMethod.ExistFile(uploadSettingsUpdateRequestDTO.BannerWeb);
                    bool existBannerMobile = _generalMethod.ExistFile(uploadSettingsUpdateRequestDTO.BannerMobile);

                    bool LogoWebValidation = existLogoWeb ?
                                             _generalMethod.ValidateFile(uploadSettingsUpdateRequestDTO.LogoWeb, arrExtensions, maxSizeFile) :
                                             true;

                    bool LogoMobileValidation = existLogoMobile ?
                                                 _generalMethod.ValidateFile(uploadSettingsUpdateRequestDTO.LogoMobile, arrExtensions, maxSizeFile) :
                                                true;

                    bool BannerWebValidation = existBannerWeb ?
                                                _generalMethod.ValidateFile(uploadSettingsUpdateRequestDTO.BannerWeb, arrExtensions, maxSizeFile) :
                                               true;

                    bool BannerMobileValidation = existBannerMobile ?
                                                   _generalMethod.ValidateFile(uploadSettingsUpdateRequestDTO.BannerMobile, arrExtensions, maxSizeFile) :
                                                  true;

                    if (!LogoWebValidation)
                    {
                        Notify(string.Format(ERROR_UPLOAD, uploadSettingsUpdateRequestDTO.LogoWeb, layoutSettings));
                        return false;
                    }

                    if (!LogoMobileValidation)
                    {
                        Notify(string.Format(ERROR_UPLOAD, uploadSettingsUpdateRequestDTO.LogoMobile, arrExtensions));
                        return false;
                    }

                    if (!BannerWebValidation)
                    {
                        Notify(string.Format(ERROR_UPLOAD, uploadSettingsUpdateRequestDTO.BannerWeb, arrExtensions));
                        return false;
                    }

                    if (!BannerMobileValidation)
                    {
                        Notify(string.Format(ERROR_UPLOAD, uploadSettingsUpdateRequestDTO.BannerMobile, arrExtensions));
                        return false;
                    }

                    if (existLogoWeb)
                    {
                        uploadSettingsDb.LogoWeb = await GetByteArray(LogoWebValidation, uploadSettingsUpdateRequestDTO.LogoWeb, uploadSettingsDb.LogoWeb);
                        uploadSettingsDb.LogoWebDescription = Path.GetFileNameWithoutExtension(uploadSettingsUpdateRequestDTO.LogoWeb.FileName ?? StringExtensionMethod.GetEmptyString());
                    }

                    if (existLogoMobile)
                    {
                        uploadSettingsDb.LogoMobile = await GetByteArray(LogoWebValidation, uploadSettingsUpdateRequestDTO.LogoMobile, uploadSettingsDb.LogoMobile);
                        uploadSettingsDb.LogoMobileDescription = Path.GetFileNameWithoutExtension(uploadSettingsUpdateRequestDTO.LogoMobile.FileName ?? StringExtensionMethod.GetEmptyString());
                    }

                    if (existBannerWeb)
                    {
                        uploadSettingsDb.BannerWeb = await GetByteArray(LogoWebValidation, uploadSettingsUpdateRequestDTO.BannerWeb, uploadSettingsDb.BannerWeb);
                        uploadSettingsDb.BannerWebDescription = Path.GetFileNameWithoutExtension(uploadSettingsUpdateRequestDTO.BannerWeb.FileName ?? StringExtensionMethod.GetEmptyString());
                    }

                    if (existBannerMobile)
                    {
                        uploadSettingsDb.BannerMobile = await GetByteArray(LogoWebValidation, uploadSettingsUpdateRequestDTO.BannerMobile, uploadSettingsDb.BannerMobile);
                        uploadSettingsDb.BannerMobileDescription = Path.GetFileNameWithoutExtension(uploadSettingsUpdateRequestDTO.BannerMobile.FileName ?? StringExtensionMethod.GetEmptyString());
                    }


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

