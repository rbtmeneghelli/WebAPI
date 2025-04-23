using WebAPI.Domain.CQRS.Command;
using WebAPI.Domain.CQRS.Queries;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.DTO.Configuration;
using WebAPI.Domain.DTO.ControlPanel;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Models;
using WebAPI.Domain.ValueObject;

namespace WebAPI.Application.Mapping;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        #region Mapeamentos do Usuário

        CreateMap<UserRequestCreateDTO, User>()
        .BeforeMap((source, dest) =>
        {
            dest.CreatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
            dest.UpdatedAt = null;
        })
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.IsActive, act => act.MapFrom(src => src.IsActive))
        .ForMember(dest => dest.IsAuthenticated, act => act.MapFrom(src => src.IsAuthenticated))
        .ForMember(dest => dest.LastPassword, act => act.MapFrom(src => src.LastPassword.ApplyTrim()))
        .ForMember(dest => dest.Login, act => act.MapFrom(src => src.Login.ApplyTrim()))
        .ForMember(dest => dest.Password, act => act.MapFrom(src => src.Password.ApplyTrim()))
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id));

        CreateMap<UserRequestUpdateDTO, User>()
        .BeforeMap((source, dest) =>
        {
            dest.CreatedAt = null;
            dest.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
        })
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.IsActive, act => act.MapFrom(src => src.IsActive))
        .ForMember(dest => dest.IsAuthenticated, act => act.MapFrom(src => src.IsAuthenticated))
        .ForMember(dest => dest.LastPassword, act => act.MapFrom(src => src.LastPassword.ApplyTrim()))
        .ForMember(dest => dest.Login, act => act.MapFrom(src => src.Login.ApplyTrim()))
        .ForMember(dest => dest.Password, act => act.MapFrom(src => src.Password.ApplyTrim()))
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id));

        CreateMap<User, UserResponseDTO>()
        .AfterMap((src, dest) => 
        {
            dest.Password = dest.IsActive.HasValue ? "**********" : string.Empty;
        })
        .ForMember(dest => dest.IsActive, act => act.MapFrom(src => src.IsActive))
        .ForMember(dest => dest.IsAuthenticated, act => act.MapFrom(src => src.IsAuthenticated))
        .ForMember(dest => dest.LastPassword, act => act.MapFrom(src => src.LastPassword.ApplyTrim()))
        .ForMember(dest => dest.Login, act => act.MapFrom(src => src.Login.ApplyTrim()))
        .ForMember(dest => dest.Password, act => act.MapFrom(src => src.Password.ApplyTrim())).ReverseMap();
        
        CreateMap<UserResponseDTO, UserExcelDTO>().ReverseMap();

        #endregion
        
        CreateMap<Log, LogResponseDTO>()
        .ForMember(dest => dest.Class, act => act.MapFrom(src => src.Class.ApplyTrim()))
        .ForMember(dest => dest.Method, act => act.MapFrom(src => src.Method.ApplyTrim()))
        .ForMember(dest => dest.MessageError, act => act.MapFrom(src => src.MessageError))
        .ForMember(dest => dest.Object, act => act.MapFrom(src => src.Object))
        .ForMember(dest => dest.UpdateTime, act => act.MapFrom(src => src.UpdateTime))
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id)).ReverseMap();

        CreateMap<Audit, AuditResponseDTO>()
        .ForMember(dest => dest.TableName, act => act.MapFrom(src => src.TableName.ApplyTrim()))
        .ForMember(dest => dest.ActionName, act => act.MapFrom(src => src.ActionName.ApplyTrim()))
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.KeyValues, act => act.MapFrom(src => src.KeyValues))
        .ForMember(dest => dest.NewValues, act => act.MapFrom(src => src.NewValues))
        .ForMember(dest => dest.OldValues, act => act.Condition(src => !string.IsNullOrEmpty(src.OldValues)))
        .ForMember(dest => dest.OldValues, act => act.MapFrom(src => src.OldValues)).ReverseMap();

        //TODO: Ajustar 
        //CreateMap<Audit, AuditResponseDTO>()
        //.ForMember(dest => dest.TableName, act => act.MapFrom(src => src.TableName.ApplyTrim()))
        //.ForMember(dest => dest.ActionName, act => act.MapFrom(src => src.ActionName.ApplyTrim()))
        //.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        //.ForMember(dest => dest.KeyValues, act => act.MapFrom(src => src.KeyValues))
        //.ForMember(dest => dest.NewValues, act => act.MapFrom(src => src.NewValues))
        //.ForMember(dest => dest.OldValues, act => act.MapFrom(src => src.OldValues)).ReverseMap();

        CreateMap<Region, RegionQueryFilterResponse>().ReverseMap();
        CreateMap<Region, RegionQueryByIdResponse>().ReverseMap();
        CreateMap<Region, CreateRegionCommandRequest>().ReverseMap();
        CreateMap<Region, UpdateRegionCommandRequest>().ReverseMap();

        CreateMap<AuthenticationSettingsCreateRequestDTO, AuthenticationSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.NumberOfTryToBlockUser, act => act.MapFrom(src => src.NumberOfTryToBlockUser))
        .ForMember(dest => dest.BlockUserTime, act => act.MapFrom(src => src.BlockUserTime))
        .ForMember(dest => dest.ApplyTwoFactoryValidation, act => act.MapFrom(src => src.ApplyTwoFactoryValidation))
        .ForMember(dest => dest.IdEnvironmentType, act => act.MapFrom(src => src.IdEnvironment))
        .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()))
        .ForMember(dest => dest.IsActive, act => act.MapFrom(src => true));

        CreateMap<AuthenticationSettingsUpdateRequestDTO, AuthenticationSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.NumberOfTryToBlockUser, act => act.MapFrom(src => src.NumberOfTryToBlockUser))
        .ForMember(dest => dest.BlockUserTime, act => act.MapFrom(src => src.BlockUserTime))
        .ForMember(dest => dest.ApplyTwoFactoryValidation, act => act.MapFrom(src => src.ApplyTwoFactoryValidation))
        .ForMember(dest => dest.IdEnvironmentType, act => act.MapFrom(src => src.IdEnvironment))
        .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()));

        CreateMap<ExpirationPasswordSettingsCreateRequestDTO, ExpirationPasswordSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.QtyDaysPasswordExpire, act => act.MapFrom(src => src.QtyDaysPasswordExpire))
        .ForMember(dest => dest.NotifyExpirationDays, act => act.MapFrom(src => src.NotifyExpirationDays))
        .ForMember(dest => dest.IdEnvironmentType, act => act.MapFrom(src => src.IdEnvironment))
        .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()))
        .ForMember(dest => dest.IsActive, act => act.MapFrom(src => true));

        CreateMap<ExpirationPasswordSettingsUpdateRequestDTO, ExpirationPasswordSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.QtyDaysPasswordExpire, act => act.MapFrom(src => src.QtyDaysPasswordExpire))
        .ForMember(dest => dest.NotifyExpirationDays, act => act.MapFrom(src => src.NotifyExpirationDays))
        .ForMember(dest => dest.IdEnvironmentType, act => act.MapFrom(src => src.IdEnvironment))
        .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()));

        CreateMap<RequiredPasswordSettingsCreateRequestDTO, RequiredPasswordSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.MinimalOfChars, act => act.MapFrom(src => src.MinimalOfChars))
        .ForMember(dest => dest.MustHaveNumbers, act => act.MapFrom(src => src.MustHaveNumbers))
        .ForMember(dest => dest.MustHaveSpecialChars, act => act.MapFrom(src => src.MustHaveSpecialChars))
        .ForMember(dest => dest.MustHaveUpperCaseLetter, act => act.MapFrom(src => src.MustHaveUpperCaseLetter))
        .ForMember(dest => dest.IdEnvironmentType, act => act.MapFrom(src => src.IdEnvironment))
        .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()))
        .ForMember(dest => dest.IsActive, act => act.MapFrom(src => true));

        CreateMap<RequiredPasswordSettingsUpdateRequestDTO, RequiredPasswordSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.MinimalOfChars, act => act.MapFrom(src => src.MinimalOfChars))
        .ForMember(dest => dest.MustHaveNumbers, act => act.MapFrom(src => src.MustHaveNumbers))
        .ForMember(dest => dest.MustHaveSpecialChars, act => act.MapFrom(src => src.MustHaveSpecialChars))
        .ForMember(dest => dest.MustHaveUpperCaseLetter, act => act.MapFrom(src => src.MustHaveUpperCaseLetter))
        .ForMember(dest => dest.IdEnvironmentType, act => act.MapFrom(src => src.IdEnvironment))
        .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()));

        CreateMap<LogSettingsCreateRequestDTO, LogSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.SaveLogUpdateData, act => act.MapFrom(src => src.SaveLogUpdateData))
        .ForMember(dest => dest.SaveLogResearchData, act => act.MapFrom(src => src.SaveLogResearchData))
        .ForMember(dest => dest.SaveLogCreateData, act => act.MapFrom(src => src.SaveLogCreateData))
        .ForMember(dest => dest.SaveLogDeleteData, act => act.MapFrom(src => src.SaveLogDeleteData))
        .ForMember(dest => dest.SaveLogTurnOffSystem, act => act.MapFrom(src => src.SaveLogTurnOffSystem))
        .ForMember(dest => dest.SaveLogTurnOnSystem, act => act.MapFrom(src => src.SaveLogTurnOnSystem))
        .ForMember(dest => dest.IdEnvironmentType, act => act.MapFrom(src => src.IdEnvironment))
        .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()))
        .ForMember(dest => dest.IsActive, act => act.MapFrom(src => true));

        CreateMap<LogSettingsUpdateRequestDTO, LogSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.SaveLogUpdateData, act => act.MapFrom(src => src.SaveLogUpdateData))
        .ForMember(dest => dest.SaveLogResearchData, act => act.MapFrom(src => src.SaveLogResearchData))
        .ForMember(dest => dest.SaveLogCreateData, act => act.MapFrom(src => src.SaveLogCreateData))
        .ForMember(dest => dest.SaveLogDeleteData, act => act.MapFrom(src => src.SaveLogDeleteData))
        .ForMember(dest => dest.SaveLogTurnOffSystem, act => act.MapFrom(src => src.SaveLogTurnOffSystem))
        .ForMember(dest => dest.SaveLogTurnOnSystem, act => act.MapFrom(src => src.SaveLogTurnOnSystem))
        .ForMember(dest => dest.IdEnvironmentType, act => act.MapFrom(src => src.IdEnvironment))
        .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()));

        CreateMap<EnvironmentTypeSettingsCreateRequestDTO, EnvironmentTypeSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.Description, act => act.MapFrom(src => src.EnvironmentDescription))
        .ForMember(dest => dest.Initials, act => act.MapFrom(src => src.EnvironmentInitial))
        .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()))
        .ForMember(dest => dest.IsActive, act => act.MapFrom(src => true));

        CreateMap<EnvironmentTypeSettingsUpdateRequestDTO, EnvironmentTypeSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.Description, act => act.MapFrom(src => src.EnvironmentDescription))
        .ForMember(dest => dest.Initials, act => act.MapFrom(src => src.EnvironmentInitial))
        .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()));

        CreateMap<EmailDisplaySettingsCreateRequestDTO, EmailDisplay>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
        .ForMember(dest => dest.Subject, act => act.MapFrom(src => src.Subject))
        .ForMember(dest => dest.Body, act => act.MapFrom(src => src.Body))
        .ForMember(dest => dest.MessagePriority, act => act.MapFrom(src => src.MessagePriority))
        .ForMember(dest => dest.HasAttachment, act => act.MapFrom(src => src.HasAttachment))
        .ForMember(dest => dest.EmailTemplateId, act => act.MapFrom(src => src.IdEmailTemplate))
        .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()))
        .ForMember(dest => dest.IsActive, act => act.MapFrom(src => true));

        CreateMap<EmailDisplaySettingsUpdateRequestDTO, EmailDisplay>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
        .ForMember(dest => dest.Subject, act => act.MapFrom(src => src.Subject))
        .ForMember(dest => dest.Body, act => act.MapFrom(src => src.Body))
        .ForMember(dest => dest.MessagePriority, act => act.MapFrom(src => src.MessagePriority))
        .ForMember(dest => dest.HasAttachment, act => act.MapFrom(src => src.HasAttachment))
        .ForMember(dest => dest.EmailTemplateId, act => act.MapFrom(src => src.IdEmailTemplate))
        .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()));

        CreateMap<EmailSettingsCreateRequestDTO, EmailSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.Host, act => act.MapFrom(src => src.Host))
        .ForMember(dest => dest.SmtpConfig, act => act.MapFrom(src => src.SmtpConfig))
        .ForMember(dest => dest.PrimaryPort, act => act.MapFrom(src => src.PrimaryPort))
        .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
        .ForMember(dest => dest.Password, act => act.MapFrom(src => CryptographyAesManager.ApplyEncrypt(src.Password)))
        .ForMember(dest => dest.EnableSsl, act => act.MapFrom(src => src.EnableSsl))
        .ForMember(dest => dest.IdEnvironmentType, act => act.MapFrom(src => src.IdEnvironment))
        .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()))
        .ForMember(dest => dest.IsActive, act => act.MapFrom(src => true));

        CreateMap<EmailSettingsUpdateRequestDTO, EmailSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.Host, act => act.MapFrom(src => src.Host))
        .ForMember(dest => dest.SmtpConfig, act => act.MapFrom(src => src.SmtpConfig))
        .ForMember(dest => dest.PrimaryPort, act => act.MapFrom(src => src.PrimaryPort))
        .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
        .ForMember(dest => dest.Password, act => act.MapFrom(src => CryptographyAesManager.ApplyEncrypt(src.Password)))
        .ForMember(dest => dest.EnableSsl, act => act.MapFrom(src => src.EnableSsl))
        .ForMember(dest => dest.IdEnvironmentType, act => act.MapFrom(src => src.IdEnvironment))
        .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()));

        CreateMap<LayoutSettingsCreateRequestDTO, LayoutSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.ImageFileContentToUpload, act => act.MapFrom(src => src.ImageFileContentToUpload))
        .ForMember(dest => dest.DocumentFileContentToUpload, act => act.MapFrom(src => src.DocumentFileContentToUpload))
        .ForMember(dest => dest.MaxDocumentFileSize, act => act.MapFrom(src => src.MaxDocumentFileSize))
        .ForMember(dest => dest.MaxImageFileSize, act => act.MapFrom(src => src.MaxImageFileSize))
        .ForMember(dest => dest.IdEnvironmentType, act => act.MapFrom(src => src.IdEnvironment))
        .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()))
        .ForMember(dest => dest.IsActive, act => act.MapFrom(src => true));

        CreateMap<LayoutSettingsUpdateRequestDTO, LayoutSettings>()
        .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
        .ForMember(dest => dest.ImageFileContentToUpload, act => act.MapFrom(src => src.ImageFileContentToUpload))
        .ForMember(dest => dest.DocumentFileContentToUpload, act => act.MapFrom(src => src.DocumentFileContentToUpload))
        .ForMember(dest => dest.MaxDocumentFileSize, act => act.MapFrom(src => src.MaxDocumentFileSize))
        .ForMember(dest => dest.MaxImageFileSize, act => act.MapFrom(src => src.MaxImageFileSize))
        .ForMember(dest => dest.IdEnvironmentType, act => act.MapFrom(src => src.IdEnvironment))
        .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => DateOnlyExtension.GetDateTimeNowFromBrazil()));

        #region Mapeamentos do Funcionario

        CreateMap<EmployeeRequestDTO, Employee>()
        .BeforeMap((source, dest) =>
        {
            dest.CreatedAt = source.Id is null ? DateOnlyExtension.GetDateTimeNowFromBrazil() : null;
            dest.UpdatedAt = source.Id is not null ? DateOnlyExtension.GetDateTimeNowFromBrazil() : null;
        })
        .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name.ApplyTrim()))
        .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email.ApplyTrim()))
        .ForMember(dest => dest.TelPhone, act => act.MapFrom(src => src.TelPhone.ApplyTrim()))
        .ForMember(dest => dest.CelPhone, act => act.MapFrom(src => src.CelPhone.ApplyTrim()))
        .ForMember(dest => dest.Salary, act => act.MapFrom(src => src.Salary))
        .ForMember(dest => dest.BirthDate, act => act.MapFrom(src => src.BirthDate))
        .ForMember(dest => dest.IdProfile, act => act.MapFrom(src => src.IdProfile))
        .ForMember(dest => dest.IdUser, act => act.MapFrom(src => src.IdUser));
        
        CreateMap<Employee, EmployeeResponseDTO>()
        .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name.ApplyTrim()))
        .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email.ApplyTrim()))
        .ForMember(dest => dest.TelPhone, act => act.MapFrom(src => src.TelPhone.ApplyTrim()))
        .ForMember(dest => dest.CelPhone, act => act.MapFrom(src => src.CelPhone.ApplyTrim()))
        .ForMember(dest => dest.Salary, act => act.MapFrom(src => src.Salary))
        .ForMember(dest => dest.SalaryAnual, act => act.MapFrom<AnualSalaryResolver>())
        .ForMember(dest => dest.BirthDate, act => act.MapFrom(src => src.BirthDate))
        .ForMember(dest => dest.Age, act => act.MapFrom<AgeResolver>()).ReverseMap();

        #endregion

        #region Mapeamentos do Produto (Quando temos um construtor com parametros imutaveis, podemos trabalhar da forma exemplificada abaixo)

        CreateMap<Product, ProductResponseDTO>()
        .ConstructUsing(src => new ProductResponseDTO
        {
            Id = src.Id,
            Name = src.Name,
            Price = src.Price,
        });

        #endregion

        CreateMap<AddressData, AddressDataDTO>().ReverseMap();
    }
}
