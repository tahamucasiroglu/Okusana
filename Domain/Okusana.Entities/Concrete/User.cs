using Okusana.Entities.Base;

namespace Okusana.Entities.Concrete
{
    public class User : Entity
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string FullName { get => Name + " " + Surname; }  //ignore la
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get => DateTime.Now.Year - BirthDate.Year; } //ignorla
        public bool? Gender { get; set; }// 0 erkek 1 kadın null diğer
        public string Password { get; set; } = null!;
        public string Status { get; set; } = null!;
        virtual public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
        virtual public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
