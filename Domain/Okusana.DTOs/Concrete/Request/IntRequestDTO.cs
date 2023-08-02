using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.Request
{
    public record IntRequestDTO : AbstractRequest
    {
        public int Value { get; set; }
    }
}
