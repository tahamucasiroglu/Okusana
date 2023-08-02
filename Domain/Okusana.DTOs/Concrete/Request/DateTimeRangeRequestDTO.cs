using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.Request
{
    public record DateTimeRangeRequestDTO : AbstractRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
