using Okusana.Entities.Base;

namespace Okusana.Entities.Concrete
{
    public class Category : Entity//ek tablo sub için tablo tap
    {
        public Guid? ParentId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        virtual public Category? ParentCategory { get; set; }
        virtual public ICollection<Category>? SubCategories { get; set; }
        virtual public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
