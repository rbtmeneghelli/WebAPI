using WebAPI.Domain;
using WebAPI.Domain.Cryptography;
using WebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Infra.Data
{
    public static class SeedContext
    {
        public static void ExecuteSeed(this ModelBuilder modelBuilder)
        {
            SeedProfile(modelBuilder);
            SeedOperation(modelBuilder);
            SeedRole(modelBuilder);
            SeedProfileOperation(modelBuilder);
            SeedUser(modelBuilder);
            SeedArchiveType(modelBuilder);
            SeedEmailTemplate(modelBuilder);
            SeedEmailType(modelBuilder);
            SeedEmailDisplay(modelBuilder);
        }

        private static void SeedUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Login = "admin@DefaultAPI.com.br",
                CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(),
                IsActive = true,
                IsAuthenticated = true,
                Password = HashingManager.GetLoadHashingManager().HashToString("123mudar"),
                LastPassword = string.Empty,
                IdProfile = 1
            });
        }

        private static void SeedProfile(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(
               new Profile() { Id = 1, Description = "Perfil Usuário", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true },
               new Profile() { Id = 2, Description = "Perfil Administrador", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true },
               new Profile() { Id = 3, Description = "Perfil Manager", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true }
            );
        }

        private static void SeedOperation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>().HasData(
              new Operation() { Id = 1, Description = "Auditoria", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true }
            );
        }

        private static void SeedRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
               new Role() { Id = 1, Description = "Regra de acesso a tela de Auditoria", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), RoleTag = "ROLE_AUDIT" }
            );
        }

        private static void SeedProfileOperation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfileOperation>().HasData(
               new ProfileOperation() { IdProfile = 1, IdOperation = 1 }
            );
        }

        private static void SeedArchiveType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArchiveType>().HasData(
               new ArchiveType() { Id = 1, Description = "Word", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true },
               new ArchiveType() { Id = 2, Description = "Excel", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true },
               new ArchiveType() { Id = 3, Description = "Pdf", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true },
               new ArchiveType() { Id = 4, Description = "Txt", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true },
               new ArchiveType() { Id = 5, Description = "Jpg", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true },
               new ArchiveType() { Id = 6, Description = "Word", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true },
               new ArchiveType() { Id = 7, Description = "Png", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true }
            );
        }

        private static void SeedEmailTemplate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailTemplate>().HasData(
               new EmailTemplate() { Id = 1, Description = "WebAPI", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true }
            );
        }

        private static void SeedEmailType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailType>().HasData(
               new EmailType() { Id = 1, Description = "Gmail", SmtpConfig = "smtp.gmail.com", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true },
               new EmailType() { Id = 2, Description = "Outlook", SmtpConfig = "smtp.office365.com", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true },
               new EmailType() { Id = 3, Description = "Hotmail", SmtpConfig = "smtp.live.com", CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true }
            );
        }

        private static void SeedEmailDisplay(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailDisplay>().HasData(
               new EmailDisplay() { Id = 1, Subject = EmailDisplay.GetSubjectWelcome(), Title = EmailDisplay.GetTitleWelcome(), Body = EmailDisplay.GetBodyTextWelcome(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true, HasAttachment = false },
               new EmailDisplay() { Id = 2, Subject = EmailDisplay.GetSubjectForgetPsw(), Title = EmailDisplay.GetTitleForgetPsw(), Body = EmailDisplay.GetBodyTextForgetPsw(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true, HasAttachment = false },
               new EmailDisplay() { Id = 3, Subject = EmailDisplay.GetSubjectTradePsw(), Title = EmailDisplay.GetTitleTradePsw(), Body = EmailDisplay.GetBodyTextTradePsw(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true, HasAttachment = false },
               new EmailDisplay() { Id = 4, Subject = EmailDisplay.GetSubjectConfirmPsw(), Title = EmailDisplay.GetTitleConfirmPsw(), Body = EmailDisplay.GetBodyTextConfirmPsw(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true, HasAttachment = false },
               new EmailDisplay() { Id = 5, Subject = EmailDisplay.GetSubjectReport(), Title = EmailDisplay.GetTitleReport(), Body = StringExtensionMethod.GetEmptyString(), EmailTemplateId = 1, Priority = MessagePriority.Normal, CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil(), IsActive = true, HasAttachment = true }
            );
        }
    }
}