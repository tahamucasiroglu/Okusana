using Okusana.DTOs.Base;

namespace Okusana.DTOs.Concrete.User
{
    public sealed record GetUserDTO : GetDTO
    {
        public string Name { get; init; } = null!;
        public string Surname { get; init; } = null!;
        public string FullName { get => Name + " " + Surname; }  //ignore la
        public string Email { get; init; } = null!;
        public string? Phone { get; init; }
        public string? IdentityNumber { get; init; }
        public DateTime BirthDate { get; init; }
        public int Age { get => DateTime.Now.Year - BirthDate.Year; } //ignorla
        public bool? Gender { get; init; }// 0 erkek 1 kadın null diğer
        public string Password { get; init; } = null!;
        public string Status { get; init; } = null!;
    }
}
