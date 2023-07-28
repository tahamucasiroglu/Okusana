using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.HashTag
{
    public sealed record GetHashTagDTO : GetDTO
    {
        public string Name { get; init; } = null!;
    }
}
