using Okusana.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Concrete.Category
{
    public class AddCategoryDTO : AddDTO
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
