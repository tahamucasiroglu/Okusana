using Okusana.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DTOs.Concrete.User
{
    public class UpdateUserDTO : UpdateDTO
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool? Gender { get; set; }
        public string Password { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
