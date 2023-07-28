using Okusana.DTOs.Abstract;


namespace Okusana.DTOs.Base
{
    abstract public record DeleteDTO : DTO, IDeleteDTO
    {
        public Guid Id { get; init; }
    }
}
