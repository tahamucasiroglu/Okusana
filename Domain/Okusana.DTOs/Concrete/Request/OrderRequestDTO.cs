using Okusana.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Concrete.Request
{
    public sealed record OrderRequestDTO : AbstractRequest
    {
        public string Order { get; set; } = string.Empty;
    }
}
