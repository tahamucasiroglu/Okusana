using Okusana.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Concrete.HashTag
{
    public class AddHashTagDTO : AddDTO
    {
        public string Name { get; set; } = null!;
    }
}
