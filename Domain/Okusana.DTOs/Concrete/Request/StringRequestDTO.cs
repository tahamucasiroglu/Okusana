using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.Request
{
    public sealed record StringRequestDTO : AbstractRequest
    {
        public string Value { get; set; } = "";
    }
}
