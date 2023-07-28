
using Okusana.Entities.Base;

namespace Okusana.Entities.Concrete
{
    public class BlogTag : Entity // hareket tablosu
    {
        public Guid BlogId { get; set; }
        public Guid TagId { get; set; }
        public Blog Blog { get; set; } = null!;
        public HashTag HashTag { get; set; } = null!;
    }
}
