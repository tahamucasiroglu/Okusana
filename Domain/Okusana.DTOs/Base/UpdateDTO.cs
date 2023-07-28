using Okusana.DTOs.Abstract;


namespace Okusana.DTOs.Base
{
    abstract public record UpdateDTO : DTO, IUpdateDTO
    {
        public Guid Id { get; init; }
    }
}
