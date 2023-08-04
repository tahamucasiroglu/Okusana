using Okusana.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Concrete.Request
{
    public sealed record PageRequestDTO : AbstractRequest
    {
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}
