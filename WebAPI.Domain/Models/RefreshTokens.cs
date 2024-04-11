using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Domain.Models
{
    public sealed class RefreshTokens
    {
        public string Username { get; set; }
        public string RefreshToken { get; set; }

        public RefreshTokens(string userName, string refreshToken)
        {
            Username = userName;
            RefreshToken = refreshToken;
        }
    }
}
