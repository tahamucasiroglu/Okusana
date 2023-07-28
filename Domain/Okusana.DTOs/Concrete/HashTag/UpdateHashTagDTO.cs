using Okusana.DTOs.Base;


namespace Okusana.DTOs.Concrete.HashTag
{
    public sealed record UpdateHashTagDTO : UpdateDTO
    {
        public string Name { get; init; } = null!;
    }
}
