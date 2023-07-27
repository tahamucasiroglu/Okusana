using Okusana.Entities.Base;

namespace Okusana.Entities.Concrete
{
    public class HashTag : Entity
    {
        public string Name { get; set; } = null!;
        virtual public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
