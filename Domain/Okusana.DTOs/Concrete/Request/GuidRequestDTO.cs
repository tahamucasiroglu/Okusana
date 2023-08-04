using Okusana.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Concrete.Request
{
    public sealed record GuidRequestDTO : AbstractRequest
    {
        public Guid Value { get; set; }
    }
}
