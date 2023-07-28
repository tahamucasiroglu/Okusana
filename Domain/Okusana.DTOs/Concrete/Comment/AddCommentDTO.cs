using Okusana.DTOs.Base;


namespace Okusana.DTOs.Concrete.Comment
{
    public sealed record AddCommentDTO : AddDTO
    {
        public Guid BlogId { get; init; }
        public Guid UserId { get; init; }
        public string Content { get; init; } = null!;
        public int? Rate { get; init; }
        public bool IsLike { get; init; }
    }
}
