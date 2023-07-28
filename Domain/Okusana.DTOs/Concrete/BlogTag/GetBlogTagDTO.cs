using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.BlogTag
{
    public sealed record GetBlogTagDTO : GetDTO
    {
        public Guid BlogId { get; init; }
        public Guid TagId { get; init; }
    }
}
