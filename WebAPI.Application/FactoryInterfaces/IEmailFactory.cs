namespace WebAPI.Application.FactoryInterfaces;

public interface IEmailFactory
{
    IEmailConfigFactory SendEmailByEnumEmail(EnumEmail enumEmail);
}
