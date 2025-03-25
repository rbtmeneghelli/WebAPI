namespace WebAPI.Application.Interfaces.Shared;

public interface IDataProtectionService
{
    string ApplyProtect(string input);
    string RemoveProtect(string input);
}
