using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.User
{
    public sealed record UpdateUserDTO : UpdateDTO
    {
        public string Name { get; init; } = null!;
        public string Surname { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string? Phone { get; init; }
        public string? IdentityNumber { get; init; }
        public DateTime BirthDate { get; init; }
        public bool? Gender { get; init; }
        public string Password { get; init; } = null!;
        public string Status { get; init; } = null!;
    }
}
