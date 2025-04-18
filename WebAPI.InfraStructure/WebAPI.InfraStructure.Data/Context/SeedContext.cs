using Microsoft.EntityFrameworkCore;
using MimeKit;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Entities.Configuration;
using WebAPI.Domain.Entities.Others;
using FastPackForShare.Extensions;
using WebAPI.Domain.Models.Factory.Email;

namespace WebAPI.InfraStructure.Data.Context;

public static class SeedContext
{
    private const bool STATUS_TRUE = true;
    private const bool STATUS_FALSE = false;
    private static DateTime _currentDate;

    #region Configuration Seeds

    private static void SeedEnvironmentType(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnvironmentTypeSettings>().HasData(
           new EnvironmentTypeSettings() { Id = (int)EnumEnvironment.PRD, Description = "Ambiente Produção", CreateDate = _currentDate, Status = STATUS_TRUE, Initials = "PRD" },
           new EnvironmentTypeSettings() { Id = (int)EnumEnvironment.PRE_PROD, Description = "Ambiente PréProdução", CreateDate = _currentDate, Status = STATUS_TRUE, Initials = "PREPRD" },
           new EnvironmentTypeSettings() { Id = (int)EnumEnvironment.HML, Description = "Ambiente Homologação", CreateDate = _currentDate, Status = STATUS_TRUE, Initials = "HML" },
           new EnvironmentTypeSettings() { Id = (int)EnumEnvironment.QA, Description = "Ambiente QA", CreateDate = _currentDate, Status = STATUS_TRUE, Initials = "QA" },
           new EnvironmentTypeSettings() { Id = (int)EnumEnvironment.DEV, Description = "Ambiente DEV", CreateDate = _currentDate, Status = STATUS_TRUE, Initials = "DEV" }
        );
    }

    private static void SeedEmailSettings(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmailSettings>().HasData(
           new EmailSettings() { Id = 1, Host = "Gmail", SmtpConfig = "smtp.gmail.com", PrimaryPort = 25, Email = "teste@gmail.com", Password = CryptographyAesService.ApplyEncrypt("123Mudar"), EnableSsl = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.DEV },
           new EmailSettings() { Id = 2, Host = "Outlook", SmtpConfig = "smtp.office365.com", PrimaryPort = 25, Email = "teste@gmail.com", Password = CryptographyAesService.ApplyEncrypt("123Mudar"), EnableSsl = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.DEV },
           new EmailSettings() { Id = 3, Host = "Hotmail", SmtpConfig = "smtp.live.com", PrimaryPort = 25, Email = "teste@gmail.com", Password = CryptographyAesService.ApplyEncrypt("123Mudar"), EnableSsl = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.DEV }
        );
    }

    private static void SeedAuthenticationSettings(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthenticationSettings>().HasData(
           new AuthenticationSettings() { Id = (int)EnumEnvironment.PRD, NumberOfTryToBlockUser = 3, BlockUserTime = 60, ApplyTwoFactoryValidation = false, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.PRD },
           new AuthenticationSettings() { Id = (int)EnumEnvironment.PRE_PROD, NumberOfTryToBlockUser = 3, BlockUserTime = 60, ApplyTwoFactoryValidation = false, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.PRE_PROD },
           new AuthenticationSettings() { Id = (int)EnumEnvironment.HML, NumberOfTryToBlockUser = 3, BlockUserTime = 60, ApplyTwoFactoryValidation = false, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.HML },
           new AuthenticationSettings() { Id = (int)EnumEnvironment.QA, NumberOfTryToBlockUser = 3, BlockUserTime = 60, ApplyTwoFactoryValidation = false, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.QA },
           new AuthenticationSettings() { Id = (int)EnumEnvironment.DEV, NumberOfTryToBlockUser = 3, BlockUserTime = 60, ApplyTwoFactoryValidation = false, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.DEV }
        );
    }

    private static void SeedExpirationPasswordSettings(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpirationPasswordSettings>().HasData(
           new ExpirationPasswordSettings() { Id = (int)EnumEnvironment.PRD, QtyDaysPasswordExpire = 90, NotifyExpirationDays = 5, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.PRD },
           new ExpirationPasswordSettings() { Id = (int)EnumEnvironment.PRE_PROD, QtyDaysPasswordExpire = 90, NotifyExpirationDays = 5, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.PRE_PROD },
           new ExpirationPasswordSettings() { Id = (int)EnumEnvironment.HML, QtyDaysPasswordExpire = 90, NotifyExpirationDays = 5, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.HML },
           new ExpirationPasswordSettings() { Id = (int)EnumEnvironment.QA, QtyDaysPasswordExpire = 90, NotifyExpirationDays = 5, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.QA },
           new ExpirationPasswordSettings() { Id = (int)EnumEnvironment.DEV, QtyDaysPasswordExpire = 90, NotifyExpirationDays = 5, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.DEV }
        );
    }

