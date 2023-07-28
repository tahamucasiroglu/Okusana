using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.BlogTag
{
    public sealed record UpdateBlogTagDTO : UpdateDTO
    {
        public Guid BlogId { get; init; }
        public Guid TagId { get; init; }
    }
}
