using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Interfaces.Factory;

public interface IEmailFactory
{
    IEmailConfigFactory SendEmailByEnumEmail(EnumEmail enumEmail);
}
