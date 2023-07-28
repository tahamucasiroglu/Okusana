using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Entities.Concrete
{
    public class BlogTag
    {
        public Guid BlogId { get; set; }
        public Guid TagId { get; set; }
        public Blog Blog { get; set; } = null!;
        public HashTag HashTag { get; set; } = null!;
    }
}
