using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Base
{
    abstract public record GetDTO
    {
        public Guid Id { get; init; }
        public DateTime CreateDate { get; init; }
        public DateTime? UpdateDate { get; init; }
        public DateTime? DeleteDate { get; init; }
        public bool IsDeleted { get; init; }
    }
}
