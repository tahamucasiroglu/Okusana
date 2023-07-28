using Okusana.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Entities.Concrete
{
    public class SubCategory : Entity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        virtual public Category Category { get; set; } = null!;
        virtual public ICollection<Blog> Blogs { get; set; } = null!;
    }
}
