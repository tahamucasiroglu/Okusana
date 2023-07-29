using Okusana.DTOs.Base;


namespace Okusana.DTOs.Concrete.Comment
{
    public sealed record UpdateCommentDTO : UpdateDTO
    {
        public string Content { get; init; } = null!;
        public int? Rate { get; init; }
        public bool IsLike { get; init; }
    }
}
