using Microsoft.AspNetCore.Http;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;

namespace WebAPI.Application.Services.Configuration;

public sealed class UploadSettingsService : BaseHandlerService, IUploadSettingsService
{
    private readonly IUploadSettingsRepository _iUploadSettingsRepository;
    private readonly ILayoutSettingsRepository _iLayoutSettingsRepository;
    private EnvironmentVariables _environmentVariables;

    private const string ERROR_UPLOAD = "Ocorreu um erro no upload do logo web. Tente novamente! \n O arquivo deve ser do tipo {0} e de tamanho maximo de {1}";

    public UploadSettingsService(
        IUploadSettingsRepository iUploadSettingsRepository,
        ILayoutSettingsRepository iLayoutSettingsRepository,
        INotificationMessageService iNotificationMessageService,
        EnvironmentVariables environmentVariables)
        : base(iNotificationMessageService)

    {
        _iUploadSettingsRepository = iUploadSettingsRepository;
        _iLayoutSettingsRepository = iLayoutSettingsRepository;
        _environmentVariables = environmentVariables;
    }

    public async Task<UploadSettingsResponseDTO> GetUploadSettingsByEnvironmentAsync()
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
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
    }

    public async Task<UploadSettingsResponseDTO> GetUploadSettingsByIdAsync(long id)
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
                          StatusDescription = p.IsActive.GetDescriptionByBoolean()
                      }).FirstOrDefaultAsync();
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
        LayoutSettings layoutSettings = _iLayoutSettingsRepository
                                        .FindBy(x => x.IdEnvironmentType == uploadSettingsCreateRequestDTO.IdEnvironment && x.IsActive.Value)
                                        .FirstOrDefault();

        if (GuardClauseExtension.IsNull(layoutSettings))
        {
            Notify(FixConstants.SUCCESS_IN_NOTFOUND);
            return false;
        }

        string[] arrExtensions = layoutSettings.ImageFileContentToUpload.Split(',');
        double maxSizeFile = layoutSettings.MaxImageFileSize;

        bool LogoWebValidation = SharedExtension.ValidateFile(uploadSettingsCreateRequestDTO.LogoWeb, arrExtensions, maxSizeFile);
        bool LogoMobileValidation = SharedExtension.ValidateFile(uploadSettingsCreateRequestDTO.LogoMobile, arrExtensions, maxSizeFile);
        bool BannerWebValidation = SharedExtension.ValidateFile(uploadSettingsCreateRequestDTO.BannerWeb, arrExtensions, maxSizeFile);
        bool BannerMobileValidation = SharedExtension.ValidateFile(uploadSettingsCreateRequestDTO.BannerMobile, arrExtensions, maxSizeFile);

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

        byte[] arrLogoWeb = await SharedExtension.SetFileToByteArray(uploadSettingsCreateRequestDTO.LogoWeb);
        byte[] arrLogoMobile = await SharedExtension.SetFileToByteArray(uploadSettingsCreateRequestDTO.LogoMobile);
        byte[] arrBannerWeb = await SharedExtension.SetFileToByteArray(uploadSettingsCreateRequestDTO.BannerWeb);
        byte[] arrBannerMobile = await SharedExtension.SetFileToByteArray(uploadSettingsCreateRequestDTO.BannerMobile);

        UploadSettings uploadSettings = new UploadSettings()
        {
            LogoWeb = arrLogoWeb,
            LogoWebDescription = Path.GetFileNameWithoutExtension(uploadSettingsCreateRequestDTO.LogoWeb.FileName) ?? string.Empty,
            LogoMobile = arrLogoMobile,
            LogoMobileDescription = Path.GetFileNameWithoutExtension(uploadSettingsCreateRequestDTO.LogoMobile.FileName) ?? string.Empty,
            BannerWeb = arrBannerWeb,
            BannerWebDescription = Path.GetFileNameWithoutExtension(uploadSettingsCreateRequestDTO.BannerWeb.FileName) ?? string.Empty,
            BannerMobile = arrBannerMobile,
            BannerMobileDescription = Path.GetFileNameWithoutExtension(uploadSettingsCreateRequestDTO.BannerMobile.FileName) ?? string.Empty,
            CreatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil(),
            IsActive = true,
            IdEnvironmentType = uploadSettingsCreateRequestDTO.IdEnvironment
        };

        _iUploadSettingsRepository.Create(uploadSettings);
        return true;
    }

    public async Task<bool> UpdateUploadSettingsAsync(UploadSettingsUpdateRequestDTO uploadSettingsUpdateRequestDTO)
    {
        try
        {
            LayoutSettings layoutSettings = _iLayoutSettingsRepository
                                .FindBy(x => x.IdEnvironmentType == uploadSettingsUpdateRequestDTO.IdEnvironment && x.IsActive.Value)
                                .FirstOrDefault();

            if (GuardClauseExtension.IsNull(layoutSettings))
            {
                Notify(FixConstants.SUCCESS_IN_NOTFOUND);
                return false;
            }

            var uploadSettingsDb = _iUploadSettingsRepository.GetById(uploadSettingsUpdateRequestDTO.Id.Value);

            if (GuardClauseExtension.IsNotNull(layoutSettings))
            {
                if (uploadSettingsDb.IsActive.Value)
                {
                    string[] arrExtensions = layoutSettings.ImageFileContentToUpload.Split(',');
                    double maxSizeFile = layoutSettings.MaxImageFileSize;

                    bool existLogoWeb = SharedExtension.ExistFile(uploadSettingsUpdateRequestDTO.LogoWeb);
                    bool existLogoMobile = SharedExtension.ExistFile(uploadSettingsUpdateRequestDTO.LogoMobile);
                    bool existBannerWeb = SharedExtension.ExistFile(uploadSettingsUpdateRequestDTO.BannerWeb);
                    bool existBannerMobile = SharedExtension.ExistFile(uploadSettingsUpdateRequestDTO.BannerMobile);

                    bool LogoWebValidation = existLogoWeb ?
                                             SharedExtension.ValidateFile(uploadSettingsUpdateRequestDTO.LogoWeb, arrExtensions, maxSizeFile) :
                                             true;

                    bool LogoMobileValidation = existLogoMobile ?
                                                 SharedExtension.ValidateFile(uploadSettingsUpdateRequestDTO.LogoMobile, arrExtensions, maxSizeFile) :
                                                true;

                    bool BannerWebValidation = existBannerWeb ?
                                                SharedExtension.ValidateFile(uploadSettingsUpdateRequestDTO.BannerWeb, arrExtensions, maxSizeFile) :
                                               true;

                    bool BannerMobileValidation = existBannerMobile ?
                                                   SharedExtension.ValidateFile(uploadSettingsUpdateRequestDTO.BannerMobile, arrExtensions, maxSizeFile) :
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
                        uploadSettingsDb.LogoWebDescription = Path.GetFileNameWithoutExtension(uploadSettingsUpdateRequestDTO.LogoWeb.FileName ?? string.Empty);
                    }

                    if (existLogoMobile)
                    {
                        uploadSettingsDb.LogoMobile = await GetByteArray(LogoWebValidation, uploadSettingsUpdateRequestDTO.LogoMobile, uploadSettingsDb.LogoMobile);
                        uploadSettingsDb.LogoMobileDescription = Path.GetFileNameWithoutExtension(uploadSettingsUpdateRequestDTO.LogoMobile.FileName ?? string.Empty);
                    }

                    if (existBannerWeb)
                    {
                        uploadSettingsDb.BannerWeb = await GetByteArray(LogoWebValidation, uploadSettingsUpdateRequestDTO.BannerWeb, uploadSettingsDb.BannerWeb);
                        uploadSettingsDb.BannerWebDescription = Path.GetFileNameWithoutExtension(uploadSettingsUpdateRequestDTO.BannerWeb.FileName ?? string.Empty);
                    }

                    if (existBannerMobile)
                    {
                        uploadSettingsDb.BannerMobile = await GetByteArray(LogoWebValidation, uploadSettingsUpdateRequestDTO.BannerMobile, uploadSettingsDb.BannerMobile);
                        uploadSettingsDb.BannerMobileDescription = Path.GetFileNameWithoutExtension(uploadSettingsUpdateRequestDTO.BannerMobile.FileName ?? string.Empty);
                    }


                    uploadSettingsDb.IdEnvironmentType = uploadSettingsUpdateRequestDTO.IdEnvironment;
                    uploadSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
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
        UploadSettings uploadSettingsDb = _iUploadSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(uploadSettingsDb))
        {
            uploadSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            uploadSettingsDb.IsActive = false;
            _iUploadSettingsRepository.Update(uploadSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_DELETELOGIC);
            return false;
        }
    }

    public async Task<bool> ReactiveUploadSettingsByIdAsync(long id)
    {
        UploadSettings uploadSettingsDb = _iUploadSettingsRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(uploadSettingsDb))
        {
            uploadSettingsDb.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            uploadSettingsDb.IsActive = true;
            _iUploadSettingsRepository.Update(uploadSettingsDb);
            return true;
        }
        else
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
    }

    private async Task<byte[]> GetByteArray(bool fileValidation, IFormFile formFile, byte[] arrByteFileDb)
    {
        byte[] arrByteFile = new byte[0];

        if (fileValidation)
        {
            arrByteFile = await SharedExtension.SetFileToByteArray(formFile);
            return arrByteFile;
        }

        return arrByteFileDb;
    }
}

