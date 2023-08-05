using Okusana.Entities.Base;


namespace Okusana.Entities.Concrete
{
    public class Comment : Entity
    {
        public Guid BlogId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = null!;
        public int Rate { get; set; }
        public virtual Blog Blog { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
