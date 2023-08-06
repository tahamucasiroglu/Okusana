using Okusana.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Concrete.Response
{
    public sealed record GetTokenResponseDTO : AbstractResponse
    {
        public string Token { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Status { get; init; } = string.Empty;
        public DateTime TokenCreateTime { get; init; }
        public DateTime TokenDeleteTime { get; init; }
    }
}
