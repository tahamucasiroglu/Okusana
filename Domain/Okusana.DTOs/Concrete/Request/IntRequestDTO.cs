using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.Request
{
    public sealed record IntRequestDTO : AbstractRequest
    {
        public int Value { get; set; }
    }
}
