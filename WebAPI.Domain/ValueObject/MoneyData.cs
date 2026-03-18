using System.Collections.Frozen;
using System.Globalization;

namespace WebAPI.Domain.ValueObject;

/// <summary>
/// Link de referência: https://blog.balta.io/lidando-com-dinheiro-em-aplicacoes-globalizadas/
/// </summary>
public sealed record MoneyData
{
    public decimal Amount { get; set; }
    public EnumCurrencyCode Currency { get; set; }

    private MoneyData(decimal amount, EnumCurrencyCode currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static MoneyData Create(decimal amount, EnumCurrencyCode currency) => new(amount, currency);
    public static MoneyData Zero(decimal amount, EnumCurrencyCode currency) => new(0, currency);

    public MoneyData Sum(MoneyData moneyData)
    {
        EnsureSameCurrency(moneyData);
        return new MoneyData(Amount + moneyData.Amount, Currency);
    }

    public MoneyData Subtract(MoneyData moneyData)
    {
        EnsureSameCurrency(moneyData);
        return new MoneyData(Amount - moneyData.Amount, Currency);
    }

    public MoneyData Multiply(MoneyData moneyData)
    {
        EnsureSameCurrency(moneyData);
        return new MoneyData(Amount - moneyData.Amount, Currency);
    }

    private void EnsureSameCurrency(MoneyData moneyData)
    {
        if (Currency != moneyData.Currency)
            throw new InvalidOperationException();
    }

    public string Format(CultureInfo cultureInfo)
    {
        var format = (NumberFormatInfo)cultureInfo.NumberFormat.Clone();
        format.CurrencySymbol = GetCurrencySymbol(Currency);
        return Amount.ToString("C", format);
    }

    private static string GetCurrencySymbol(EnumCurrencyCode currency)
    {
        Dictionary<EnumCurrencyCode, string> dictionary = new()
        {
            { EnumCurrencyCode.Brl, "R$" },
            { EnumCurrencyCode.Usd, "$" },
            { EnumCurrencyCode.Eur, "€" },
            { EnumCurrencyCode.Gbp, "£" },
            { EnumCurrencyCode.Jpy, "¥" },
        };

        dictionary.ToFrozenDictionary();
        dictionary.TryGetValue(currency, out var result);

        return result ?? currency.ToString().ToUpperInvariant();
    }

    public override string ToString() => $"{Amount:F2} {Currency.ToString().ToUpperInvariant()}";
}
