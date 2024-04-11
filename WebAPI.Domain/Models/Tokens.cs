using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Domain.Models
{
    public sealed class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
