using Okusana.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Entities.Concrete
{
    public class Category : Entity
    {
        public Guid? ParentId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        virtual public Category? ParentCategory { get; set; }
        virtual public ICollection<Category>? SubCategories { get; set; }
        virtual public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