    private static void SeedLogSettings(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LogSettings>().HasData(
           new LogSettings() { Id = (int)EnumEnvironment.PRD, SaveLogTurnOnSystem = false, SaveLogTurnOffSystem = false, SaveLogCreateData = true, SaveLogResearchData = true, SaveLogUpdateData = true, SaveLogDeleteData = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.PRD },
           new LogSettings() { Id = (int)EnumEnvironment.PRE_PROD, SaveLogTurnOnSystem = false, SaveLogTurnOffSystem = false, SaveLogCreateData = true, SaveLogResearchData = true, SaveLogUpdateData = true, SaveLogDeleteData = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.PRE_PROD },
           new LogSettings() { Id = (int)EnumEnvironment.HML, SaveLogTurnOnSystem = false, SaveLogTurnOffSystem = false, SaveLogCreateData = true, SaveLogResearchData = true, SaveLogUpdateData = true, SaveLogDeleteData = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.HML },
           new LogSettings() { Id = (int)EnumEnvironment.QA, SaveLogTurnOnSystem = false, SaveLogTurnOffSystem = false, SaveLogCreateData = true, SaveLogResearchData = true, SaveLogUpdateData = true, SaveLogDeleteData = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.QA },
           new LogSettings() { Id = (int)EnumEnvironment.DEV, SaveLogTurnOnSystem = false, SaveLogTurnOffSystem = false, SaveLogCreateData = true, SaveLogResearchData = true, SaveLogUpdateData = true, SaveLogDeleteData = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.DEV }
        );
    }

    private static void SeedRequiredPasswordSettings(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequiredPasswordSettings>().HasData(
           new RequiredPasswordSettings() { Id = (int)EnumEnvironment.PRD, MinimalOfChars = 10, MustHaveNumbers = true, MustHaveSpecialChars = true, MustHaveUpperCaseLetter = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.PRD },
           new RequiredPasswordSettings() { Id = (int)EnumEnvironment.PRE_PROD, MinimalOfChars = 10, MustHaveNumbers = true, MustHaveSpecialChars = true, MustHaveUpperCaseLetter = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.PRE_PROD },
           new RequiredPasswordSettings() { Id = (int)EnumEnvironment.HML, MinimalOfChars = 10, MustHaveNumbers = true, MustHaveSpecialChars = true, MustHaveUpperCaseLetter = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.HML },
           new RequiredPasswordSettings() { Id = (int)EnumEnvironment.QA, MinimalOfChars = 10, MustHaveNumbers = true, MustHaveSpecialChars = true, MustHaveUpperCaseLetter = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.QA },
           new RequiredPasswordSettings() { Id = (int)EnumEnvironment.DEV, MinimalOfChars = 10, MustHaveNumbers = true, MustHaveSpecialChars = true, MustHaveUpperCaseLetter = true, CreateDate = _currentDate, Status = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.DEV }
        );
    }

    private static void SeedEmailTemplate(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmailTemplate>().HasData(
           new EmailTemplate() { Id = 1, Description = "WebAPI", CreatedAt = _currentDate, IsActive = STATUS_TRUE }
        );
    }

    private static void SeedEmailDisplay(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmailDisplay>().HasData(
           new EmailDisplay() { Id = (int)EnumEmail.Welcome, Subject = "Bem vindo ao sistema {0}", Title = "Email de boas vindas", Body = new EmailWelcomeConfig().GetBodyText(), EmailTemplateId = 1, MessagePriority = MessagePriority.Normal, CreateDate = _currentDate, Status = STATUS_TRUE, HasAttachment = STATUS_FALSE },
           new EmailDisplay() { Id = (int)EnumEmail.ChangePassword, Subject = "{0} - Solicitação de troca de senha", Title = "Email de troca de senha", Body = EmailDisplay.GetBodyTextTradePsw(), EmailTemplateId = 1, MessagePriority = MessagePriority.Normal, CreateDate = _currentDate, Status = STATUS_TRUE, HasAttachment = STATUS_FALSE },
           new EmailDisplay() { Id = (int)EnumEmail.ResetPassword, Subject = "{0} - Esqueci a senha", Title = "Email de reset de senha", Body = EmailDisplay.GetBodyTextForgetPsw(), EmailTemplateId = 1, MessagePriority = MessagePriority.Normal, CreateDate = _currentDate, Status = STATUS_TRUE, HasAttachment = STATUS_FALSE },
           new EmailDisplay() { Id = (int)EnumEmail.ConfirmPassword, Subject = "{0} - Confirmação de senha", Title = "Email de confirmação de senha", Body = EmailDisplay.GetBodyTextConfirmPsw(), EmailTemplateId = 1, MessagePriority = MessagePriority.Normal, CreateDate = _currentDate, Status = STATUS_TRUE, HasAttachment = STATUS_FALSE },
           new EmailDisplay() { Id = (int)EnumEmail.Report, Subject = "{0} - Relatório", Title = "Email de relatório", Body = string.Empty, EmailTemplateId = 1, MessagePriority = MessagePriority.Normal, CreateDate = _currentDate, IsActive = STATUS_TRUE, HasAttachment = STATUS_FALSE }
        );
    }

