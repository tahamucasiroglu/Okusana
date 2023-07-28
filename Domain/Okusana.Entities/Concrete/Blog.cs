using Okusana.Entities.Base;

namespace Okusana.Entities.Concrete
{
    public class Blog : Entity
    {
        public Guid UserId { get; set; }
        public Guid SubCategoryId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? PublicationDate { get; set; }
        public bool IsPublished { get; set; }
        virtual public User User { get; set; } = null!;
        virtual public SubCategory SubCategory { get; set; } = null!;
        virtual public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        virtual public ICollection<BlogTag> BlogTags { get; set; } = new List<BlogTag>();

    }
}
