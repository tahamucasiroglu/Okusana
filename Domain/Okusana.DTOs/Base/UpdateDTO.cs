using Okusana.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Base
{
    abstract public record UpdateDTO : DTO, IUpdateDTO
    {
        public Guid Id { get; init; }
    }
}
