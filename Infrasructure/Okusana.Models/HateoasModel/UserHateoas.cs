using Okusana.Abstract.Models.HateoasModel;
using Okusana.DTOs.Concrete.User;
using Okusana.Extensions;

namespace Okusana.Models.HateoasModel
{
    public partial record Hateoas
    {
        public record User : IUserHateoas
        {
            public Dictionary<string, List<string>> Links
            {
                get => new Dictionary<string, List<string>>()
            {
                {Hateoas.Methods.Get, new List<string>() { "/User/{Id}", "/User/{CategoryId}", "/User/{Date}" } },
                {Hateoas.Methods.Post,  new List<string>{ $"/{nameof(AddUserDTO)}"} },
                {Hateoas.Methods.Put, new List<string>{ $"/{nameof(UpdateUserDTO)}" } },
                {Hateoas.Methods.Delete, new List<string>{ $"/{nameof(DeleteUserDTO)}" } },
            };
            }
            public Dictionary<string, Dictionary<string, string>> Methods
            {
                get => new Dictionary<string, Dictionary<string, string>>()
            {
                {Hateoas.Methods.Get, typeof(GetUserDTO).GetPropertyDict() },
                {Hateoas.Methods.Post, typeof(AddUserDTO).GetPropertyDict() },
                {Hateoas.Methods.Put, typeof(UpdateUserDTO).GetPropertyDict() },
                {Hateoas.Methods.Delete, typeof(DeleteUserDTO).GetPropertyDict() },
            };
            }
        }
    }
}
