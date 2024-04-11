﻿namespace WebAPI.Domain.Models
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }

        public string Issuer { get; set; }

        public double Seconds { get; set; }

        public string Key { get; set; }
    }
}