    private static void SeedLayoutSettings(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LayoutSettings>().HasData(
           new LayoutSettings() { Id = (int)EnumEnvironment.PRD, CreateDate = _currentDate, DocumentFileContentToUpload = ".pdf,.doc,.docx", ImageFileContentToUpload = ".jpg,.jpeg,.png", MaxDocumentFileSize = 20, MaxImageFileSize = 20, IsActive = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.PRD },
           new LayoutSettings() { Id = (int)EnumEnvironment.PRE_PROD, CreateDate = _currentDate, DocumentFileContentToUpload = ".pdf,.doc,.docx", ImageFileContentToUpload = ".jpg,.jpeg,.png", MaxDocumentFileSize = 20, MaxImageFileSize = 20, IsActive = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.PRE_PROD },
           new LayoutSettings() { Id = (int)EnumEnvironment.HML, CreateDate = _currentDate, DocumentFileContentToUpload = ".pdf,.doc,.docx,.txt", ImageFileContentToUpload = ".jpg,.jpeg,.png", MaxDocumentFileSize = 20, MaxImageFileSize = 20, IsActive = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.HML },
           new LayoutSettings() { Id = (int)EnumEnvironment.QA, CreateDate = _currentDate, DocumentFileContentToUpload = ".pdf,.doc,.docx,.txt", ImageFileContentToUpload = ".jpg,.jpeg,.png", MaxDocumentFileSize = 20, MaxImageFileSize = 20, IsActive = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.QA },
           new LayoutSettings() { Id = (int)EnumEnvironment.DEV, CreateDate = _currentDate, DocumentFileContentToUpload = ".pdf,.doc,.docx,.txt", ImageFileContentToUpload = ".jpg,.jpeg,.png", MaxDocumentFileSize = 20, MaxImageFileSize = 20, IsActive = STATUS_TRUE, IdEnvironmentType = (int)EnumEnvironment.DEV }
        );
    }

    #endregion

    #region Control Panel Seeds

    private static void SeedArea(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>().HasData(
           new Area()
           {
               Id = 1,
               Description = "Administrador Dev",
               HierarchyLevel = EnumHierarchyLevel.Development,
               Order = 0,
               CreateDate = _currentDate,
               Status = STATUS_TRUE
           },
           new Area()
           {
               Id = 2,
               Description = "Administrador Sistema",
               HierarchyLevel = EnumHierarchyLevel.Principal,
               Order = 0,
               CreateDate = _currentDate,
               Status = STATUS_TRUE
           },
           new Area()
           {
               Id = 3,
               Description = "Setor Operacional",
               HierarchyLevel = EnumHierarchyLevel.Areas,
               Order = 0,
               CreateDate = _currentDate,
               Status = STATUS_TRUE
           },
           new Area()
           {
               Id = 4,
               Description = "Setor Financeiro",
               HierarchyLevel = EnumHierarchyLevel.Areas,
               Order = 1,
               CreateDate = _currentDate,
               Status = STATUS_TRUE
           },
           new Area()
           {
               Id = 5,
               Description = "Setor Marketing",
               HierarchyLevel = EnumHierarchyLevel.Areas,
               Order = 2,
               CreateDate = _currentDate,
               Status = STATUS_TRUE
           },
           new Area()
           {
               Id = 6,
               Description = "Setor Relações Humanas",
               HierarchyLevel = EnumHierarchyLevel.Areas,
               Order = 3,
               CreateDate = _currentDate,
               Status = STATUS_TRUE
           }
        );
    }

