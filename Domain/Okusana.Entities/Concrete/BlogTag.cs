using Okusana.Entities.Abstract;

namespace Okusana.Entities.Concrete
{
    public class BlogTag : IEntityCore // hareket tablosu
    {
        public Guid BlogId { get; set; }
        public Guid TagId { get; set; }
        public Blog Blog { get; set; } = null!;
        public HashTag HashTag { get; set; } = null!;
    }
}
