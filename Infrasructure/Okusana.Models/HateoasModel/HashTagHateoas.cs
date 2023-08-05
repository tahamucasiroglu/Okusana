
using Okusana.Abstract.Models.HateoasModel;
using Okusana.DTOs.Concrete.HashTag;
using Okusana.Extensions;

namespace Okusana.Models.HateoasModel
{
    public partial record Hateoas
    {
        public record HashTag : IHashTagHateoas
        {
            public Dictionary<string, List<string>> Links
            {
                get => new Dictionary<string, List<string>>()
            {
                    {Hateoas.Methods.Get, new List<string>() { "/HashTag/{Id}", "/HashTag/{CategoryId}", "/HashTag/{Date}" } },
                    {Hateoas.Methods.Post,  new List<string>{ $"/{nameof(AddHashTagDTO)}"} },
                    {Hateoas.Methods.Put, new List<string>{ $"/{nameof(UpdateHashTagDTO)}" } },
                    {Hateoas.Methods.Delete, new List<string>{ $"/{nameof(DeleteHashTagDTO)}" } },
            };
            }
            public Dictionary<string, Dictionary<string, string>> Methods
            {
                get => new Dictionary<string, Dictionary<string, string>>()
            {
                    {Hateoas.Methods.Get, typeof(GetHashTagDTO).GetPropertyDict() },
                    {Hateoas.Methods.Post, typeof(AddHashTagDTO).GetPropertyDict() },
                    {Hateoas.Methods.Put, typeof(UpdateHashTagDTO).GetPropertyDict() },
                    {Hateoas.Methods.Delete, typeof(DeleteHashTagDTO).GetPropertyDict() },
            };
            }
        }
    }
}