    private static void SeedOperation(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Operation>().HasData(
          new Operation() { Id = 1, Description = "Auditoria", Order = 1, CreateDate = _currentDate, Status = STATUS_TRUE },
          new Operation() { Id = 2, Description = "Logs", Order = 2, CreateDate = _currentDate, Status = STATUS_TRUE },
          new Operation() { Id = 3, Description = "Area", Order = 3, CreateDate = _currentDate, Status = STATUS_TRUE },
          new Operation() { Id = 4, Description = "Operação", Order = 4, CreateDate = _currentDate, Status = STATUS_TRUE },
          new Operation() { Id = 5, Description = "Perfil", Order = 5, CreateDate = _currentDate, Status = STATUS_TRUE },
          new Operation() { Id = 6, Description = "Funcionario", Order = 6, CreateDate = _currentDate, Status = STATUS_TRUE },
          new Operation() { Id = 7, Description = "Usuario", Order = 7, CreateDate = _currentDate, Status = STATUS_TRUE }
        );
    }

    private static void SeedProfile(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>().HasData(
           new Profile()
           {
               Id = 1,
               Description = "Perfil Desenvolvedor",
               CreateDate = _currentDate,
               Status = STATUS_TRUE,
               IdArea = 1
           },
           new Profile()
           {
               Id = 2,
               Description = "Perfil Administrador",
               CreateDate = _currentDate,
               Status = STATUS_TRUE,
               IdArea = 2
           },
           new Profile()
           {
               Id = 3,
               Description = "Perfil Manager Operacional",
               CreateDate = _currentDate,
               Status = STATUS_TRUE,
               IdArea = 3
           },
           new Profile()
           {
               Id = 4,
               Description = "Perfil Manager Financeiro",
               CreateDate = _currentDate,
               Status = STATUS_TRUE,
               IdArea = 4
           }
        );
    }

