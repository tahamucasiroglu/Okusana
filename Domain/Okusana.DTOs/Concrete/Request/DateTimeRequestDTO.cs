using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.Request
{
    public record DateTimeRequestDTO : AbstractRequest
    {
        public DateTime Date { get; set; }
    }
}
