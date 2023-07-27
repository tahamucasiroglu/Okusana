using Okusana.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Entities.Concrete
{
    public class HashTag : Entity
    {
        public Guid BlogId { get; set; }
        public string Name { get; set; } = null!;
        virtual public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
