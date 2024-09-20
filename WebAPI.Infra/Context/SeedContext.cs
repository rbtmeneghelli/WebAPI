using WebAPI.Domain;
using WebAPI.Domain.Cryptography;
using WebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Infra.Data
{
    public static class SeedContext
    {
        private const bool STATUS_TRUE = true;
        private const bool STATUS_FALSE = false;
        private static DateTime _currentDate;

        #region Control Seeds

        private static void SeedArea(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().HasData(
               new Area()
               {
                   Id = 1,
                   Description = "Administrador Dev",
                   HierarchyLevel = EnumHierarchyLevel.Development,
                   Order = 0,
                   CreatedTime = _currentDate,
                   IsActive = STATUS_TRUE
               },
               new Area()
               {
                   Id = 2,
                   Description = "Administrador Sistema",
                   HierarchyLevel = EnumHierarchyLevel.Principal,
                   Order = 0,
                   CreatedTime = _currentDate,
                   IsActive = STATUS_TRUE
               },
               new Area()
               {
                   Id = 3,
                   Description = "Setor Operacional",
                   HierarchyLevel = EnumHierarchyLevel.Areas,
                   Order = 0,
                   CreatedTime = _currentDate,
                   IsActive = STATUS_TRUE
               },
               new Area()
               {
                   Id = 4,
                   Description = "Setor Financeiro",
                   HierarchyLevel = EnumHierarchyLevel.Areas,
                   Order = 1,
                   CreatedTime = _currentDate,
                   IsActive = STATUS_TRUE
               },
               new Area()
               {
                   Id = 5,
                   Description = "Setor Marketing",
                   HierarchyLevel = EnumHierarchyLevel.Areas,
                   Order = 2,
                   CreatedTime = _currentDate,
                   IsActive = STATUS_TRUE
               },
               new Area()
               {
                   Id = 6,
                   Description = "Setor Relações Humanas",
                   HierarchyLevel = EnumHierarchyLevel.Areas,
                   Order = 3,
                   CreatedTime = _currentDate,
                   IsActive = STATUS_TRUE
               }
            );
        }

        private static void SeedOperation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>().HasData(
              new Operation() { Id = 1, Description = "Auditoria", Order = 1, CreatedTime = _currentDate, IsActive = STATUS_TRUE },
              new Operation() { Id = 2, Description = "Logs", Order = 2, CreatedTime = _currentDate, IsActive = STATUS_TRUE },
              new Operation() { Id = 3, Description = "Area", Order = 3, CreatedTime = _currentDate, IsActive = STATUS_TRUE },
              new Operation() { Id = 4, Description = "Operação", Order = 4, CreatedTime = _currentDate, IsActive = STATUS_TRUE },
              new Operation() { Id = 5, Description = "Perfil", Order = 5, CreatedTime = _currentDate, IsActive = STATUS_TRUE },
              new Operation() { Id = 6, Description = "Funcionario", Order = 6, CreatedTime = _currentDate, IsActive = STATUS_TRUE },
              new Operation() { Id = 7, Description = "Usuario", Order = 7, CreatedTime = _currentDate, IsActive = STATUS_TRUE }
            );
        }

        private static void SeedProfile(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(
               new Profile()
               {
                   Id = 1,
                   Description = "Perfil Desenvolvedor",
                   CreatedTime = _currentDate,
                   IsActive = STATUS_TRUE,
                   IdArea = 1
               },
               new Profile()
               {
                   Id = 2,
                   Description = "Perfil Administrador",
                   CreatedTime = _currentDate,
                   IsActive = STATUS_TRUE,
                   IdArea = 2
               },
               new Profile()
               {
                   Id = 3,
                   Description = "Perfil Manager Operacional",
                   CreatedTime = _currentDate,
                   IsActive = STATUS_TRUE,
                   IdArea = 3
               },
               new Profile()
               {
                   Id = 4,
                   Description = "Perfil Manager Financeiro",
                   CreatedTime = _currentDate,
                   IsActive = STATUS_TRUE,
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
                CreatedTime = _currentDate,
                IsActive = STATUS_TRUE,
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
                CreatedTime = _currentDate,
                IsActive = STATUS_TRUE
            }
            );
        }

        #endregion

        #region Operational Seeds
        private static void SeedArchiveType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArchiveType>().HasData(
               new ArchiveType() { Id = 1, Description = "Word", CreatedTime = _currentDate, IsActive = STATUS_TRUE },
               new ArchiveType() { Id = 2, Description = "Excel", CreatedTime = _currentDate, IsActive = STATUS_TRUE },
               new ArchiveType() { Id = 3, Description = "Pdf", CreatedTime = _currentDate, IsActive = STATUS_TRUE },
               new ArchiveType() { Id = 4, Description = "Txt", CreatedTime = _currentDate, IsActive = STATUS_TRUE },
               new ArchiveType() { Id = 5, Description = "Jpg", CreatedTime = _currentDate, IsActive = STATUS_TRUE },
               new ArchiveType() { Id = 6, Description = "Word", CreatedTime = _currentDate, IsActive = STATUS_TRUE },
               new ArchiveType() { Id = 7, Description = "Png", CreatedTime = _currentDate, IsActive = STATUS_TRUE }
            );
        }

        private static void SeedEmailTemplate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailTemplate>().HasData(
               new EmailTemplate() { Id = 1, Description = "WebAPI", CreatedTime = _currentDate, IsActive = STATUS_TRUE }
            );
        }

        private static void SeedEmailType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailSettings>().HasData(
               new EmailSettings() { Id = 1, Host = "Gmail", SmtpConfig = "smtp.gmail.com", CreatedTime = _currentDate, IsActive = STATUS_TRUE },
               new EmailSettings() { Id = 2, Host = "Outlook", SmtpConfig = "smtp.office365.com", CreatedTime = _currentDate, IsActive = STATUS_TRUE },
               new EmailSettings() { Id = 3, Host = "Hotmail", SmtpConfig = "smtp.live.com", CreatedTime = _currentDate, IsActive = STATUS_TRUE }
            );
        }

        private static void SeedEmailDisplay(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailDisplay>().HasData(
               new EmailDisplay() { Id = (int)EnumEmail.Welcome, Subject = EmailDisplay.GetSubjectWelcome(), Title = EnumEmail.Welcome.GetDisplayName(), Body = EmailDisplay.GetBodyTextWelcome(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = _currentDate, IsActive = STATUS_TRUE, HasAttachment = STATUS_FALSE },
               new EmailDisplay() { Id = (int)EnumEmail.ResetPassword, Subject = EmailDisplay.GetSubjectForgetPsw(), Title = EnumEmail.ResetPassword.GetDisplayName(), Body = EmailDisplay.GetBodyTextForgetPsw(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = _currentDate, IsActive = STATUS_TRUE, HasAttachment = STATUS_FALSE },
               new EmailDisplay() { Id = (int)EnumEmail.ChangePassword, Subject = EmailDisplay.GetSubjectTradePsw(), Title = EnumEmail.ChangePassword.GetDisplayName(), Body = EmailDisplay.GetBodyTextTradePsw(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = _currentDate, IsActive = STATUS_TRUE, HasAttachment = STATUS_FALSE },
               new EmailDisplay() { Id = 4, Subject = EmailDisplay.GetSubjectConfirmPsw(), Title = EmailDisplay.GetTitleConfirmPsw(), Body = EmailDisplay.GetBodyTextConfirmPsw(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = _currentDate, IsActive = STATUS_TRUE, HasAttachment = STATUS_FALSE },
               new EmailDisplay() { Id = 5, Subject = EmailDisplay.GetSubjectReport(), Title = EmailDisplay.GetTitleReport(), Body = StringExtensionMethod.GetEmptyString(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = _currentDate, IsActive = STATUS_TRUE, HasAttachment = STATUS_FALSE }
            );
        }

        #endregion

        public static void ExecuteSeedControl(this ModelBuilder modelBuilder)
        {
            _currentDate = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
            SeedArea(modelBuilder);
            SeedOperation(modelBuilder);
            SeedProfile(modelBuilder);
            SeedProfileOperation(modelBuilder);
            SeedUser(modelBuilder);
            SeedEmployee(modelBuilder);
        }

        public static void ExecuteSeedOperation(this ModelBuilder modelBuilder)
        {
            _currentDate = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
            SeedArchiveType(modelBuilder);
            SeedEmailTemplate(modelBuilder);
            SeedEmailType(modelBuilder);
            SeedEmailDisplay(modelBuilder);
        }
    }
}