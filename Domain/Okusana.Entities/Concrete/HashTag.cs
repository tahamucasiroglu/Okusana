using Okusana.Entities.Base;

namespace Okusana.Entities.Concrete
{
    public class HashTag : Entity
    {
        public string Name { get; set; } = null!;
        virtual public ICollection<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
    }
}
