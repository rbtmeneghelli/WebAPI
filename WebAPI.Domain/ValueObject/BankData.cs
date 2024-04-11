namespace WebAPI.Domain.ValueObject;

public sealed record BankData
{
    public string Agency { get; set; }
    public string Account { get; set; }
    public string Digit { get; set; }
    public string Name { get; set; }
}
