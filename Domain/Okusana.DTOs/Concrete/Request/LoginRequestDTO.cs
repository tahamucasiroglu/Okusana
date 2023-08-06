using Okusana.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Concrete.Request
{
    public sealed record LoginRequestDTO : AbstractRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
