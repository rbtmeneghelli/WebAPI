namespace WebAPI.Domain.Models
{
    public sealed record TokenSettings
    {
        public string Audience { get; init; }

        public string Issuer { get; init; }

        public double Seconds { get; init; }

        public string Key { get; init; }
    }
}
