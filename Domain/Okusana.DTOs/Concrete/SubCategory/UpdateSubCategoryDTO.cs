using Okusana.DTOs.Base;


namespace Okusana.DTOs.Concrete.SubCategory
{
    public sealed record UpdateSubCategoryDTO : UpdateDTO
    {
        public Guid CategoryId { get; init; }
        public string Name { get; init; } = null!;
        public string? Description { get; init; }
    }
}
