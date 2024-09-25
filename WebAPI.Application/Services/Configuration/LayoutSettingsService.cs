using Microsoft.AspNetCore.Http;
using NPOI.OpenXmlFormats.Dml;
using WebAPI.Application.Generic;
using WebAPI.Domain;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.EntitiesDTO.Configuration;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Configuration;

public class LayoutSettingsService : GenericService, ILayoutSettingsService
{
    private readonly ILayoutSettingsRepository _iLayoutSettingsRepository;
    private readonly GeneralMethod _generalMethod;
    private const string ERROR_UPLOAD = "Ocorreu um erro no upload do logo web. Tente novamente! \n O arquivo deve ser do tipo {0} e de tamanho maximo de {1}";

    public LayoutSettingsService(
        ILayoutSettingsRepository iLayoutSettingsRepository,
        INotificationMessageService iNotificationMessageService)
        : base(iNotificationMessageService)
    {
        _generalMethod = GeneralMethod.GetLoadExtensionMethods();
        _iLayoutSettingsRepository = iLayoutSettingsRepository;
    }

    public async Task<bool> CreateLayoutSettingsRequestDTO(LayoutSettingsCreateRequestDTO layoutSettingsCreateRequestDTO)
    {
        try
        {
            bool LogoWebValidation = _generalMethod.ValidateFile(layoutSettingsCreateRequestDTO.LogoWeb);
            bool LogoMobileValidation = _generalMethod.ValidateFile(layoutSettingsCreateRequestDTO.LogoMobile);
            bool BannerWebValidation = _generalMethod.ValidateFile(layoutSettingsCreateRequestDTO.BannerWeb);
            bool BannerMobileValidation = _generalMethod.ValidateFile(layoutSettingsCreateRequestDTO.BannerMobile);

            if (!LogoWebValidation)
                Notify(string.Format(ERROR_UPLOAD, layoutSettingsCreateRequestDTO.LogoWeb, ".Jpg,.png,.jpeg"));

            if (!LogoWebValidation)
                Notify(string.Format(ERROR_UPLOAD, layoutSettingsCreateRequestDTO.LogoWeb, ".Jpg,.png,.jpeg"));

            if (!LogoWebValidation)
                Notify(string.Format(ERROR_UPLOAD, layoutSettingsCreateRequestDTO.LogoWeb, ".Jpg,.png,.jpeg"));

            if (!LogoWebValidation)
                Notify(string.Format(ERROR_UPLOAD, layoutSettingsCreateRequestDTO.LogoWeb, ".Jpg,.png,.jpeg"));

            byte[] arrLogoWeb = await _generalMethod.SetFileToByteArray(layoutSettingsCreateRequestDTO.LogoWeb);
            byte[] arrLogoMobile = await _generalMethod.SetFileToByteArray(layoutSettingsCreateRequestDTO.LogoMobile);
            byte[] arrBannerWeb = await _generalMethod.SetFileToByteArray(layoutSettingsCreateRequestDTO.BannerWeb);
            byte[] arrBannerMobile = await _generalMethod.SetFileToByteArray(layoutSettingsCreateRequestDTO.BannerMobile);

            LayoutSettings layoutSettings = new LayoutSettings()
            {
                LogoWeb = arrLogoWeb,
                LogoMobile = arrLogoMobile,
                BannerWeb = arrBannerWeb,
                BannerMobile = arrBannerMobile,
                CreateDate = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(),
                DocumentFileContentToUpload = "sfsdf",
                IdEnvironmentType = layoutSettingsCreateRequestDTO.IdEnvironment,
                ImageFileContentToUpload = "hfdsghfhd",
                MaxDocumentFileSize = 20,
                MaxImageFileSize = 20,
                Status = true
            };

            _iLayoutSettingsRepository.Create(layoutSettings);
            return true;
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_ADD);
            return false;
        }
    }

    public async Task<bool> UpdateLayoutSettingsRequestDTO(LayoutSettingsUpdateRequestDTO layoutSettingsUpdateRequestDTO)
    {
        try
        {
            var layoutSettingsDb = _iLayoutSettingsRepository.GetById(layoutSettingsUpdateRequestDTO.Id.Value);

            if (layoutSettingsDb is null)
            {
                Notify(FixConstants.ERROR_IN_RESEARCH);
                return false;
            }

            if (layoutSettingsDb.Status)
            {
                bool LogoWebValidation = ValidationFile(layoutSettingsUpdateRequestDTO.LogoWeb);
                bool LogoMobileValidation = ValidationFile(layoutSettingsUpdateRequestDTO.LogoWeb);
                bool BannerWebValidation = ValidationFile(layoutSettingsUpdateRequestDTO.LogoWeb);
                bool BannerMobileValidation = ValidationFile(layoutSettingsUpdateRequestDTO.LogoWeb);

                layoutSettingsDb.LogoWeb = await GetByteArray(LogoWebValidation, layoutSettingsUpdateRequestDTO.LogoWeb, layoutSettingsDb.LogoWeb);
                layoutSettingsDb.LogoMobile = await GetByteArray(LogoWebValidation, layoutSettingsUpdateRequestDTO.LogoWeb, layoutSettingsDb.LogoWeb);
                layoutSettingsDb.BannerWeb = await GetByteArray(LogoWebValidation, layoutSettingsUpdateRequestDTO.LogoWeb, layoutSettingsDb.LogoWeb);
                layoutSettingsDb.BannerMobile = await GetByteArray(LogoWebValidation, layoutSettingsUpdateRequestDTO.LogoWeb, layoutSettingsDb.LogoWeb);
                layoutSettingsDb.IdEnvironmentType = layoutSettingsUpdateRequestDTO.IdEnvironment;
                layoutSettingsDb.UpdateDate = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
                _iLayoutSettingsRepository.Update(layoutSettingsDb);
                return true;
            }

            Notify(FixConstants.ERROR_IN_UPDATE);
            return false;
        }
        catch (Exception ex)
        {
            Notify(FixConstants.ERROR_IN_UPDATE);
            return false;
        }

        return true;
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

    //public async Task<LayoutSettingsResponseDTO> GetLayoutSettingsByIdAsync(long id)
    //{
    //    try
    //    {
    //        return await (from p in _iRequiredPasswordSettingsRepository.FindBy(x => x.Id == id).AsQueryable()
    //                      select new RequiredPasswordSettingsResponseDTO
    //                      {
    //                          Id = p.Id.Value,
    //                          EnvironmentDescription = p.EnvironmentTypeSettings.Description,
    //                          MinimalOfChars = p.MinimalOfChars,
    //                          MustHaveNumbers = p.MustHaveNumbers,
    //                          MustHaveSpecialChars = p.MustHaveSpecialChars,
    //                          MustHaveUpperCaseLetter = p.MustHaveUpperCaseLetter,
    //                          StatusDescription = p.GetStatusDescription()
    //                      }).FirstOrDefaultAsync();
    //    }
    //    catch
    //    {
    //        Notify(FixConstants.ERROR_IN_GETID);
    //        return default;
    //    }
    //    finally
    //    {
    //        await Task.CompletedTask;
    //    }
    //}
}
