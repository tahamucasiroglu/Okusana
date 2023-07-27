using Okusana.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Entities.Concrete
{
    public class Comment : Entity
    {
        public Guid BlogId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = null!;
        public int? Rate { get; set; }
        public bool IsLike { get; set; }
        public virtual Blog Blog { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
