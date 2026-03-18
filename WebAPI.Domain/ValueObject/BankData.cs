using FastPackForShare.Extensions;
using System.Text.RegularExpressions;

namespace WebAPI.Domain.ValueObject;

public sealed class BankData
{
    public string Agency { get; set; }
    public string Account { get; set; }
    public string Digit { get; set; }
    public EnumBank Bank { get; set; }

    private BankData(string agency, string account, string digit, EnumBank bank)
    {
        Agency = agency;
        Account = account;
        Digit = digit;
        Bank = bank;
    }

    public static BankData Create(string agency, string account, string digit, EnumBank bank)
    {
        if (string.IsNullOrWhiteSpace(agency))
            throw new ArgumentException("Código da agência é obrigatório.");

        if (!Regex.IsMatch(agency, @"^\d{1,5}$"))
            throw new ArgumentException("Código da agência deve conter de 1 a 5 dígitos.");

        if (string.IsNullOrWhiteSpace(account))
            throw new ArgumentException("Código da conta é obrigatório.");

        if (!Regex.IsMatch(account, @"^\d{1,10}$"))
            throw new ArgumentException("Código da conta deve conter de 1 a 5 dígitos.");

        if (string.IsNullOrWhiteSpace(digit))
            throw new ArgumentException("Dígito da conta é obrigatório.");

        if (!Regex.IsMatch(digit, @"^[0-9Xx]$"))
            throw new ArgumentException("Dígito deve ser numérico ou 'X'.");

        return new BankData(agency, account, digit.ToUpper(), bank);
    }

    public override string ToString() => $"{Bank.GetEnumDescription()}: {Agency}-{Account}-{Digit}";
}