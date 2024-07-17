using WebAPI.Domain;
using WebAPI.Domain.Cryptography;
using WebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Enums;

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
               new ProfileOperation() { IdProfile = 1, IdOperation = 1, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 1, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 1, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 1, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 2, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 2, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 2, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 2, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 3, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 3, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 3, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 3, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 4, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 4, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 4, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 4, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 5, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 5, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 5, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 5, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 6, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 6, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 6, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 6, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 7, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 7, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 7, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 1, IdOperation = 7, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 2, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 2, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 2, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 2, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 3, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 3, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 3, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 3, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 4, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 4, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 4, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 4, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 5, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 5, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 5, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 5, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 6, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 6, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 6, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 6, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 7, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 7, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 7, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 2, IdOperation = 7, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 3, IdOperation = 5, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 3, IdOperation = 5, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 3, IdOperation = 5, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 3, IdOperation = 5, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 3, IdOperation = 6, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 3, IdOperation = 6, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 3, IdOperation = 6, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 3, IdOperation = 6, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 3, IdOperation = 7, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 3, IdOperation = 7, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 3, IdOperation = 7, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 3, IdOperation = 7, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 4, IdOperation = 5, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 4, IdOperation = 5, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 4, IdOperation = 5, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 4, IdOperation = 5, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 4, IdOperation = 6, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 4, IdOperation = 6, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 4, IdOperation = 6, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 4, IdOperation = 6, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 4, IdOperation = 7, RoleTag = "ROLE_NEW", Order = 0, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 4, IdOperation = 7, RoleTag = "ROLE_EDIT", Order = 1, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 4, IdOperation = 7, RoleTag = "ROLE_DELETE", Order = 2, IsEnable = STATUS_TRUE },
               new ProfileOperation() { IdProfile = 4, IdOperation = 7, RoleTag = "ROLE_VIEW", Order = 3, IsEnable = STATUS_TRUE }
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
            modelBuilder.Entity<EmailType>().HasData(
               new EmailType() { Id = 1, Description = "Gmail", SmtpConfig = "smtp.gmail.com", CreatedTime = _currentDate, IsActive = STATUS_TRUE },
               new EmailType() { Id = 2, Description = "Outlook", SmtpConfig = "smtp.office365.com", CreatedTime = _currentDate, IsActive = STATUS_TRUE },
               new EmailType() { Id = 3, Description = "Hotmail", SmtpConfig = "smtp.live.com", CreatedTime = _currentDate, IsActive = STATUS_TRUE }
            );
        }

        private static void SeedEmailDisplay(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailDisplay>().HasData(
               new EmailDisplay() { Id = 1, Subject = EmailDisplay.GetSubjectWelcome(), Title = EmailDisplay.GetTitleWelcome(), Body = EmailDisplay.GetBodyTextWelcome(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = _currentDate, IsActive = STATUS_TRUE, HasAttachment = STATUS_FALSE },
               new EmailDisplay() { Id = 2, Subject = EmailDisplay.GetSubjectForgetPsw(), Title = EmailDisplay.GetTitleForgetPsw(), Body = EmailDisplay.GetBodyTextForgetPsw(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = _currentDate, IsActive = STATUS_TRUE, HasAttachment = STATUS_FALSE },
               new EmailDisplay() { Id = 3, Subject = EmailDisplay.GetSubjectTradePsw(), Title = EmailDisplay.GetTitleTradePsw(), Body = EmailDisplay.GetBodyTextTradePsw(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = _currentDate, IsActive = STATUS_TRUE, HasAttachment = STATUS_FALSE },
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