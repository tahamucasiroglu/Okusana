using Okusana.DTOs.Base;


namespace Okusana.DTOs.Concrete.Blog
{
    public sealed record GetBlogDTO : GetDTO
    {
        public Guid UserId { get; init; }
        public Guid SubCategoryId { get; init; }
        public string Title { get; init; } = null!;
        public string Content { get; init; } = null!;
        public DateTime? PublicationDate { get; init; }
        public bool IsPublished { get; init; }
    }
}
