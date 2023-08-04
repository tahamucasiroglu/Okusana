using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.Request
{
    public sealed record DateTimeRangeRequestDTO : AbstractRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
