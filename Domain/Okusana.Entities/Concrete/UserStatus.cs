using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Entities.Concrete
{
    public class UserStatus
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string FullName { get => Name + " " + Surname; set => FullName = value; }
        public string Email { get; set; } = null!; 
        public string Phone { get; set; } = null!;

    }
}
