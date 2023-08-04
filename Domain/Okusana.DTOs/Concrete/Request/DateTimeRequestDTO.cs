using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.Request
{
    public sealed record DateTimeRequestDTO : AbstractRequest
    {
        public DateTime Date { get; set; }
    }
}
