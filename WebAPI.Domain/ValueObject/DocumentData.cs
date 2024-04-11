namespace WebAPI.Domain.ValueObject;

public sealed record DocumentData
{
    public int CPF { get; set; }
    public int RG { get; set; }
}
