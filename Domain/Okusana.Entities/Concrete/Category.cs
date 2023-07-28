using Okusana.Entities.Base;

namespace Okusana.Entities.Concrete
{
    public class Category : Entity//ek tablo sub için tablo tap
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        virtual public ICollection<SubCategory>? SubCategories { get; set; }
    }
}
