

using Okusana.DTOs.Abstract;

namespace Okusana.DTOs.Base
{
    abstract public record GetDTO : IGetDTO
    {
        public Guid Id { get; init; }
        public DateTime CreateDate { get; init; }
        public DateTime? UpdateDate { get; init; }
        public DateTime? DeleteDate { get; init; }
        public bool IsDeleted { get; init; }
    }
}
