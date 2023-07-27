using Okusana.Entities.Base;

namespace Okusana.Entities.Concrete
{
    public class Blog : Entity
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? PublicationDate { get; set; }
        public bool IsPublished { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
        virtual public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        virtual public ICollection<HashTag> HashTags { get; set; } = new List<HashTag>();

    }
}