    private static void SeedProfileOperation(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProfileOperation>().HasData(
           new ProfileOperation() { Id = 1, IdProfile = 1, IdOperation = 1, RoleTag = $"ROLE_{nameof(Audit).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 2, IdProfile = 1, IdOperation = 1, RoleTag = $"ROLE_{nameof(Audit).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 3, IdProfile = 1, IdOperation = 1, RoleTag = $"ROLE_{nameof(Audit).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 4, IdProfile = 1, IdOperation = 1, RoleTag = $"ROLE_{nameof(Audit).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 5, IdProfile = 1, IdOperation = 2, RoleTag = $"ROLE_{nameof(Log).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 6, IdProfile = 1, IdOperation = 2, RoleTag = $"ROLE_{nameof(Log).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 7, IdProfile = 1, IdOperation = 2, RoleTag = $"ROLE_{nameof(Log).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 8, IdProfile = 1, IdOperation = 2, RoleTag = $"ROLE_{nameof(Log).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 9, IdProfile = 1, IdOperation = 3, RoleTag = $"ROLE_{nameof(Area).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 10, IdProfile = 1, IdOperation = 3, RoleTag = $"ROLE_{nameof(Area).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 11, IdProfile = 1, IdOperation = 3, RoleTag = $"ROLE_{nameof(Area).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 12, IdProfile = 1, IdOperation = 3, RoleTag = $"ROLE_{nameof(Area).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 13, IdProfile = 1, IdOperation = 4, RoleTag = $"ROLE_{nameof(Operation).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 14, IdProfile = 1, IdOperation = 4, RoleTag = $"ROLE_{nameof(Operation).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 15, IdProfile = 1, IdOperation = 4, RoleTag = $"ROLE_{nameof(Operation).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 16, IdProfile = 1, IdOperation = 4, RoleTag = $"ROLE_{nameof(Operation).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 17, IdProfile = 1, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 18, IdProfile = 1, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 19, IdProfile = 1, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 20, IdProfile = 1, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 21, IdProfile = 1, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 22, IdProfile = 1, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 23, IdProfile = 1, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 24, IdProfile = 1, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 25, IdProfile = 1, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 26, IdProfile = 1, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 27, IdProfile = 1, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 28, IdProfile = 1, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 29, IdProfile = 2, IdOperation = 2, RoleTag = $"ROLE_{nameof(Log).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 30, IdProfile = 2, IdOperation = 2, RoleTag = $"ROLE_{nameof(Log).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 31, IdProfile = 2, IdOperation = 2, RoleTag = $"ROLE_{nameof(Log).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 32, IdProfile = 2, IdOperation = 2, RoleTag = $"ROLE_{nameof(Log).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 33, IdProfile = 2, IdOperation = 3, RoleTag = $"ROLE_{nameof(Area).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 34, IdProfile = 2, IdOperation = 3, RoleTag = $"ROLE_{nameof(Area).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 35, IdProfile = 2, IdOperation = 3, RoleTag = $"ROLE_{nameof(Area).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 36, IdProfile = 2, IdOperation = 3, RoleTag = $"ROLE_{nameof(Area).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 37, IdProfile = 2, IdOperation = 4, RoleTag = $"ROLE_{nameof(Operation).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 38, IdProfile = 2, IdOperation = 4, RoleTag = $"ROLE_{nameof(Operation).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 39, IdProfile = 2, IdOperation = 4, RoleTag = $"ROLE_{nameof(Operation).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 40, IdProfile = 2, IdOperation = 4, RoleTag = $"ROLE_{nameof(Operation).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 41, IdProfile = 2, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 42, IdProfile = 2, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 43, IdProfile = 2, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 44, IdProfile = 2, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper().ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 45, IdProfile = 2, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 46, IdProfile = 2, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 47, IdProfile = 2, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 48, IdProfile = 2, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 49, IdProfile = 2, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 50, IdProfile = 2, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 51, IdProfile = 2, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 52, IdProfile = 2, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 53, IdProfile = 3, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 54, IdProfile = 3, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 55, IdProfile = 3, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 56, IdProfile = 3, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 57, IdProfile = 3, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 58, IdProfile = 3, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 59, IdProfile = 3, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 60, IdProfile = 3, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 61, IdProfile = 3, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 62, IdProfile = 3, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 63, IdProfile = 3, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 64, IdProfile = 3, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 65, IdProfile = 4, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 66, IdProfile = 4, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 67, IdProfile = 4, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 68, IdProfile = 4, IdOperation = 5, RoleTag = $"ROLE_{nameof(Profile).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 69, IdProfile = 4, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 70, IdProfile = 4, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 71, IdProfile = 4, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 72, IdProfile = 4, IdOperation = 6, RoleTag = $"ROLE_{nameof(Employee).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 73, IdProfile = 4, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_NEW", Order = 0, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 74, IdProfile = 4, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_EDIT", Order = 1, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 75, IdProfile = 4, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_DELETE", Order = 2, IsEnable = STATUS_TRUE },
           new ProfileOperation() { Id = 76, IdProfile = 4, IdOperation = 7, RoleTag = $"ROLE_{nameof(User).ToUpper()}_VIEW", Order = 3, IsEnable = STATUS_TRUE }
        );
    }

    private static void SeedUser(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User()
        {
            Id = 1,
            Login = "admin@DefaultAPI.com.br",
            CreateDate = _currentDate,
            Status = STATUS_TRUE,
            IsAuthenticated = STATUS_TRUE,
            Password = HashingManager.GetLoadHashingManager().HashToString("123mudar"),
            LastPassword = StringExtensionMethod.GetEmptyString(),
            HasTwoFactoryValidation = STATUS_FALSE,
        });
    }

    private static void SeedEmployee(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
        new Employee()
        {
            Id = 1,
            Name = "Administrador Desenvolvedor",
            Email = "xpto@gmail.com",
            TelPhone = "1233336789",
            CelPhone = "12999991234",
            IdProfile = 1,
            IdUser = 1,
            CreateDate = _currentDate,
            Status = STATUS_TRUE
        }
        );
    }

    #endregion

    public static void ExecuteSeedControlPanel(this ModelBuilder modelBuilder)
    {
        _currentDate = DateOnlyExtension.GetDateTimeNowFromBrazil();
        SeedArea(modelBuilder);
        SeedOperation(modelBuilder);
        SeedProfile(modelBuilder);
        SeedProfileOperation(modelBuilder);
        SeedUser(modelBuilder);
        SeedEmployee(modelBuilder);
    }

    public static void ExecuteSeedConfiguration(this ModelBuilder modelBuilder)
    {
        _currentDate = DateOnlyExtension.GetDateTimeNowFromBrazil();
        SeedEnvironmentType(modelBuilder);
        SeedEmailSettings(modelBuilder);
        SeedEmailTemplate(modelBuilder);
        SeedEmailDisplay(modelBuilder);
        SeedAuthenticationSettings(modelBuilder);
        SeedExpirationPasswordSettings(modelBuilder);
        SeedLogSettings(modelBuilder);
        SeedRequiredPasswordSettings(modelBuilder);
        SeedLayoutSettings(modelBuilder);
    }

    public static void ReseedTables(this WebAPIContext context)
    {
        if (context.User.Where(x => x.Id > 1).Count() > 0)
        {
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Users', RESEED, 2)");
            context.SaveChanges();
        }

        if (context.Profile.Where(x => x.Id > 3).Count() > 0)
        {
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Profiles', RESEED, 4)");
            context.SaveChanges();
        }
    }
}